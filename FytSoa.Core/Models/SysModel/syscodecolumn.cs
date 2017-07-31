using System;
using System.Linq;
using System.Text;

namespace FytSoa.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class syscodecolumn
    {
           public syscodecolumn(){


           }
           /// <summary>
           /// Desc:自动增长
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ID {get;set;}

           /// <summary>
           /// Desc:父ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ParentId {get;set;}

           /// <summary>
           /// Desc:排序深度
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ClassLayer {get;set;}

           /// <summary>
           /// Desc:字典标题
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Title {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Sort {get;set;}

           /// <summary>
           /// Desc:添加时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime AddDate {get;set;}

    }
}
