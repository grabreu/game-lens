using GameLens.ServiceDefaults;
using Microsoft.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, _, _) =>
    {
        document.Info = new OpenApiInfo
        {
            Title = "GameLens API",
            Version = "v1",
            Description = "Games catalog API with search by meaning, e.g. \"dark metroidvania\".",
            Contact = new()
            {
                Name = "Gabriel Abreu",
                Url = new("https://grabreu.dev")
            }
        };
        document.Servers = [];
        return Task.CompletedTask;
    });
});

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapOpenApi();
app.MapScalarApiReference();
app.Map("/", () => Results.Redirect("/scalar"));

await app.RunAsync();
