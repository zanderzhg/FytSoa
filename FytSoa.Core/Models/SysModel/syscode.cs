using System;
using System.Linq;
using System.Text;

namespace FytSoa.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class syscode
    {
           public syscode(){


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
           /// Desc:字典类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CodeType {get;set;}

           /// <summary>
           /// Desc:字典名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Name {get;set;}

           /// <summary>
           /// Desc:字典代码值
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CodeValue {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Sort {get;set;}

           /// <summary>
           /// Desc:是否启用
           /// Default:b'1'
           /// Nullable:False
           /// </summary>           
           public bool Status {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Summary {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? AddDate {get;set;}

    }
}
