using System;
using ProtoBuf;

namespace FytSoa.Models
{
    ///<summary>
    /// 系统菜单
    ///</summary>
    [ProtoContract]
    public partial class sysmenu
    {
           public sysmenu(){


           }
        /// <summary>
        /// Desc:自动增长
        /// Default:
        /// Nullable:False
        /// </summary>    
        [ProtoMember(1)]
        public int ID {get;set;}

        /// <summary>
        /// Desc:系统ID
        /// Default:0
        /// Nullable:False
        /// </summary>         
        [ProtoMember(2)]
        public int SysID {get;set;}

        /// <summary>
        /// Desc:菜单父ID
        /// Default:0
        /// Nullable:False
        /// </summary>     
        [ProtoMember(3)]
        public int ParentId {get;set;}

        /// <summary>
        /// Desc:菜单名称
        /// Default:
        /// Nullable:False
        /// </summary>   
        [ProtoMember(4)]
        public string Name {get;set;}

        /// <summary>
        /// Desc:菜单标记
        /// Default:
        /// Nullable:True
        /// </summary>    
        [ProtoMember(5)]
        public string Code {get;set;}

        /// <summary>
        /// Desc:ID集合
        /// Default:
        /// Nullable:True
        /// </summary>  
        [ProtoMember(6)]
        public string ClassList {get;set;}

        /// <summary>
        /// Desc:深度
        /// Default:0
        /// Nullable:False
        /// </summary>    
        [ProtoMember(7)]
        public int ClassLayer {get;set;}

        /// <summary>
        /// Desc:链接地址
        /// Default:
        /// Nullable:False
        /// </summary>     
        [ProtoMember(8)]
        public string Urls {get;set;}

        /// <summary>
        /// Desc:控制器名称
        /// Default:
        /// Nullable:True
        /// </summary>       
        [ProtoMember(9)]
        public string ControllerName {get;set;}

        /// <summary>
        /// Desc:方法名称
        /// Default:
        /// Nullable:True
        /// </summary>    
        [ProtoMember(10)]
        public string ActionName {get;set;}

        /// <summary>
        /// Desc:图标
        /// Default:
        /// Nullable:True
        /// </summary>   
        [ProtoMember(11)]
        public string Icon {get;set;}

        /// <summary>
        /// Desc:排序
        /// Default:0
        /// Nullable:False
        /// </summary>   
        [ProtoMember(12)]
        public int Sort {get;set;}

        /// <summary>
        /// Desc:是否显示
        /// Default:b'1'
        /// Nullable:False
        /// </summary>  
        [ProtoMember(13)]
        public bool IsShow {get;set;}

        /// <summary>
        /// Desc:修改时间
        /// Default:
        /// Nullable:True
        /// </summary>  
        [ProtoMember(14)]
        public DateTime? UpdateDate {get;set;}

    }
}
