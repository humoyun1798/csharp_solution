using StackExchange.Redis;

namespace RedisDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var get = Get("你");
                if (get == null)
                {
                    Console.WriteLine(Set("你", "2B", 60));
                }
                else
                {

                    Console.WriteLine(get);
                }

                
            }
            catch (Exception ex) { 
            
            Console.WriteLine(ex.ToString()+ex.StackTrace);
            }

         

        }

        static bool Set(string key, string value, int n) {

            var redis = RedisHelper.RedisConn;
            var db = redis.GetDatabase();
            return db.StringSet(key, value, TimeSpan.FromSeconds(n));

        }
        static string? Get(string key)
        {

            var redis = RedisHelper.RedisConn;
            var db = redis.GetDatabase();
            return db.StringGet(key);

        }


    }
}