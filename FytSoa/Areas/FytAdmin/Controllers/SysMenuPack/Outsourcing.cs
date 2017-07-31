using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FytSoa.Common;
using FytSoa.Core.Models;
using FytSoa.Models;
using SqlSugar;

namespace FytSoa.Areas.FytAdmin.Controllers.sysmenuPack
{
    public class MenuOutsourcing
    {
        #region 修改和添加
        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="db"></param>
        /// <param name="model"></param>
        /// <param name="adminUser"></param>
        /// <returns></returns>
        public ResultJson Change(SqlSugarClient db, sysmenu model,string adminUser)
        {
            var json = new ResultJson() { backurl = "close",msg = "保存成功~"};
            model.UpdateDate = DateTime.Now;
            model.SysID = 1;
            if (model.ID == 0)
            {
                var tempM = db.Insertable(model).ExecuteReutrnIdentity();
                if (model.ParentId > 0)
                {
                    //说明有父级  根据父级，查询对应的模型
                    var parModel = db.Queryable<sysmenu>().InSingle(model.ParentId);
                    if (parModel != null)
                    {
                        model.ClassList = parModel.ClassList + Convert.ToInt32(tempM) + ",";
                        model.ClassLayer = parModel.ClassLayer + 1;
                        model.ID = Convert.ToInt32(tempM);
                    }
                }
                else
                {
                    //没有父级
                    model.ClassList = "," + Convert.ToInt32(tempM) + ",";
                }
                db.Updateable(model).ExecuteCommand();
            }
            else
            {
                //判断修改之前的父级栏目是否和当前的相当
                if (FytRequest.GetFormInt("SouParentId") != model.ParentId)
                {
                    //不相等更改等级
                    var parModel = db.Queryable<sysmenu>().InSingle(model.ParentId);
                    if (parModel != null)
                    {
                        model.ClassList = parModel.ClassList + model.ID + ",";
                        model.ClassLayer = parModel.ClassLayer + 1;
                    }
                }
                db.Updateable(model).ExecuteCommand();
            }
            db.Insertable(new syslog()
            {
                UserName = adminUser,
                Title = "修改菜单：" + model.Name,
                IP = FytRequest.GetIp(),
                LogType = 6,
                LogGrade = "1",
                RequestUrl = FytRequest.GetUrl(),
                AddDate = DateTime.Now
            }).ExecuteCommand();
            return json;
        }
        #endregion

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="db"></param>
        /// <param name="p"></param>
        /// <param name="i"></param>
        /// <param name="o"></param>
        public void MenuSort(SqlSugarClient db, int p,int i,int o)
        {
            int a = 0, b = 0, c = 0;
            var list = db.Queryable<sysmenu>().Where(m => m.ParentId == p).OrderBy(m => m.Sort).ToList();
            if (list.Count > 0)
            {
                var index = 0;
                foreach (var item in list)
                {
                    index++;
                    if (index == 1)
                    {
                        if (item.ID == i) //判断是否是头如果上升则不做处理
                        {
                            if (o == 1) //下降一位
                            {
                                a = Convert.ToInt32(item.Sort);
                                b = Convert.ToInt32(list[index].Sort);
                                c = a;
                                a = b;
                                b = c;
                                item.Sort = a;
                                db.Updateable(item).ExecuteCommand();
                                var nitem = list[index];
                                nitem.Sort = b;
                                db.Updateable(nitem).ExecuteCommand();
                                break;
                            }
                        }
                    }
                    else if (index == list.Count)
                    {
                        if (item.ID == i) //最后一条如果下降则不做处理
                        {
                            if (o == 0) //上升一位
                            {
                                a = Convert.ToInt32(item.Sort);
                                b = Convert.ToInt32(list[index - 2].Sort);
                                c = a;
                                a = b;
                                b = c;
                                item.Sort = a;
                                db.Updateable(item).ExecuteCommand();
                                var nitem = list[index - 2];
                                nitem.Sort = b;
                                db.Updateable(nitem).ExecuteCommand();
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (item.ID == i) //判断是否是头如果上升则不做处理
                        {
                            if (o == 1) //下降一位
                            {
                                a = Convert.ToInt32(item.Sort);
                                b = Convert.ToInt32(list[index].Sort);
                                c = a;
                                a = b;
                                b = c;
                                item.Sort = a;
                                db.Updateable(item).ExecuteCommand();
                                var nitem = list[index];
                                nitem.Sort = b;
                                db.Updateable(nitem).ExecuteCommand();
                                break;
                            }
                            else
                            {
                                a = Convert.ToInt32(item.Sort);
                                b = Convert.ToInt32(list[index - 2].Sort);
                                c = a;
                                a = b;
                                b = c;
                                item.Sort = a;
                                db.Updateable(item).ExecuteCommand();
                                var nitem = list[index - 2];
                                nitem.Sort = b;
                                db.Updateable(nitem).ExecuteCommand();
                                break;
                            }
                        }
                    }
                }
            }
        }


        /// 反向递归模块集合，可重复模块数据，最后去重
        /// <param name="prevModule">总模块</param>
        /// <param name="retmodule">返回模块</param>
        /// <param name="parentId">上级ID</param>
        private void RecursiveModule(List<sysmenu> prevModule, List<sysmenu> retmodule, int? parentId)
        {
            var result = prevModule.Where(p => p.ID == parentId);
            foreach (var item in result)
            {
                retmodule.Add(item);
                RecursiveModule(prevModule, retmodule, item.ParentId);
            }
        }

        /// <summary>
        /// 递归模块列表，返回按级别排序
        /// </summary>
        public List<sysmenu> RecursiveModule(List<sysmenu> list)
        {
            var result = new List<sysmenu>();
            if (list != null && list.Count > 0)
            {
                ChildModule(list, result, 0);
            }
            return result;
        }
        /// <summary>
        /// 递归模块列表
        /// </summary>
        private void ChildModule(List<sysmenu> list, List<sysmenu> newlist, int parentId)
        {
            var result = list.Where(p => p.ParentId == parentId).OrderBy(p => p.ClassLayer).ThenBy(p => p.Sort).ToList();
            if (!result.Any()) return;
            for (int i = 0; i < result.Count(); i++)
            {
                newlist.Add(result[i]);
                ChildModule(list, newlist, result[i].ID);
            }
        }
        /// <summary>
        /// 模型去重，非常重要
        /// </summary>
        public class ModuleDistinct : IEqualityComparer<sysmenu>
        {
            public bool Equals(sysmenu x, sysmenu y)
            {
                return x.ID == y.ID;
            }

            public int GetHashCode(sysmenu obj)
            {
                return obj.ToString().GetHashCode();
            }
        }
    }
}