using SimpleGraphClient.Models;

namespace SimpleGraphClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.Configure<AzureAdOptions>(builder.Configuration.GetSection("AzureADOptions"));
            builder.Services.Configure<ServiceAccountOptions>(builder.Configuration.GetSection("ServiceAccountOptions"));

            builder.Services.AddSingleton<IGraphService, GraphService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/me", (IGraphService graphService) => graphService.Me());

            app.Run();
        }
    }
}