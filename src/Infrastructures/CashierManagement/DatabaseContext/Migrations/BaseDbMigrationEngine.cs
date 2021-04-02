using CashierManagementInfractureLayer.DatabaseContext.ConfigModels;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.VersionTableInfo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CashierManagementInfractureLayer.DatabaseContext.Migrations
{
    public abstract class BaseDbMigrationEngine : IDbMigrationEngine
    {
        public abstract SqlDbOption SqlDbOption { get; }
        public abstract IReadOnlyList<Assembly> Assemblies { get; }
        public abstract IVersionTableMetaData VersionTableMetaData { get; }
        public void MigrateUp()
        {
            var services = CreateService(SqlDbOption.SqlDbType, SqlDbOption.ConnectionString, Assemblies.ToArray());
            using (var scope = services.CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
            }
        }
        private IServiceProvider CreateService(SqlDbTypes sqlDbOptions, string dbConnectionString, Assembly[] assemblies)
        {
            var services = new ServiceCollection().AddFluentMigratorCore().AddLogging(lb => lb.AddFluentMigratorConsole());

            switch (sqlDbOptions)
            {
                case SqlDbTypes.SqlServer:
                    services.Configure<RunnerOptions>(opt =>
                    {
                        opt.Tags = new[]
                        {
                            SqlDbTypes.SqlServer.ToString()
                        };
                    });
                    services.ConfigureRunner(rb =>
                    {
                        rb.AddSqlServer().WithGlobalConnectionString(dbConnectionString).ScanIn(assemblies).For.Migrations();
                        if (VersionTableMetaData != null)
                        {
                            rb.WithVersionTable(VersionTableMetaData);
                        }
                    });
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sqlDbOptions), sqlDbOptions, null);
            }

            return services.BuildServiceProvider(false);
        }
    }
}
