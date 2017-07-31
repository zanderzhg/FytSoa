using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FytSoa.Common;
using FytSoa.Common.EnumsHelper;
using FytSoa.Common.Log;
using FytSoa.Core.Models;
using FytSoa.Models;
using SqlSugar;

namespace FytSoa.Areas.FytAdmin.Controllers
{
    public class LoginOutsourcing
    {
        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="db"></param>
        /// <param name="lmodel"></param>
        /// <returns></returns>
        public ResultJson Logins(SqlSugarClient db,vLoginModel lmodel)
        {
            var json = new ResultJson(){  backurl = "/fytadmin/index/"  };
            var model = db.Queryable<sysadmin>().Single(m => m.LoginName == lmodel.loginname);
            if (model != null)
            {
                LogProvider.Error(LoggerEnums.Info.ToString(), DES3Encrypt.EncryptString(lmodel.password));
                if (model.LoginPwd.Equals(DES3Encrypt.EncryptString(lmodel.password)))
                {
                    //判断是否冻结
                    if (model.Status)
                    {
                        json.data = model;
                        //根据管理员的角色ID查询菜单，目前支持模块化权限验证
                        var roleModel = db.Queryable<sysrolemenu>().Where(m => m.RoleID == model.RoleID).ToList();
                        var mlist = roleModel.Select(item => item.MenuID).ToList();
                        //根据角色关联的菜单ID，查询菜单集合
                        var menuList = db.Queryable<sysmenu>().Where(m => mlist.Contains(m.ID)).ToList();
                        var adminModel=new AdminModel()
                        {
                            ID = model.ID,sysadmin = model,sysMenu = menuList
                        };
                        //将用户登录信息保存的session中
                        SessionHelper.SetSession(KeyHelper.SESSION_ADMIN_INFO, ProtobufHelper.Serialize(adminModel));
                        //将登录ID保存到cookie中
                        CookieHelper.SetCookie(KeyHelper.COOKIE_ADMIN_USERID, DES3Encrypt.EncryptString(model.ID.ToString()),1);
                    }
                    else
                    {
                        json.status = 403;
                        json.msg = "您的账号被冻结，请联系管理员~";
                    }
                }
                else
                {
                    json.status = 402;
                    json.msg = "密码错误~";
                }
            }
            else
            {
                json.status = 401;
                json.msg = "用户名错误~";
            }
            return json;
        }
    }
}