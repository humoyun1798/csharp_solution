﻿using StackExchange.Redis;

namespace RedisDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 创建连接到Redis服务器的连接Multiplexer
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");

            // 获取数据库
            IDatabase db = redis.GetDatabase();

            // 存储数据
            db.StringSet("myKey", "Hello, Redis!");

            // 读取数据
            string value = db.StringGet("myKey");
            Console.WriteLine($"Value retrieved from Redis: {value}");

            // 示例：存储哈希表
            HashEntry[] hashEntries = { new HashEntry("field1", "value1"), new HashEntry("field2", "value2") };
            db.HashSet("myHash", hashEntries);

            // 示例：读取哈希表
            HashEntry[] retrievedHashEntries = db.HashGetAll("myHash");
            foreach (var entry in retrievedHashEntries)
            {
                Console.WriteLine($"Field: {entry.Name}, Value: {entry.Value}");
            }
        }
    }
}