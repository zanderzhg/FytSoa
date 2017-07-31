using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FytSoa.Common;
using FytSoa.Controllers;
using FytSoa.Core;
using FytSoa.Models;

namespace FytSoa.Api
{
    public class AppController : ApiBaseController
    {
        public AppController(DbService s) : base(s)
        {
        }

        public ResultJson Get()
        {
            var json = new ResultJson();
            List<sysadmin> list;
            Service.Command<FytOutsourcing>((db, o) =>
            {
                var queryable = db.Queryable<sysadmin>();
                int pageCount = queryable.Count();
                list = queryable.ToPageList(1, 20);
                json.data = list;
                json.total = Total(20, pageCount);
            });
            return json;
        }

        public ResultJson Get(int id)
        {
            var json = new ResultJson();
            sysadmin model;
            Service.Command<FytOutsourcing>((db, o) =>
            {
                model = db.Queryable<sysadmin>().InSingle(id);
                json.data = model;
            });
            return json;
        }



    }
}
