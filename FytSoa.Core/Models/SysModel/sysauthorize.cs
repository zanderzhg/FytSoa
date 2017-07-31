using System;
using System.Linq;
using System.Text;

namespace FytSoa.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class sysauthorize
    {
           public sysauthorize(){


           }
           /// <summary>
           /// Desc:自动增长
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ID {get;set;}

           /// <summary>
           /// Desc:菜单ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int MenuID {get;set;}

           /// <summary>
           /// Desc:菜单名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Name {get;set;}

           /// <summary>
           /// Desc:代码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Code {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int Sort {get;set;}

    }
}
