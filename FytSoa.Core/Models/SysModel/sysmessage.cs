using System;
using System.Linq;
using System.Text;

namespace FytSoa.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class sysmessage
    {
           public sysmessage(){


           }
           /// <summary>
           /// Desc:自动标识
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ID {get;set;}

           /// <summary>
           /// Desc:栏目ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ClassID {get;set;}

           /// <summary>
           /// Desc:类型
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Types {get;set;}

           /// <summary>
           /// Desc:标题
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Title {get;set;}

           /// <summary>
           /// Desc:电话号码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Mobile {get;set;}

           /// <summary>
           /// Desc:联系邮箱
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Email {get;set;}

           /// <summary>
           /// Desc:QQ
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string QQ {get;set;}

           /// <summary>
           /// Desc:是否查看
           /// Default:b'0'
           /// Nullable:False
           /// </summary>           
           public bool Status {get;set;}

           /// <summary>
           /// Desc:描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Summary {get;set;}

           /// <summary>
           /// Desc:内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Content {get;set;}

           /// <summary>
           /// Desc:用户ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int UserId {get;set;}

           /// <summary>
           /// Desc:用户名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:父ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ParentId {get;set;}

           /// <summary>
           /// Desc:回复ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int RepId {get;set;}

           /// <summary>
           /// Desc:添加时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? AddDate {get;set;}

           /// <summary>
           /// Desc:回复时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RepDate {get;set;}

    }
}
