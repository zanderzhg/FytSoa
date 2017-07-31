using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FytSoa.Common.EnumsHelper
{
    /// <summary>
    /// 数据库表日志枚举 
    /// </summary>
    public enum SysLogEnums
    {
        [Description("用户登录日志")]
        Login = 1,
        [Description("内容操作日志")]
        Content = 2,
        [Description("菜单操作日志")]
        Menu = 3,
        [Description("模板管理日志")]
        Temp = 4,
        [Description("组件管理日志")]
        Assembly = 5,
        [Description("数据库管理日志")]
        DataBase = 6
    }

    /// <summary>
    /// 本地日志枚举 INFO=普通  WARN=警告  ERROR=错误  FATAL=异常
    /// </summary>
    public enum LoggerEnums
    {
        [Description("普通")]
        Info,
        [Description("警告")]
        Warn,
        [Description("错误")]
        Error,
        [Description("异常")]
        Fatal
    }
}
