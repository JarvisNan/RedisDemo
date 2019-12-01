using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedisDemo.Models;
using StackExchange.Redis;

namespace RedisDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _db;

        public HomeController(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _db = redis.GetDatabase();
        }
        public IActionResult Index()
        {
            _db.StringSet("fullname", "GiaoGiao");
            var name = _db.StringGet("fullname");

            return View("Index",name);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
