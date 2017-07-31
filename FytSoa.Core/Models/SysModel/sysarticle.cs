using System;
using System.Linq;
using System.Text;

namespace FytSoa.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class sysarticle
    {
           public sysarticle(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string GUID {get;set;}

           /// <summary>
           /// Desc:栏目ID
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ClassID {get;set;}

           /// <summary>
           /// Desc:0=新闻1=多图片
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Types {get;set;}

           /// <summary>
           /// Desc:文章标题
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Title {get;set;}

           /// <summary>
           /// Desc:文章标题颜色
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TitleColor {get;set;}

           /// <summary>
           /// Desc:文章副标题
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SubTitle {get;set;}

           /// <summary>
           /// Desc:作者
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Author {get;set;}

           /// <summary>
           /// Desc:来源
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Source {get;set;}

           /// <summary>
           /// Desc:是否外链
           /// Default:b'0'
           /// Nullable:False
           /// </summary>           
           public bool IsLink {get;set;}

           /// <summary>
           /// Desc:外部链接地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LinkUrl {get;set;}

           /// <summary>
           /// Desc:文章标签
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Tag {get;set;}

           /// <summary>
           /// Desc:文章宣传图
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ImgUrl {get;set;}

           /// <summary>
           /// Desc:文章缩略图
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ThumImg {get;set;}

           /// <summary>
           /// Desc:视频链接地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string VideoUrl {get;set;}

           /// <summary>
           /// Desc:是否置顶
           /// Default:b'0'
           /// Nullable:False
           /// </summary>           
           public bool IsTop {get;set;}

           /// <summary>
           /// Desc:是否热点
           /// Default:b'0'
           /// Nullable:False
           /// </summary>           
           public bool IsHot {get;set;}

           /// <summary>
           /// Desc:是否滚动
           /// Default:b'0'
           /// Nullable:False
           /// </summary>           
           public bool IsScroll {get;set;}

           /// <summary>
           /// Desc:是否幻灯
           /// Default:b'0'
           /// Nullable:False
           /// </summary>           
           public bool IsSlide {get;set;}

           /// <summary>
           /// Desc:是否允许评论
           /// Default:b'0'
           /// Nullable:False
           /// </summary>           
           public bool IsComment {get;set;}

           /// <summary>
           /// Desc:是否手机站显示
           /// Default:b'0'
           /// Nullable:False
           /// </summary>           
           public bool IsWap {get;set;}

           /// <summary>
           /// Desc:是否在回收站
           /// Default:b'0'
           /// Nullable:False
           /// </summary>           
           public bool IsRecyc {get;set;}

           /// <summary>
           /// Desc:审核状态
           /// Default:b'1'
           /// Nullable:False
           /// </summary>           
           public bool Audit {get;set;}

           /// <summary>
           /// Desc:文章摘要
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Summary {get;set;}

           /// <summary>
           /// Desc:文章内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Content {get;set;}

           /// <summary>
           /// Desc:点击量
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Hits {get;set;}

           /// <summary>
           /// Desc:当日点击量
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int DayHits {get;set;}

           /// <summary>
           /// Desc:星期点击量
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int WeedHits {get;set;}

           /// <summary>
           /// Desc:月点击量
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int MonthHits {get;set;}

           /// <summary>
           /// Desc:最后点击时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? LastHitDate {get;set;}

           /// <summary>
           /// Desc:编辑时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? EditDate {get;set;}

           /// <summary>
           /// Desc:添加时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? AddDate {get;set;}

           /// <summary>
           /// Desc:删除到回收站时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? DelDate {get;set;}

    }
}
