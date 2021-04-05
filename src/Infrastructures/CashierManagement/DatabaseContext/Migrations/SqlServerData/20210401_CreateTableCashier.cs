using CashierManagementInfractureLayer.DatabaseContext.ConfigModels;
using FluentMigrator;

namespace CashierManagementInfractureLayer.DatabaseContext.Migrations.SqlServerData
{
    [Migration(20210401)]
    [Tags(nameof(SqlDbTypes.SqlServer))]
    public class CreateTableCashier : Migration
    {
        public override void Down()
        {
            Delete.Table("Cashier")
                .InSchema("dbo");
        }

        public override void Up()
        {
            Create.Table("Cashier")
                .InSchema("dbo")
                .WithIdColumn()
                .WithColumn("Guid").AsGuid().NotNullable().WithDefault(SystemMethods.NewGuid)
                .WithColumn("Address").AsString(50).NotNullable()
                .WithColumn("StoredAmount").AsDecimal().NotNullable()
                .WithTimeStamps();
        }
    }
}
