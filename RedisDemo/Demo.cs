    using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class Demo
    {
        public static void StringTest()
        {
            using (ConnectionMultiplexer conn = RedisHelper.RedisConn)
            {
                string key = "StringTest";
                var db = conn.GetDatabase();

                if (db.KeyExists(key))
                    db.KeyDelete(key);

                db.StringAppend(key, DateTime.Now.ToString());
                Console.WriteLine("写入字符串结束");
                Console.ReadLine();

                Console.WriteLine(db.StringGet(key));
                Console.ReadLine();
            }
        }

        public static void HashSetTest()
        {
            List<UserInfoDto> list = new List<UserInfoDto>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new UserInfoDto()
                {
                    Id = i,
                    LastLoginTime = DateTime.Now,
                    Password = "password" + i.ToString(),
                    StaffId = "StaffId_" + i.ToString(),
                    StaffName = "StaffName_" + i.ToString()
                });
            }

            using (ConnectionMultiplexer conn = RedisHelper.RedisConn)
            {
                string key = "HashSetTest";
                var db = conn.GetDatabase();
                db.KeyDelete(key);
                //string listKey = IdentityMap.CreateKey<UserInfoDto>();
                HashEntry[] items = new HashEntry[list.Count];
                for (int i = 0; i < list.Count - 1; i++)
                {
                    string json = JsonConvert.SerializeObject(list[i]);

                    db.HashSet(key, list[i].Id, json);
                    //db.HashSet(key, "password", list[i].Password);
                    //db.HashSet(key, "StaffId", list[i].StaffId);

                    Console.WriteLine(db.HashGet(key, list[i].Id));
                }
            }
            Console.ReadLine();
        }

        public static void SetTest()
        {
            List<UserInfoDto> list = new List<UserInfoDto>();
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                list.Add(new UserInfoDto()
                {
                    Id = i,
                    LastLoginTime = dt,
                    Password = "password" + i.ToString(),
                    StaffId = "StaffId_" + i.ToString(),
                    StaffName = "StaffName_" + i.ToString()
                });
            }

            using (ConnectionMultiplexer conn = RedisHelper.RedisConn)
            {
                string key = "SetTest:";
                var db = conn.GetDatabase();
                db.KeyDelete(key);
                //string listKey = IdentityMap.CreateKey<UserInfoDto>();
                HashEntry[] items = new HashEntry[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    string json = JsonConvert.SerializeObject(list[i]);
                    db.KeyDelete(key + list[i].Id.ToString());
                    //db.SetAdd(key + list[i].Id.ToString(), json);
                    db.SetAdd(key + list[i].Id.ToString() + ":name", list[i].StaffName);
                    db.SetAdd(key + list[i].Id.ToString() + ":StaffId", list[i].StaffId);

                    var result = db.SetScan(key, "*password99*").FirstOrDefault();
                    Console.WriteLine(result);
                }
            }
            Console.WriteLine("Complete!");

            Console.ReadLine();
        }

        public static void ListTest()
        {
            using (ConnectionMultiplexer conn = RedisHelper.RedisConn)
            {
                string key = "ListTest";
                var db = conn.GetDatabase();
                for (int i = 0; i < 10; i++)
                {
                    db.ListLeftPush(key, "string_" + i.ToString());
                }
                Console.WriteLine("写入完成");
                Console.ReadLine();

                while (0 != db.ListLength(key))
                {
                    //从redis数据库弹出List里的数据
                    var str = db.ListRightPop(key);
                    Console.WriteLine(str);
                }
                Console.ReadLine();
            }
        }

        public static void SortedSet()
        {
            List<UserInfoDto> list = new List<UserInfoDto>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new UserInfoDto()
                {
                    Id = i,
                    LastLoginTime = DateTime.Now,
                    Password = "password" + i.ToString(),
                    StaffId = "StaffId_" + i.ToString(),
                    StaffName = "StaffName_" + i.ToString()
                });
            }

            using (ConnectionMultiplexer conn = RedisHelper.RedisConn)
            {
                string key = "SortedSetTest:";
                var db = conn.GetDatabase();
                db.KeyDelete("SortedSetTest");

                foreach (var item in list)
                {
                    string json = JsonConvert.SerializeObject(item);
                    db.KeyDelete(key + item.Id.ToString());
                    db.KeyDelete("SortedSetTest" + item.Id.ToString() + ":name");
                    db.KeyDelete("SortedSetTest" + item.Id.ToString() + ":StaffId");
                    //db.SetAdd(key + list[i].Id.ToString(), json);
                    db.SortedSetAdd(key + item.Id.ToString() + ":name", item.StaffName, item.Id);
                    db.SortedSetAdd(key + item.Id.ToString() + ":StaffId", item.StaffName, item.Id);
                }

                Console.WriteLine("写入完成");
                Console.ReadLine();

                Console.WriteLine("读取两条记录");
                var result = db.SortedSetRangeByRank(key, 9, 10);
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine(result[i]);
                }

                var result2 = db.SortedSetRangeByRankWithScores(key, 0, -1, Order.Descending);

                var result3 = db.SortedSetScan(key, "*99*", 10).ToList();
                for (int i = 0; i < result3.Count; i++)
                {
                    Console.WriteLine(result3[i]);
                }
                Console.ReadLine();

            }
        }
    }
}
