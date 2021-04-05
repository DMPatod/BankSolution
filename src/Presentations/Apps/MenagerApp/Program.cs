using CashierManagementInfractureLayer.DatabaseContext;
using CashierManagementInfractureLayer.DatabaseContext.Migrations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MenagerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            try
            {
                RunMigrations(host.Services);
            }
            catch (Exception ex)
            {
                throw new Exception("MigrationEnginesExceptions", ex);
            }
            host.Run();
        }

        private static void RunMigrations(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var provider = serviceScope.ServiceProvider;
                using (var dbContext = provider.GetRequiredService<EntityDbContext>())
                {
                    dbContext.Database.Migrate();
                }

                var migrationEngines = provider.GetServices<IDbMigrationEngine>();
                foreach (var engine in migrationEngines)
                {
                    engine.MigrateUp();
                }
            }

        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
