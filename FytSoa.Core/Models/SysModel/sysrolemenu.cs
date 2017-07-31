using System;
using System.Linq;
using System.Text;

namespace FytSoa.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class sysrolemenu
    {
           public sysrolemenu(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ID {get;set;}

           /// <summary>
           /// Desc:角色ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int RoleID {get;set;}

           /// <summary>
           /// Desc:菜单ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int MenuID {get;set;}

    }
}
