using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FytSoa.Common;
using FytSoa.Common.EnumsHelper;
using FytSoa.Common.Log;
using FytSoa.Core;
using FytSoa.Models;

namespace FytSoa.Controllers
{
    public class TestController : BaseController
    {
        public TestController(DbService s) : base(s) { }
        // GET: Test
        public ActionResult Index()
        {
            //测试日志
            /*var jm = DES3Encrypt.EncryptString("admins");
            LogProvider.Error(LoggerEnums.Info.ToString(), "加密测试：：" + jm);
            LogProvider.Error(LoggerEnums.Info.ToString(), "解密测试：" + DES3Encrypt.DecryptString(jm));*/
            var json=new ResultJson();
            var list = new List<sysadmin>();
            Service.Command<FytOutsourcing>((db, o) =>
            {
                var queryable = db.Queryable<sysadmin>();
                int pageCount = queryable.Count();
                list= queryable.ToPageList(1, 20);
                json.data = list;
                json.total = Total(20, pageCount);
            });
            return View(list);
        }
    }
}