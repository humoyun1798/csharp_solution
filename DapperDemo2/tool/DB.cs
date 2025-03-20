using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DapperDemo.tool
{
    public class DB
    {
        //private static readonly string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnstr"].ConnectionString;



        public static T Execute<T>(string connStr, Func<IDbConnection, T> func)
        {
            using (var conn = OpenConnection(connStr))
            {
                var result = func(conn);
                return result;
            }
        }



        public static T ExceuteWithTransaction<T>(string connStr, Func<IDbConnection, IDbTransaction, T> func)
        {
            var r = default(T);
            IDbTransaction trans = null;
            using (var conn = OpenConnection(connStr))
            {
                try
                {
                    trans = conn.BeginTransaction();
                    r = func(conn, trans);
                    trans.Commit();


                }
                catch (Exception ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        trans.Dispose();
                    }

                }


            }

            return r;


        }
        public static IDbConnection OpenConnection(string connStr)
        {


            IDbConnection connection = new MySqlConnection(connStr);
            connection.Open();
            return connection;
        }
    }
}
