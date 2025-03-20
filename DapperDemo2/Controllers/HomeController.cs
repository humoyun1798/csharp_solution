using DapperDemo.tool;
using DapperDemo2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DapperDemo2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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



        public IActionResult AAA()
        {
            try
            {

                var k = WangDB.Execute((conn) => conn.Query<ActionlogsModel>("SELECT * FROM `actionlogs` where ModuleName=@ModuleName", new { ModuleName = "用户管理" })).AsList(); ;
                var kk = WangDB.Execute((conn) => conn.ExecuteScalar<int>("SELECT count(0) FROM `actionlogs` where ModuleName=@ModuleName", new { ModuleName = "用户管理" })); ;

                return Json(new { data=k,count = kk });
            }
            catch(Exception ex)
            {

                return Json(new { data = ex.Message+ex.StackTrace });
            }
           
        }


       
    }
}
