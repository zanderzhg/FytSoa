using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FytSoa.Common;
using FytSoa.Common.Log;
using FytSoa.Model;
using RestSharp;
using SqlSugar;
using SyntacticSugar;

namespace FytSoa.Core
{
    public class RestApi<T> where T : class, new()
    {
        public T Get(string url, object pars)
        {
            var type = Method.GET;
            IRestResponse<T> reval = GetApiInfo(url, pars, type);
            return reval.Data;
        }
        public T Post(string url, object pars)
        {
            var type = Method.POST;
            IRestResponse<T> reval = GetApiInfo(url, pars, type);
            return reval.Data;
        }
        public T Delete(string url, object pars)
        {
            var type = Method.DELETE;
            IRestResponse<T> reval = GetApiInfo(url, pars, type);
            return reval.Data;
        }
        public T Put(string url, object pars)
        {
            var type = Method.PUT;
            IRestResponse<T> reval = GetApiInfo(url, pars, type);
            return reval.Data;
        }

        private static IRestResponse<T> GetApiInfo(string url, object pars, Method type)
        {
            var request = new RestRequest(type);
            if (pars != null)
                request.AddObject(pars);
            var cm = SyntacticSugar.CacheManager<UserInfo>.GetInstance();
            string uniqueKey = PubGet.GetUserKey;
            if (cm.ContainsKey(uniqueKey)) {
                request.AddCookie(KeyHelper.UserUniqueKey, CookiesManager<string>.GetInstance()[KeyHelper.UserUniqueKey]);
            }
            var client =
                new RestClient(RequestInfo.HttpDomain + url) {CookieContainer = new System.Net.CookieContainer()};
            IRestResponse<T> reval = client.Execute<T>(request);
            if (reval.ErrorException == null) return reval;
            LogProvider.Error("数据库", new Exception(reval.Content).Message);
            throw new Exception("请求出错");
        }
    }
}