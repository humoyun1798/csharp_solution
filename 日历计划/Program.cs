using Dm;
using Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using DB;
using 日历计划.Model;

namespace 日历计划
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {


                var db = SqliteGetDB.GetDB();
                Console.Write("请输入今天是不是工作日(0休息 1工作日):");
                var enter = Console.ReadLine();

                //开始时间
                var start = DateTime.Now.ToString("yyyy-MM-dd 07:00:00");
                var start_time = Convert.ToDateTime(start);
                var day_count = DateTime.Now.ToString("yyyy-MM-dd");

                //工作日
                var Array1 = new List<plan>();


                //休息日
                var Array2 = new List<plan>();
                //奖励
                var Array3 = new List<plan>();

                Array3.Add(new plan() { hour = 2, str = "自由支配" });


                //var flag = 0;

                ////2024 法定节假日
                //var holidays = new List<DateTime>() {
                //    new DateTime(2024, 2, 10), new DateTime(2024, 2, 11), new DateTime(2024, 2, 12), new DateTime(2024, 2, 13), new DateTime(2024, 2, 14), new DateTime(2024, 2, 15), new DateTime(2024, 2, 16), new DateTime(2024, 2, 17),
                //    new DateTime(2024, 4, 4), new DateTime(2024, 4, 5), new DateTime(2024, 4, 6),
                //    new DateTime(2024, 5, 1), new DateTime(2024, 5, 2), new DateTime(2024, 5, 3), new DateTime(2024, 5, 4), new DateTime(2024, 5, 5),
                //    new DateTime(2024, 6, 10),
                //    new DateTime(2024, 9, 15), new DateTime(2024, 9, 16), new DateTime(2024, 9, 17),
                //    new DateTime(2024, 10, 1), new DateTime(2024, 10, 2), new DateTime(2024, 10, 3), new DateTime(2024, 10, 4), new DateTime(2024, 10, 5), new DateTime(2024, 10, 6), new DateTime(2024, 10, 7)
                //};
                    
                //if (holidays.Contains(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))))
                //{

                //}


                ////周六日
                //DayOfWeek day = DateTime.Now.DayOfWeek;
                //if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
                //{
                //    Console.WriteLine($"{DateTime.Now.ToShortDateString()}是周六或周日。");
                //}
                //else
                //{
                //    Console.WriteLine($"{DateTime.Now.ToShortDateString()}不是周六或周日。");
                //}


                if (start_time.Hour <= 21)
                {

                    var t = new time();
                    t.state = 0;
                    t.type = Convert.ToInt32(enter);
                    
                    t.day = start_time.ToString("yyyy-MM-dd HH:mm:ss") + "-" + start_time.AddHours(2).ToString("yyyy-MM-dd HH:mm:ss");
                    t.day_count = DateTime.Now.ToString("yyyy-MM-dd");


                    db.Insertable(t).ExecuteCommand();
                    Console.WriteLine("排课结束");
                }
                //var aa = new time();
                //aa.state = 0;
                //aa.day = DateTime.Now.ToString();
                //aa.str = "老铁666";
                //db.Insertable(aa).ExecuteCommand();

                var a = db.Queryable<time>().Where(c=>c.day_count== DateTime.Now.ToString("yyyy-MM-dd")).ToList();

                Console.WriteLine("===============================");

                foreach (var item in a)
                {
                    Console.WriteLine($"id:{item.ID} day:{item.day} state:{item.state}  str:{item.str}");
                }
                Console.WriteLine("===============================");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }





        }

        //public static SqlSugarClient GetDB()
        //{

        //    SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
        //    {
        //        //ConnectionString = @"Data Source=E:\sql.db;Version=3",//Master Connection
        //        //DbType = SqlSugar.DbType.Sqlite,
        //        //InitKeyType = InitKeyType.Attribute,
        //        //IsAutoCloseConnection = true,

        //        ConnectionString = @$"Data Source=C:\sqlite\test.db", // SQLite 连接字符串
        //        DbType = SqlSugar.DbType.Sqlite, // 指定数据库类型为 SQLite
        //        IsAutoCloseConnection = true, // 自动关闭连接
        //        InitKeyType = InitKeyType.Attribute//从实体特性中读取主键自增列信息

        //    });
        //    return db;
        //}
    }
}
