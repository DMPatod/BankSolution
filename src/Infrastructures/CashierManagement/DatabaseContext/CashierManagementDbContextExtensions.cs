using CashierManagementInfractureLayer.DatabaseContext.ConfigModels;
using CashierManagementInfractureLayer.DatabaseContext.Migrations;
using CashierManagementInfractureLayer.DatabaseContext.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CashierManagementInfractureLayer.DatabaseContext
{
    public static class CashierManagementDbContextExtensions
    {
        public static IServiceCollection AddDbCashierContext(this IServiceCollection services, SqlDbOption sqlDbOption)
        {
            services.AddSingleton(sqlDbOption);
            switch (sqlDbOption.SqlDbTypes)
            {
                case SqlDbTypes.SqlServer:
                    services.AddScoped<IDbMigrationEngine, SqlServerDbMigrationEngine>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return services;
        }
    }
}
