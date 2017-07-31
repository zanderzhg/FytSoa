using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FytSoa.Core;
using FytSoa.Model;

namespace FytSoa.Api
{
    public class ApiBaseController:ApiController
    {
        public DbService Service;
        public UserInfo UserInfo;

        public ApiBaseController(DbService s)
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
    }
}