using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FytSoa.Common.Log
{
    /// <summary>
    /// 日志
    /// </summary>
    public class LogProvider
    {
        #region Member

        /// <summary>
        /// 日志文件的物理路径
        /// </summary>
        private static readonly string File= HttpContext.Current.Server.MapPath("~/Logs/");

        /// <summary>
        /// 为保持互斥线程安全。
        /// </summary>
        private static readonly object Mutex = new object();


        #endregion

        /// <summary>
        /// Logs an error to the log file.
        /// </summary>
        /// <param name="origin">The origin of the error</param>
        /// <param name="message">The message</param>
        /// <param name="details">Optional error details</param>
        public static void Error(string origin, string message, Exception details = null)
        {
            lock (Mutex)
            {
                var path = File + DateTime.Now.ToString("yyyyMM");
                if (!FileHelper.IsExistDirectory(path))
                {
                    FileHelper.CreateFolder(path);
                }
                FileStream fs = new FileStream(path + "/log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", FileMode.Append);
                using (var writer = new StreamWriter(fs))
                {
                    writer.WriteLine($"***********{0}***********", "Begin");
                    writer.WriteLine(
                        $"ERROR [{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Origin [{origin}] Message [{message}]");
                    writer.WriteLine($"***********{0}***********\r\n\r\n", "End");
                    if (details != null)
                        writer.WriteLine(details.Message);
                }
                fs.Dispose();
            }
        }
    }
}
