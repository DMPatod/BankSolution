using FluentMigrator;

namespace CashierManagementInfractureLayer.DatabaseContext.Migrations.SqlServerData
{
    [Migration(20210401)]
    class CreateTableCashier : Migration
    {
        public override void Down()
        {
            Delete.Table("Cashier");
        }

        public override void Up()
        {
            Create.Table("Cashier")
                .WithColumn("Id").AsGuid().PrimaryKey().Identity()
                .WithColumn("Address").AsString("50").NotNullable()
                .WithColumn("StoredAmount").AsDecimal().NotNullable()
                .WithColumn("ConnectedWhen").AsDateTime2().NotNullable();
        }
    }
}
