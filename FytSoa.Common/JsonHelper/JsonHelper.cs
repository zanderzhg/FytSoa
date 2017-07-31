using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FytSoa.Common
{
    public class ResultJson
    {
        #region Property

        /// <summary>
        /// 数据状态
        /// </summary>
        public int status { get; set; } = 200;
        /// <summary>
        /// 提示信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 回传URL
        /// </summary>
        public string backurl { get; set; }
        /// <summary>
        /// 数据包
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// 数据包A
        /// </summary>
        public object dataa { get; set; }
        /// <summary>
        /// 数据包B
        /// </summary>
        public object datab { get; set; }
        /// <summary>
        /// 数据包C
        /// </summary>
        public object datac { get; set; }
        /// <summary>
        /// 数据包C
        /// </summary>
        public object datad { get; set; }
        /// <summary>
        /// 数据包C
        /// </summary>
        public object datae { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int rows { get; set; } = 0;

        /// <summary>
        /// 当前第几页
        /// </summary>
        public int index { get; set; } = 0;

        /// <summary>
        /// 总页数
        /// </summary>
        public int total { get; set; } = 0;

        #endregion
    }

    /// <summary>
    /// 文件模型
    /// </summary>
    public class FileModel
    {
        public string name { get; set; }
        public string ext { get; set; }
        public long size { get; set; }
        public DateTime time { get; set; }
    }

    public class ArrayFiles
    {
        public int id { get; set; }
        public int pId { get; set; }
        public string name { get; set; }
        public Boolean open { get; set; }
        public string target { get; set; }
        public string url { get; set; }
    }
    public class JsonFile
    {
        /// <summary>
        /// 消息说明
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 状态，可自定义
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 原图
        /// </summary>
        public string imgUrl { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string thumImg { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object data { get; set; }
    }
}
