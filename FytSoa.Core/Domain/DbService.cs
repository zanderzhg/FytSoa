using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FytSoa.Common.Log;
using SqlSugar;
using SyntacticSugar;

namespace FytSoa.Core
{
    /// <summary>
    ///数据访问层
    /// </summary>
    public class DbService : IDisposable
    {
        private readonly SqlSugarClient _db;
        public DbService()
        {
            _db = DbConfig.GetDbInstance();
        }

        /// <summary>
        /// 服务命令
        /// </summary>
        /// <typeparam name="TOutsourcing">外包对象</typeparam>
        /// <param name="func"></param>
        public void Command<TOutsourcing>(Action<TOutsourcing> func) where TOutsourcing : class, new() 
        {
            try
            {
                var o = new TOutsourcing();
                func(o);
                o = null;//及时释放对象 
                //_db 会在http请求结束前执行 dispose 
            }
            catch (Exception ex)
            {
                //在这里可以处理所有controller的异常
                //获错误写入日志
                WriteExMessage(ex);
                throw;
            }
        }

        /// <summary>
        /// 服务命令
        /// </summary>
        /// <typeparam name="TOutsourcing">外包对象</typeparam>
        /// <typeparam name="TApi">接口</typeparam>
        /// <param name="func"></param>
        public void Command<TOutsourcing, TApi>(Action<TOutsourcing, RestApi<TApi>> func) where TOutsourcing : class, new() where TApi : class, new()
        {
            try
            {
                var o = new TOutsourcing();
                var api = new RestApi<TApi>();
                func(o, api);
                o = null;//及时释放对象 
                //_db 会在http请求结束前执行 dispose 
            }
            catch (Exception ex)
            {
                //在这里可以处理所有controller的异常
                //获错误写入日志
                WriteExMessage(ex);
                throw;
            }
        }

        /// <summary>
        /// 服务命令
        /// </summary>
        /// <typeparam name="TOutsourcing">外包对象</typeparam>
        /// <param name="func"></param>
        public void Command<TOutsourcing>(Action<SqlSugarClient, TOutsourcing> func) where TOutsourcing : class, new() 
        {
            try
            {
                var o = new TOutsourcing();
                func(_db, o);
                o = null;//及时释放对象 
                //_db 会在http请求结束前执行 dispose 
            }
            catch (Exception ex)
            {
                //在这里可以处理所有controller的异常
                //获错误写入日志
                WriteExMessage(ex);
                throw;
            }
        }

        /// <summary>
        /// 服务命令
        /// </summary>
        /// <typeparam name="TOutsourcing">外包对象</typeparam>
        /// <typeparam name="TApi">接口</typeparam>
        /// <param name="func"></param>
        public void Command<TOutsourcing, TApi>(Action<SqlSugarClient, TOutsourcing, RestApi<TApi>> func) where TOutsourcing : class, new() where TApi : class, new()
        {
            try
            {
                var o = new TOutsourcing();
                var api = new RestApi<TApi>();
                func(_db, o, api);
                o = null;//及时释放对象 
                //_db 会在http请求结束前执行 dispose 
            }
            catch (Exception ex)
            {
                //在这里可以处理所有controller的异常
                //获错误写入日志
                WriteExMessage(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 将错误信息写入日志
        /// </summary>
        /// <param name="ex"></param>
        private static void WriteExMessage(Exception ex)
        {
            LogProvider.Error("数据库",ex.Message);
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}