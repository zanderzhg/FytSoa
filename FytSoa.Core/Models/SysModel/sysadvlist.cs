using System;
using System.Linq;
using System.Text;

namespace FytSoa.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class sysadvlist
    {
           public sysadvlist(){


           }
           /// <summary>
           /// Desc:
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
           /// Desc:广告位名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Title {get;set;}

           /// <summary>
           /// Desc:广告位类型
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Types {get;set;}

           /// <summary>
           /// Desc:是否启用
           /// Default:b'1'
           /// Nullable:False
           /// </summary>           
           public bool Status {get;set;}

           /// <summary>
           /// Desc:图片地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ImgUrl {get;set;}

           /// <summary>
           /// Desc:链接地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LinkUrl {get;set;}

           /// <summary>
           /// Desc:链接描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LinkSummary {get;set;}

           /// <summary>
           /// Desc:打开窗口类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Target {get;set;}

           /// <summary>
           /// Desc:广告位说明
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string AdvCode {get;set;}

           /// <summary>
           /// Desc:是否启用时间显示
           /// Default:b'0'
           /// Nullable:False
           /// </summary>           
           public bool IsTimeLimit {get;set;}

           /// <summary>
           /// Desc:开始时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? BeginTime {get;set;}

           /// <summary>
           /// Desc:结束时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? EndTime {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Sort {get;set;}

           /// <summary>
           /// Desc:点击量
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Hits {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UpdateDate {get;set;}

           /// <summary>
           /// Desc:广告位说明
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Summary {get;set;}

    }
}
