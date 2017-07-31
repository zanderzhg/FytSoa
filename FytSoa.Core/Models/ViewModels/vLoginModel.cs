using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FytSoa.Core.Models
{
    /// <summary>
    /// 登录
    /// </summary>
    public class vLoginModel
    {
        public string loginname { get; set; }
        public string password { get; set; }
        public string code { get; set; }
    }
}
