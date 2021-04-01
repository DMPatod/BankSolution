using CashierManagementInfractureLayer.DatabaseContext.ConfigModels;
using CashierManagementInfractureLayer.DatabaseContext.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CashierManagementInfractureLayer.DatabaseContext.SqlServerSection
{
    public class SqlServerDbMigrationEngine : IDbMigrationEngine
    {
        public SqlDbOption SqlDbOption { get; }
        public IReadOnlyList<Assembly> Assemblies { get; }

        public SqlServerDbMigrationEngine(SqlDbOption sqlDbOption)
        {
            SqlDbOption = sqlDbOption;
            Assemblies = new[] { typeof(SqlServerDbMigrationEngine).Assembly };
        }
        public void MigrateUp()
        {
            //var serviceProvider = CreateServices
        }
        private IServiceProvider CreateService(SqlDbTypes sqlDbOptions, string dbConnectionString, Assembly[] assemblies)
        {
            var services = new ServiceCollection()
                .AddLogging();

            switch (sqlDbOptions)
            {
                case SqlDbTypes.SqlServer:

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sqlDbOptions), sqlDbOptions, null);
            }
            return services.BuildServiceProvider(false);
        }
    }
}
