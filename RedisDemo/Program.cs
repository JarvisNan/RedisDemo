using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace RedisDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var redis = ConnectionMultiplexer.Connect("122.152.205.186:6379,password=123456");
            var db = redis.GetDatabase();

            db.StringSet("name", "giao");
            var name = db.StringGet("name");
            Console.WriteLine(name);
            CreateWebHostBuilder(args).Build().Run();
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
