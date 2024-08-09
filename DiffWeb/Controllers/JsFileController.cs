using DiffWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace DiffWeb.Controllers
{
    public class JsFileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddFile(IFormFile txtFile)
        {
            var db = DBC.GetDB();
            if (txtFile != null && txtFile.Length > 0)
            {
                // 保存文件到指定位置
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads", txtFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    txtFile.CopyTo(stream);
                    stream.Position = 0;
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var content = reader.ReadToEnd();
                        var f = new file();
                        f.content = content;
                        f.name = txtFile.FileName;
                        f.datetime = DateTime.Now;
                        db.Insertable(f).ExecuteCommand();
                    }

                }
            }


            return RedirectToAction(nameof(FileList), "File"); ;
        }


        public IActionResult FileList(int pi=1,int ps=20)
        {

            var db = DBC.GetDB();
            var files = db.Queryable<file>().ToList();
            var file = files.GroupBy(p => p.name).Select(g => g.OrderBy(p => p.id).FirstOrDefault()).ToList();

            foreach (var item in file)
            {
                var ll = new List<list>();
                var a = db.Queryable<file>().Where(c => c.name == item.name && c.id != item.id).OrderBy(c => c.id, OrderByType.Desc).ToList();
                if (a != null)
                {
                    foreach (var item2 in a)
                    {
                        var l = new list();
                        l.id = item2.id;
                        l.datetime = item2.datetime;
                        ll.Add(l);
                    }
                }
                item.sonlist = ll;

            }

            return Ok(file);
        }


    }
}
