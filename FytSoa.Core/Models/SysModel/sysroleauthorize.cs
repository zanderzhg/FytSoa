using System;
using System.Linq;
using System.Text;

namespace FytSoa.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class sysroleauthorize
    {
           public sysroleauthorize(){


           }
           /// <summary>
           /// Desc:自动增长
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
           /// Desc:授权ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int AuthorizeID {get;set;}

    }
}
