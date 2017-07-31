using System;
using System.Linq;
using System.Text;

namespace FytSoa.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class syssite
    {
           public syssite(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ID {get;set;}

           /// <summary>
           /// Desc:系统ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int SysId {get;set;}

           /// <summary>
           /// Desc:网站名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string SiteName {get;set;}

           /// <summary>
           /// Desc:网站域名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SiteUrl {get;set;}

           /// <summary>
           /// Desc:网站Logo
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SiteLogo {get;set;}

           /// <summary>
           /// Desc:网站描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Summary {get;set;}

           /// <summary>
           /// Desc:公司电话
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SiteTel {get;set;}

           /// <summary>
           /// Desc:公司传真
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SiteFax {get;set;}

           /// <summary>
           /// Desc:公司人事邮箱
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SiteEmail {get;set;}

           /// <summary>
           /// Desc:公司客服QQ
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string QQ {get;set;}

           /// <summary>
           /// Desc:微信公众号图片
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WeiXin {get;set;}

           /// <summary>
           /// Desc:微博链接地址或者二维码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WeiBo {get;set;}

           /// <summary>
           /// Desc:公司地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SiteAddress {get;set;}

           /// <summary>
           /// Desc:网站备案号其它等信息
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SiteCode {get;set;}

           /// <summary>
           /// Desc:网站SEO标题
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SeoTitle {get;set;}

           /// <summary>
           /// Desc:网站SEO关键字
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SeoKey {get;set;}

           /// <summary>
           /// Desc:网站SEO描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SeoDescribe {get;set;}

           /// <summary>
           /// Desc:网站版权等信息
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SiteCopyright {get;set;}

           /// <summary>
           /// Desc:网站开启关闭状态
           /// Default:b'1'
           /// Nullable:True
           /// </summary>           
           public bool? Status {get;set;}

           /// <summary>
           /// Desc:如果状态关闭，请输入关闭网站原因
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CloseInfo {get;set;}

    }
}
