var builder = DistributedApplication.CreateBuilder(args);

// ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
// ┃  PostgreSQL Configuration           ┃
// ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
var psqlUsername = builder.AddParameter("psqluser", secret: true);
var psqlPassword = builder.AddParameter("psqlpassword", secret: true);


var postgres = builder
    //.AddPostgres("postgres", userName: psqlUsername, password: psqlPassword)
    .AddPostgres("postgres")
    .WithPgAdmin() // Add pgAdmin to the PostgreSQL instance
    .WithDataVolume() // Persistant data between restarts
    .AddDatabase("birdapi");

// ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
// ┃  Redis Configuration                ┃
// ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
var cache = builder.AddRedis("cache");

// ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
// ┃  API Service Configuration          ┃
// ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
var apiService = builder.AddProject<Projects.BirdAPI_ApiService>("apiservice")
    .WithReference(postgres);
//.WithEnvironment("PSQL_USER", psqlUsername)
//.WithEnvironment("PSQL_PASSWORD", psqlPassword);

builder.AddProject<Projects.BirdAPI_MigrationService>("migrationservice")
    .WithReference(postgres);

// ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
// ┃  Web Frontend Configuration         ┃
// ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
builder.AddProject<Projects.BirdAPI_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

// ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
// ┃  Build and Run Application          ┃
// ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
builder.Build().Run();