using System;
using Library.Data;
using Library.Data.Seed;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    
                    context.Database.Migrate();

                    var seeder = new Seeder(
                        services.GetService<DataContext>(),
                        services.GetService<AuthorFactory>(),
                        services.GetService<GenreFactory>(),
                        services.GetService<PublicationFactory>(),
                        services.GetService<ReservationFactory>()
                        );
                }
                catch (Exception e)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    
                    logger.LogError(e, "An error occured during migration.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(l =>
                {
                    l.ClearProviders();
                    l.AddConsole();
                })
                .UseStartup<Startup>();
    }
}
