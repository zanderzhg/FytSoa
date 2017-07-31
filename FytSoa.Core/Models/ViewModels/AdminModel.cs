using ProtoBuf;
using System.Collections.Generic;

namespace FytSoa.Models
{
    /// <summary>
    /// Describe：管理员信息 ViewModel
    /// </summary>
    [ProtoContract]
    public class AdminModel
    {
        /// <summary>
        ///  管理员ID
        /// </summary>
        [ProtoMember(1)]
        public int ID { get; set; }

        /// <summary>
        ///  是否为超级管理员
        /// </summary>
        [ProtoMember(2)]
        public bool IsSuper { get; set; }

        /// <summary>
        /// 管理员模型
        /// </summary>
        [ProtoMember(3)]
        public sysadmin sysadmin { get; set; }
        /// <summary>
        ///  用户可操作的模块集合
        /// </summary>
        [ProtoMember(4)]
        public List<sysmenu> sysMenu { get; set; }

    }
}
