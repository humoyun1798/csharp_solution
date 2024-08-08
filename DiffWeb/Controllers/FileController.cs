using DiffWeb.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using ZstdSharp;

namespace DiffWeb.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void AddModel()
        {
            var db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = "Data Source=localhost;Port=3306;Initial Catalog=js_file;Persist Security Info=True;User ID=root;Password=123456;Pooling=True;charset=utf8mb4;MAX Pool Size=100;Min Pool Size=1;Connection Lifetime=30;", DbType = DbType.MySql, IsAutoCloseConnection = true, InitKeyType = InitKeyType.Attribute });
            db.DbFirst.IsCreateAttribute().CreateClassFile("c:\\MySqlT4\\twitter", "DiffWeb.Models");
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile txtFile)
        {
            var db = DBC.GetDB();
            if (txtFile != null && txtFile.Length > 0)
            {
                // 保存文件到指定位置
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads", txtFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await txtFile.CopyToAsync(stream);
                    stream.Position = 0;
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var content = await reader.ReadToEndAsync();
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


        public IActionResult FileList()
        {

            var db = DBC.GetDB();
            var files = db.Queryable<file>().ToList();
            var file = files.GroupBy(p => p.name).Select(g => g.OrderBy(p => p.id).FirstOrDefault()).ToList();

            foreach (var item in file)
            {
                var ll = new List<list>();
                var a = db.Queryable<file>().Where(c => c.name == item.name && c.id != item.id).OrderBy(c=>c.id,OrderByType.Desc).ToList();
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

            return View(file);
        }


        public IActionResult History(string name)
        {

            var db = DBC.GetDB();
            var files = db.Queryable<file>().Where(c => c.name == name).OrderBy(c => c.id, OrderByType.Desc).ToList();
            return Ok(files);
        }


        [HttpPost]
        public IActionResult Save(string name)
        {
            if (Request.Form.Files.Count == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var file = Request.Form.Files[0];
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file.");
            }

            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "SavedFiles", file.FileName);  // 指定保存的目录和文件名

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return Ok("File saved successfully.");
        }


    }
}
