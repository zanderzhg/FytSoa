using System;
using System.Linq;
using System.Text;

namespace FytSoa.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class syslog
    {
           public syslog(){


           }
           /// <summary>
           /// Desc:自动递增
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ID {get;set;}

           /// <summary>
           /// Desc:操作人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:日志内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Title {get;set;}

           /// <summary>
           /// Desc:IP地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IP {get;set;}

           /// <summary>
           /// Desc:日志类型
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int LogType {get;set;}

           /// <summary>
           /// Desc:日志级别
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string LogGrade {get;set;}

           /// <summary>
           /// Desc:请求地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RequestUrl {get;set;}

           /// <summary>
           /// Desc:添加时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? AddDate {get;set;}

    }
}
