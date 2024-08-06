using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiffWeb.Models
{
    public class DBConfig
    {
        public static string ConnectionString = "";
        public static string ConnectionString_ShortUrl = "";
        public static string ConnectionString_video = "";
        public static string ConnectionString_loacl = "";
        static DBConfig()
        {
            var configurationBuilder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
            var path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            IConfigurationSection sec = root.GetSection("ConnectionStrings");
            foreach (var item in sec.GetChildren())
            {
                if (item.Key == "dbc")
                {
                    ConnectionString = item.Value;
                }
                else if (item.Key == "dba")
                {
                    ConnectionString_ShortUrl = item.Value;
                }
                else if(item.Key == "dbv")
                {
                    ConnectionString_video = item.Value;
                }else if (item.Key == "dbl")
                {
                    ConnectionString_loacl = item.Value;
                }
            }
        }
    }
}
