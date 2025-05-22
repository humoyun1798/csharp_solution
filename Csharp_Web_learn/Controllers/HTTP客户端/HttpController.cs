using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net;

namespace Csharp_Web_learn.Controllers.HTTP客户端
{
    public class HttpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult hp()
        {
            var handler = new SocketsHttpHandler
            {
                //HttpClient 仅在创建连接时解析 DNS 条目。 
                //它不跟踪 DNS 服务器指定的任何生存时间 (TTL)。 
                //如果 DNS 条目定期更改，客户端不会意识到这些更新。 
                //要解决此问题，可以通过设置 PooledConnectionLifetime 属性来限制连接的生存期，以便在替换连接时重复执行 DNS 查找。

                PooledConnectionLifetime = TimeSpan.FromMinutes(15) // Recreate every 15 minutes
            };
            var sharedClient = new HttpClient(handler);
            return Ok(sharedClient.ToString());
        }


    }
}
