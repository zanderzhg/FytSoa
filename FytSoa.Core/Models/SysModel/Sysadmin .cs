using ProtoBuf;
using System;

namespace FytSoa.Models
{
    [ProtoContract]
    public class sysadmin 
    {

        /// <summary>
        /// Desc:-
        /// Default:-
        /// Nullable:False
        /// </summary>
        [ProtoMember(1)]
        public int ID {get;set;}

        /// <summary>
        /// Desc:角色ID
        /// Default:0
        /// Nullable:False
        /// </summary>
        [ProtoMember(2)]
        public int RoleID {get;set;}

        /// <summary>
        /// Desc:部门ID
        /// Default:0
        /// Nullable:False
        /// </summary>
        [ProtoMember(3)]
        public int DepID {get;set;}

        /// <summary>
        /// Desc:登录账号
        /// Default:-
        /// Nullable:False
        /// </summary>
        [ProtoMember(4)]
        public string LoginName {get;set;}

        /// <summary>
        /// Desc:密码
        /// Default:-
        /// Nullable:False
        /// </summary>
        [ProtoMember(5)]
        public string LoginPwd {get;set;}

        /// <summary>
        /// Desc:真实姓名
        /// Default:-
        /// Nullable:True
        /// </summary>
        [ProtoMember(6)]
        public string RealName {get;set;}

        /// <summary>
        /// Desc:工号
        /// Default:-
        /// Nullable:True
        /// </summary>
        [ProtoMember(7)]
        public string Number {get;set;}

        /// <summary>
        /// Desc:头像
        /// Default:-
        /// Nullable:True
        /// </summary>
        public string HeadPic {get;set;}

        /// <summary>
        /// Desc:性别
        /// Default:-
        /// Nullable:True
        /// </summary>
        [ProtoMember(8)]
        public string Sex {get;set;}

        /// <summary>
        /// Desc:手机号码
        /// Default:-
        /// Nullable:True
        /// </summary>
        [ProtoMember(9)]
        public string Mobile {get;set;}

        /// <summary>
        /// Desc:状态
        /// Default:b'1'
        /// Nullable:True
        /// </summary>
        [ProtoMember(10)]
        public bool Status {get;set;}

        /// <summary>
        /// Desc:邮箱
        /// Default:-
        /// Nullable:True
        /// </summary>
        public string Email {get;set;}

        /// <summary>
        /// Desc:备注
        /// Default:-
        /// Nullable:True
        /// </summary>
        [ProtoMember(11)]
        public string Summary {get;set;}

        /// <summary>
        /// Desc:添加时间
        /// Default:-
        /// Nullable:True
        /// </summary>
        [ProtoMember(12)]
        public DateTime? AddDate {get;set;}

        /// <summary>
        /// Desc:添加人
        /// Default:-
        /// Nullable:True
        /// </summary>
        [ProtoMember(13)]
        public string AddUser {get;set;}

    }
}
