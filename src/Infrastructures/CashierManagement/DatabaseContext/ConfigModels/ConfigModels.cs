﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CashierManagementInfractureLayer.DatabaseContext.ConfigModels
{
    public class SqlDbConfig
    {
        public int SelectIndex { get; set; }
        public List<SqlDbOption> SqlDbOptions { get; set; } = new List<SqlDbOption>();
        public SqlDbOption SelectedDbOption()
        {
            if (SqlDbOptions == null)
            {
                throw new Exception("");
            }
            if (!SqlDbOptions.Any())
            {
                throw new Exception("");
            }
            var dbOptions = SqlDbOptions.FirstOrDefault(o => o.Index == SelectIndex);
            if (dbOptions == null)
            {
                throw new Exception("");
            }
            return dbOptions;
        }
    }
    public class SqlDbOption
    {
        public int Index { get; set; }
        public SqlDbTypes SqlDbTypes { get; set; }
        public string ConnectionString { get; set; } = string.Empty;
    }

    public enum SqlDbTypes
    {
        SqlServer = 1
    }
}
