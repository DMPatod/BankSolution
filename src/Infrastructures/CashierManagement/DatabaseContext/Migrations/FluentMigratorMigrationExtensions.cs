using FluentMigrator.Builders.Create.Table;

namespace CashierManagementInfractureLayer.DatabaseContext.Migrations
{
    internal static class FluentMigratorMigrationExtensions
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax WithIdColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                .WithColumn("Id")
                .AsInt32()
                .NotNullable()
                .PrimaryKey()
                .Identity();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithTimeStamps(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                .WithColumn("CreatedAt").AsDateTime2().NotNullable()
                .WithColumn("ModifiedAt").AsDateTime2().NotNullable();
        }
    }
}
