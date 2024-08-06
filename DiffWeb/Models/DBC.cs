using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiffWeb.Models
{
    public class DBC
    {
        public static SqlSugarClient GetDB()
        {

            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = DBConfig.ConnectionString,//Master Connection
                DbType = DbType.MySql,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true,
            });

            return db;
        }
    }
}
