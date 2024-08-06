using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DiffPlex.DiffBuilder;
using DiffWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiffWeb.Controllers
{
    public class DiffController : Controller
    {
        private readonly ISideBySideDiffBuilder diffBuilder;

        public DiffController(ISideBySideDiffBuilder bidiffBuilder)
        {
            diffBuilder = bidiffBuilder;
        }


        public IActionResult Index()
        {
            return View();
        }


        //public IActionResult Diff(string oldText, string newText)
        //{
        //    var model = diffBuilder.BuildDiffModel(oldText ?? string.Empty, newText ?? string.Empty);

        //    return View(model);
        //}
        public IActionResult Diff(int oldid, int newid)
        {

            var db = DBC.GetDB();
            var o = db.Queryable<file>().Where(c => c.id == oldid).First();
            var n = db.Queryable<file>().Where(c => c.id == newid).First();

            var model = diffBuilder.BuildDiffModel(o.content ?? string.Empty, n.content ?? string.Empty);

            return View(model);
            //return Ok(files);
        }

        //public IActionResult Diff(int newid, int oldid)
        //{

        //    var db = DBC.GetDB();
        //    var n = db.Queryable<file>().Where(c => c.id == newid).First();
        //    var o = db.Queryable<file>().Where(c => c.id == oldid).First();

        //    var model = diffBuilder.BuildDiffModel(n.content ?? string.Empty, o.content ?? string.Empty);

        //    return View(model);
        //}

    }
}
