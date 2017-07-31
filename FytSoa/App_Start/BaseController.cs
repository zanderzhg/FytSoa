using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FytSoa.Common;
using FytSoa.Core;
using FytSoa.Model;
using FytSoa.Models;

namespace FytSoa
{
    public class BaseController : Controller
    {
        public DbService Service;
        public UserInfo UserInfo;

        public BaseController(DbService s)
        {
            Service = s;
        }

        /// <summary>
        /// 返回总页数
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public int Total(int pageSize, int pageCount)
        {
            return Convert.ToInt32(Math.Ceiling(pageCount * 1.0 / pageSize));
        }

        /// <summary>
        /// 返回登录的账号信息
        /// </summary>
        /// <returns></returns>
        public AdminModel GetAdminModel()
        {
            byte[] uobj = SessionHelper.GetSession(KeyHelper.SESSION_ADMIN_INFO) as byte[];
            AdminModel umodel=new AdminModel();
            if (uobj != null && uobj.Length > 0)
            {
                umodel = ProtobufHelper.DeSerialize<AdminModel>(uobj);
            }
            return umodel;
        }
    }
    public class BaseOutsourcing
    {
    }
}