using FluentMigrator.Runner.VersionTableInfo;

namespace CashierManagementInfractureLayer.DatabaseContext.Migrations.SqlServerData
{
    [VersionTableMetaData]
    public class _00000000_CreateTableMigrationMetaData : IVersionTableMetaData
    {
        public object ApplicationContext { get; set; }

        public bool OwnsSchema => false;

        public string SchemaName => "dbo";

        public string TableName => "SchemaVersionDefinition";

        public string ColumnName => "Version";

        public string DescriptionColumnName => "Description";

        public string UniqueIndexName => "SchemaVersion";

        public string AppliedOnColumnName => "AppliedOn";
    }
}
