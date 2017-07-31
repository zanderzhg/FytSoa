using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FytSoa.Core;

namespace FytSoa.Common
{
    public class SMSHelper
    {
        private static SysBasicConfig _sysconfig;
        public SMSHelper()
        {
            _sysconfig = LoadConfig(Utils.GetXmlMapPath(KeyHelper.FILE_SITE_XML_CONFING));
        }
        /// <summary>
        ///  读取站点配置文件
        /// </summary>
        private SysBasicConfig LoadConfig(string configFilePath)
        {
            return (SysBasicConfig)SerializationHelper.Load(typeof(SysBasicConfig), configFilePath);
        }

        public static string PostUrl = "http://121.199.16.178/webservice/sms.php?method=Submit";

        public static string PostSmS(string mobile,string sendTxt)
        {
            string account = _sysconfig.smsusername;
            string password = _sysconfig.smspassword;//密码可以使用明文密码或使用32位MD5加密

            string postStrTpl = "account={0}&password={1}&mobile={2}&content={3}";

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, account, password, mobile, sendTxt));

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);

                //Response.Write(reader.ReadToEnd());

                string res = reader.ReadToEnd();
                int len1 = res.IndexOf("</code>", StringComparison.Ordinal);
                int len2 = res.IndexOf("<code>", StringComparison.Ordinal);
                string code = res.Substring((len2 + 6), (len1 - len2 - 6));
                //Response.Write(code);

                int len3 = res.IndexOf("</msg>", StringComparison.Ordinal);
                int len4 = res.IndexOf("<msg>", StringComparison.Ordinal);
                string msg = res.Substring((len4 + 5), (len3 - len4 - 5));
                return code;
            }
            else
            {
                //访问失败
            }
            return "";
        }
    }
}
