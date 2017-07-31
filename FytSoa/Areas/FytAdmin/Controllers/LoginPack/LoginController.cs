using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FytSoa.Common;
using FytSoa.Core;
using FytSoa.Core.Models;
using FytSoa.Models;

namespace FytSoa.Areas.FytAdmin.Controllers
{
    [SkipLogin]
    public class LoginController : BaseController
    {
        public LoginController(DbService s) : base(s)
        {
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["code"] = Utils.GetCheckCode(6);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(vLoginModel fmodel)
        {
            var json=new ResultJson();
            Service.Command<LoginOutsourcing>((db, o) =>
            {
                json = o.Logins(db, fmodel);
            });
            return Json(json);
        }
        
    }
}