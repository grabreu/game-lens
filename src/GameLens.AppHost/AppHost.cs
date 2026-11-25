var builder = DistributedApplication.CreateBuilder(args);

builder.AddDotnetProject("api", "../GameLens.Api/GameLens.Api.csproj");

var app = builder.Build();

await app.RunAsync();
