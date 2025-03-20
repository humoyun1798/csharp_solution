using System;
using System.Data;

namespace DapperDemo.tool
{
    public class WangDB : DB
    {

        private static readonly string connStr = "Server=localhost;Port=3306;Database=collection;Uid=root;Pwd=123456;Pooling=True;charset=utf8;Connection Lifetime=30;Max Pool Size = 1024;Min Pool Size=1;SslMode = none;Convert Zero Datetime=True;Allow Zero Datetime=True";

        public static T Execute<T>(Func<IDbConnection, T> func)
        {

            return Execute<T>(connStr, func);
        }


        public static IDbConnection OpenConnection() { 
        
            return OpenConnection(connStr);
        }
        public static T ExceuteWithTransaction<T>(Func<IDbConnection,IDbTransaction,T> func)
        {

            return ExceuteWithTransaction(connStr,func);
        }

    }
}
