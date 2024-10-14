using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB
{
    public class SqliteGetDB
    {
        public static SqlSugarClient GetDB()
        {

            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                //ConnectionString = @"Data Source=E:\sql.db;Version=3",//Master Connection
                //DbType = SqlSugar.DbType.Sqlite,
                //InitKeyType = InitKeyType.Attribute,
                //IsAutoCloseConnection = true,

                ConnectionString = @$"Data Source=C:\sqlite\test.db", // SQLite 连接字符串
                DbType = SqlSugar.DbType.Sqlite, // 指定数据库类型为 SQLite
                IsAutoCloseConnection = true, // 自动关闭连接
                InitKeyType = InitKeyType.Attribute//从实体特性中读取主键自增列信息

            });
            return db;
        }
    }
}
