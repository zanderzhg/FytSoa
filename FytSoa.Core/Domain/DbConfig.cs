using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FytSoa.Common;
using SqlSugar;
using SyntacticSugar;
namespace FytSoa.Core
{
    public class DbConfig
    {
        public static SqlSugarClient GetDbInstance()
        {
            try
            {
                SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = ConfigHelper.GetConfigString(KeyHelper.DATABASE_STR), //必填
                    DbType = DbType.MySql, //必填
                    IsAutoCloseConnection = true, //默认false
                    InitKeyType = InitKeyType.SystemTable
                });
                return db;
            }
            catch (Exception ex)
            {
                throw new Exception("连接数据库出错，请检查您的连接字符串，和网络。 ex:".AppendString(ex.Message));
            }
        }
    }
}