using DiffWeb.Models;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public IActionResult FileList()
        {

            var db = DBC.GetDB();
            var files = db.Queryable<file>().ToList();
            var file = files.GroupBy(p => p.name).Select(g => g.OrderBy(p => p.id).FirstOrDefault()).ToList();

            return Ok(file);
        }


        public IActionResult History(string name)
        {

            var db = DBC.GetDB();
            var files = db.Queryable<file>().Where(c=>c.name==name).OrderBy(c=>c.id,OrderByType.Desc).ToList();
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
