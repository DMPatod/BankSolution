using CashierManagementInfractureLayer.DatabaseContext.ConfigModels;
using CashierManagementInfractureLayer.DatabaseContext.Migrations;
using FluentMigrator.Runner.VersionTableInfo;
using System.Collections.Generic;
using System.Reflection;

namespace CashierManagementInfractureLayer.DatabaseContext.SqlServerSection
{
    public class SqlServerDbMigrationEngine : BaseDbMigrationEngine
    {
        public SqlServerDbMigrationEngine(SqlDbOption sqlDbOption)
        {
            SqlDbOption = sqlDbOption;
            VersionTableMetaData = null;
            Assemblies = new[] { typeof(SqlServerDbMigrationEngine).Assembly };
        }
        public override SqlDbOption SqlDbOption { get; }
        public override IReadOnlyList<Assembly> Assemblies { get; }
        public override IVersionTableMetaData VersionTableMetaData { get; }
    }
}
