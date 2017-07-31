using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FytSoa.Core;
using FytSoa.Models;

namespace FytSoa.Controllers.AboutPack
{
    public class AboutController : BaseController
    {
        public AboutController(DbService s) : base(s)
        {
        }
        // GET: About
        public ActionResult Index()
        {
            var list = new List<sysadmin>();
            Service.Command<FytOutsourcing>((db, o) =>
            {
                list = db.Queryable<sysadmin>().ToList();

            });
            return View(list);
        }

        
    }
}