using Microsoft.Extensions.Hosting;

namespace Aspire.ServiceDiscovery.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();
        builder.Services.AddProblemDetails();
        builder.Services.AddOpenApi();

        builder.Services.AddHttpClient<LabseClient>(
            static (client) =>
            {
                client.BaseAddress = new Uri("http://labse");
            }
            );

        var app = builder.Build();

        app.UseExceptionHandler();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.MapGet("/", (LabseClient labseClient) => labseClient.LabseTest());

        app.MapDefaultEndpoints();

        app.Run();
    }
}
