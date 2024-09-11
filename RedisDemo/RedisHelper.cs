using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class RedisHelper
    {
        static ConfigurationOptions configurationOptions = ConfigurationOptions.Parse("127.0.0.1" + ":" + "6379");
        static ConnectionMultiplexer redisConn;

        public static ConnectionMultiplexer RedisConn
        {
            get
            {
                return ConnectionMultiplexer.Connect(configurationOptions);
            }
        }
    }
}
