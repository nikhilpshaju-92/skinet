using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
           using (var scope = host.Services.CreateScope())
           {
            var services =  scope.ServiceProvider;
            var loggerfactory = services.GetRequiredService<ILoggerFactory>();
             try
             {
                var context = services.GetRequiredService<StoreContext>();
                await context.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(context,loggerfactory);

             }
             catch (Exception ex)
             {
                var logger = loggerfactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occored during migration");

             }

           }
           host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
