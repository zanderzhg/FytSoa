using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FytSoa.Common
{
    public class PageData
    {
        public PageData()
        {
            //this.Items = new IQueryable<T>();
        }
        /// <summary>
        /// 共有多少条
        /// </summary>
        public int TotalNum { get; set; }
        /*/// <summary>
        /// 返回集合
        /// </summary>
        public List<T> Items { get; set; }*/
        /// <summary>
        /// 当前在第几页
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 当前每页多少条
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前路径
        /// </summary>
        public string Urls { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPageCount { get; set; }

        /// <summary>
        /// 自定义参数
        /// </summary>
        public string CurrentParem { get; set; }
    }
}
