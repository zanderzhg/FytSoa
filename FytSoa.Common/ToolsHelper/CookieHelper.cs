using System;
using System.Globalization;
using System.Web;

namespace FytSoa.Common
{
    /// <summary>
    /// Cookie辅助类
    /// </summary>
    public class CookieHelper
    {
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName] ?? new HttpCookie(strName);
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="key"></param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName] ?? new HttpCookie(strName);
            cookie[key] = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="expires">过期时间(分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName] ?? new HttpCookie(strName);
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            return HttpContext.Current.Request.Cookies[strName] != null ? HttpContext.Current.Request.Cookies[strName].Value.ToString(CultureInfo.InvariantCulture) : "";
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="key">cooke关键字</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName, string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
                return HttpContext.Current.Request.Cookies[strName][key].ToString(CultureInfo.InvariantCulture);

            return "";
        }

        /// <summary>
        /// 清除指定Cookie
        /// </summary>
        /// <param name="cookiename">cookiename</param>
        public static void ClearCookie(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-14400);
                HttpContext.Current.Response.Cookies.Remove(cookiename);
                HttpContext.Current.Response.AppendCookie(cookie);
            }
        }
        /// <summary>
        /// 添加一个Cookie
        /// 增加域的表示，需要在配置文件中配置下网站地址SiteUrl
        /// </summary>
        /// <param name="cookiename">cookie名</param>
        /// <param name="cookievalue">cookie值</param>
        /// <param name="expires">过期时间 null为浏览器过期</param>
        public static void SetCookie(string cookiename, string cookievalue, int? expires)
        {
            var cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookiename) {Value = cookievalue};
                var siteurl = System.Configuration.ConfigurationManager.AppSettings["SiteUrl"];
                if (!string.IsNullOrEmpty(siteurl))
                {
                    cookie.Domain = siteurl.Replace("www.", "");
                }
                if (expires != null && expires > 0) { cookie.Expires = DateTime.Now.AddDays(Convert.ToInt32(expires)); }
                HttpContext.Current.Response.AppendCookie(cookie);
            }
            else
            {
                HttpContext.Current.Response.SetCookie(cookie);
            }
        }
    }
}
