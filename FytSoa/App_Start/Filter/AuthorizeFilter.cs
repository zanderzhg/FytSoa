using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FytSoa.Common;

namespace FytSoa
{
    public class AuthorizeFilter : AuthorizeAttribute
    {
        /// <summary>
        /// 全局过滤器
        /// 过滤域名的集合，可多个
        /// </summary>
        private readonly List<string> _sAreas = new List<string>() {
            "FytAdmin","ShopAdmin","MemAdmin"
        };
        public AuthorizeFilter()
        {
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var area = filterContext.RouteData.DataTokens["area"];
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            // 判断控制器是否贴 SkipLoginAttribute 特性
            if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(SkipLoginAttribute), false))
            {
                return;
            }

            // 判断Action是否贴 SkipLoginAttribute 特性
            if (filterContext.ActionDescriptor.IsDefined(typeof(SkipLoginAttribute), false))
            {
                return;
            }
            // 判断是否是区域
            if (area != null && _sAreas.Any(u => u.ToLower() == area.ToString().ToLower()))
            {
                // 核心方法：
                if (!IsAdminLogin())
                {
                    filterContext.HttpContext.Response.Redirect("/fytadmin/login/");
                    filterContext.Result = new EmptyResult();
                }
            }
        }

        /// <summary>
        /// 判断管理员是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsAdminLogin()
        {
            var uobj = SessionHelper.GetSession(KeyHelper.SESSION_ADMIN_INFO) as byte[];
            return uobj != null && uobj.Length > 0;
        }

    }
}
