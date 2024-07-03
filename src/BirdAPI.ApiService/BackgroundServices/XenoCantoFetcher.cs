using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using BirdAPI.ApiService.Commands;
using BirdAPI.ApiService.Database.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BirdAPI.ApiService.BackgroundServices
{
    public class XenoCantoFetcher : BackgroundService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string BaseUrl = "https://xeno-canto.org/api/2/recordings?query=q:";
        private const string ProgressFilePath = "fetchProgress.json";
        private readonly FetchProgress _progress;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public XenoCantoFetcher(
            IHttpClientFactory httpClientFactory, 
            IHostApplicationLifetime hostApplicationLifetime,
            IServiceScopeFactory serviceScopeFactory)
        {
            _httpClientFactory = httpClientFactory;
            _progress = LoadProgress();
            hostApplicationLifetime.ApplicationStopping.Register(OnApplicationStopping);
            _serviceScopeFactory = serviceScopeFactory;
        }

protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
    using var periodicTimer = new PeriodicTimer(TimeSpan.FromMinutes(10));
    _ = PeriodicSaveAsync(periodicTimer, stoppingToken);

    char[] qualityRatings = { 'a', 'b', 'c', 'd', 'e' };

    while (!stoppingToken.IsCancellationRequested)
    {
        foreach (var quality in qualityRatings)
        {
            if (stoppingToken.IsCancellationRequested) break;

            var currentPage = quality == _progress.CurrentQuality ? _progress.CurrentPage : 1;
            var numPages = int.MaxValue;

            while (!stoppingToken.IsCancellationRequested && currentPage <= numPages)
            {
                try
                {
                    var httpClient = _httpClientFactory.CreateClient();
                    var response = await httpClient.GetAsync($"{BaseUrl}{quality}&page={currentPage}", stoppingToken);
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync(stoppingToken);
                    var xenoCantoResponse = JsonSerializer.Deserialize<XenoCantoResponse>(content);

                    if (xenoCantoResponse != null)
                    {
                        numPages = xenoCantoResponse.numPages;
                        Console.WriteLine($"Fetched page {currentPage} of {numPages} for quality {quality}");

                        using (var scope = _serviceScopeFactory.CreateScope())
                        {
                            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                            var command = new AddXenoCantoItemCommand { XenoCantoEntries = xenoCantoResponse.recordings };
                            await mediator.Send(command);
                        }
                    }

                    currentPage++;
                    _progress.CurrentQuality = quality;
                    _progress.CurrentPage = currentPage;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                await Task.Delay(1000, stoppingToken); // Delay for 1 second
            }
        }

        // Reset progress to start from the beginning
        _progress.CurrentQuality = 'a';
        _progress.CurrentPage = 1;
    }
}

        private FetchProgress LoadProgress()
        {
            if (File.Exists(ProgressFilePath))
            {
                var json = File.ReadAllText(ProgressFilePath);
                return JsonSerializer.Deserialize<FetchProgress>(json) ?? new FetchProgress { CurrentQuality = 'a', CurrentPage = 1 };
            }

            return new FetchProgress { CurrentQuality = 'a', CurrentPage = 1 };
        }

        private void SaveProgress()
        {
            var json = JsonSerializer.Serialize(_progress);
            File.WriteAllText(ProgressFilePath, json);
        }

        private void OnApplicationStopping()
        {
            SaveProgress();
        }

        // Periodically save the progress to a file
        private async Task PeriodicSaveAsync(PeriodicTimer timer, CancellationToken stoppingToken)
        {
            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    SaveProgress();
                }
            }
            catch (OperationCanceledException)
            {
                // Handle the cancellation exception if needed
            }
        }
    }

    public class FetchProgress
    {
        public char CurrentQuality { get; set; }
        public int CurrentPage { get; set; }
    }
}
