using System;
using System.Linq;
using System.Text;

namespace FytSoa.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class sysbranch
    {
           public sysbranch(){


           }
           /// <summary>
           /// Desc:自动增长
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ID {get;set;}

           /// <summary>
           /// Desc:分公司负责人
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int UserID {get;set;}

           /// <summary>
           /// Desc:系统ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int SysID {get;set;}

           /// <summary>
           /// Desc:分公司上级
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Pid {get;set;}

           /// <summary>
           /// Desc:等级
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Grade {get;set;}

           /// <summary>
           /// Desc:分公司名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Name {get;set;}

           /// <summary>
           /// Desc:分公司编号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Code {get;set;}

           /// <summary>
           /// Desc:分公司电话
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Tel {get;set;}

           /// <summary>
           /// Desc:分公司传真
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Fax {get;set;}

           /// <summary>
           /// Desc:分公司地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Address {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Summary {get;set;}

    }
}
