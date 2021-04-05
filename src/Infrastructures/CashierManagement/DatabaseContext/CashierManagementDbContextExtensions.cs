using CashierManagement.Cashiers;
using CashierManagementInfractureLayer.DatabaseContext.ConfigModels;
using CashierManagementInfractureLayer.DatabaseContext.Migrations;
using CashierManagementInfractureLayer.DatabaseContext.SqlServerSection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CashierManagementInfractureLayer.DatabaseContext
{
    public static class CashierManagementDbContextExtensions
    {
        public static IServiceCollection AddDbCashierContext(this IServiceCollection services, SqlDbOption sqlDbOption)
        {
            services.AddSingleton(sqlDbOption);
            switch (sqlDbOption.SqlDbType)
            {
                case SqlDbTypes.SqlServer:
                    services.AddScoped<IDbMigrationEngine, SqlServerDbMigrationEngine>();
                    services.AddDbContext<EntityDbContext>(builder => builder.UseSqlServer(sqlDbOption.ConnectionString));
                    services.AddScoped<ICachierDbContext, CashierSqlServerDbContext>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return services;
        }
    }
}
