using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FytSoa.Areas.FytAdmin.Controllers.sysmenuPack;
using FytSoa.Common;
using FytSoa.Common.EnumsHelper;
using FytSoa.Common.Log;
using FytSoa.Core;
using FytSoa.Models;
using SqlSugar;

namespace FytSoa.Areas.FytAdmin.Controllers
{
    public class SysMenuController : BaseController
    {
        public SysMenuController(DbService s) : base(s)
        {
        }

        #region page
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 编辑/添加页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Change(int id)
        {
            var pid = FytRequest.GetQueryInt("pid", 0);
            var model=new sysmenu();
            Service.Command<MenuOutsourcing>((db, o) =>
            {
                model = db.Queryable<sysmenu>().Single(m => m.ID == id) ?? new sysmenu(){ ParentId = pid, SysID = 1, Sort = 0,IsShow = true};

                #region 下拉框父级
                var list = db.Queryable<sysmenu>().ToList();
                var sList = o.RecursiveModule(list);
                var selectList = sList.Select(p => new SelectListItem
                {
                    Text = Utils.LevelName(p.Name, p.ClassLayer),
                    Value = p.ID.ToString(CultureInfo.InvariantCulture)
                }).ToList();
                selectList.Insert(0, new SelectListItem() { Text = "父级", Value = "0" });
                ViewBag.selectList = selectList.AsEnumerable().ToList();
                #endregion

                #region 查询排序的最大值

                if (id == 0)
                {
                    var pModel = db.Queryable<sysmenu>().OrderBy(m => m.Sort, OrderByType.Desc).First();
                    if (pModel != null)
                    {
                        model.Sort = pModel.Sort + 1;
                    }
                    else
                    {
                        model.Sort = 1;
                    }
                }
                
                #endregion
            });

            if (model != null) return View(model);
            return View();
        }
        #endregion

        #region api
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public JsonResult Getdata()
        {
            var jsonm=new ResultJson();
            Service.Command<MenuOutsourcing>((db, o) =>
            {
                var list = db.Queryable<sysmenu>().ToList();
                var sList = o.RecursiveModule(list);
                foreach (var item in sList)
                {
                    item.Name = Utils.LevelName(item.Name, item.ClassLayer);
                }
                jsonm.data = sList;
                jsonm.total = 1;
            });
            return Json(jsonm);
        }

        /// <summary>
        /// 菜单栏目自定义排序
        /// </summary>
        /// <returns></returns>
        public JsonResult ColSort()
        {
            var jsonm = new ResultJson();
            int p = FytRequest.GetFormInt("p"),
                i = FytRequest.GetFormInt("i"),
                ob = FytRequest.GetFormInt("o");
            Service.Command<MenuOutsourcing>((db, o) =>
            {
                o.MenuSort(db,p,i,ob);
            });
            return Json(jsonm);
        }

        /// <summary>
        /// 提交表单，添加/修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Change(sysmenu model)
        {
            var jsonm = new ResultJson();
            try
            {
                Service.Command<MenuOutsourcing>((db, o) =>
                {
                    jsonm=o.Change(db, model, GetAdminModel().sysadmin.LoginName);
                });
            }
            catch (Exception ex)
            {
                jsonm.msg = "保存数据发生错误！ 消息：" + ex.Message;
                jsonm.status = 500;
            }
            return Json(jsonm);
        }
        #endregion
    }
}