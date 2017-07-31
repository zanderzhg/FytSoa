using System;
using System.Linq;
using System.Text;

namespace FytSoa.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class sysroles
    {
           public sysroles(){


           }
           /// <summary>
           /// Desc:自动增长
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ID {get;set;}

           /// <summary>
           /// Desc:部门ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int DepID {get;set;}

           /// <summary>
           /// Desc:角色名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RoleName {get;set;}

           /// <summary>
           /// Desc:角色编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RoleCode {get;set;}

           /// <summary>
           /// Desc:是否系统管理员
           /// Default:b'1'
           /// Nullable:False
           /// </summary>           
           public bool IsSystemSet {get;set;}

           /// <summary>
           /// Desc:描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Summary {get;set;}

           /// <summary>
           /// Desc:创建人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CreateUser {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CreateDate {get;set;}

    }
}
