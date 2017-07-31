using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FytSoa.Common;
using FytSoa.Core;
using FytSoa.Models;

namespace FytSoa.Areas.FytAdmin.Controllers
{
    public class IndexController : BaseController
    {
        public IndexController(DbService s) : base(s)
        {
        }
        #region page
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(GetAdminModel());
        }
        #endregion

        public ActionResult Default()
        {
            return View();
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            CookieHelper.ClearCookie(KeyHelper.COOKIE_ADMIN_USERID);
            SessionHelper.Del(KeyHelper.SESSION_ADMIN_INFO);
            return RedirectToAction("Index", "Login");
        }
    }
}