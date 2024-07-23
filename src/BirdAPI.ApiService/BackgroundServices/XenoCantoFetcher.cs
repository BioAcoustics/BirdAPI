using System.Text.Json;
using BirdAPI.ApiService.Database.Models;
using BirdAPI.Data.Repositories;

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
            _serviceScopeFactory = serviceScopeFactory;
            _progress = LoadProgress();
            hostApplicationLifetime.ApplicationStopping.Register(OnApplicationStopping);
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

                    await FetchQualityPagesAsync(quality, currentPage, numPages, stoppingToken);
                }

                // Reset progress to start from the beginning
                ResetProgress();
            }
        }

        private async Task FetchQualityPagesAsync(char quality, int currentPage, int numPages, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested && currentPage <= numPages)
            {
                try
                {
                    var xenoCantoResponse = await FetchPageAsync(quality, currentPage, cancellationToken);

                    if (xenoCantoResponse != null)
                    {
                        numPages = xenoCantoResponse.numPages;
                        Console.WriteLine($"Fetched page {currentPage} of {numPages} for quality {quality}");
                        await SaveEntriesAsync(xenoCantoResponse.recordings, cancellationToken);
                    }

                    UpdateProgress(quality, ++currentPage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                await Task.Delay(1000, cancellationToken); // Delay for 1 second
            }
        }

        private async Task<XenoCantoResponse> FetchPageAsync(char quality, int currentPage, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync($"{BaseUrl}{quality}&page={currentPage}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<XenoCantoResponse>(content);
        }

        private async Task SaveEntriesAsync(IEnumerable<XenoCantoEntry> recordings, CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var xenoCantoEntryRepository = scope.ServiceProvider.GetRequiredService<IXenoCantoEntryRepository>();
            await xenoCantoEntryRepository.AddOrUpdateXenoCantoEntryRangeAsync(recordings, cancellationToken);
        }

        private void UpdateProgress(char quality, int currentPage)
        {
            _progress.CurrentQuality = quality;
            _progress.CurrentPage = currentPage;
        }

        private void ResetProgress()
        {
            _progress.CurrentQuality = 'a';
            _progress.CurrentPage = 1;
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

    public class XenoCantoResponse
    {
        public int numPages { get; set; }
        public List<XenoCantoEntry> recordings { get; set; }
    }
    
}
