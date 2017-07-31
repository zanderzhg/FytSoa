using System;
using System.Linq;
using System.Text;

namespace FytSoa.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class sysadvclass
    {
           public sysadvclass(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ID {get;set;}

           /// <summary>
           /// Desc:父ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ParentID {get;set;}

           /// <summary>
           /// Desc:栏位名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Title {get;set;}

           /// <summary>
           /// Desc:栏位类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Flag {get;set;}

           /// <summary>
           /// Desc:宽度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Width {get;set;}

           /// <summary>
           /// Desc:高度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Height {get;set;}

           /// <summary>
           /// Desc:说明
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Summary {get;set;}

           /// <summary>
           /// Desc:状态
           /// Default:b'1'
           /// Nullable:False
           /// </summary>           
           public bool Status {get;set;}

           /// <summary>
           /// Desc:站点ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int SiteID {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UpdateDate {get;set;}

    }
}
