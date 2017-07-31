using SyntacticSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FytSoa.Common;

namespace FytSoa.Core
{
    public class PubGet
    {
        public static string GetUserKey
        {
            get
            {
                return CookiesManager<string>.GetInstance()[KeyHelper.UserUniqueKey] + "--" + KeyHelper.UserUniqueKey;
            }
        }
        public static string GetEmailUserName
        {
            get
            {
                return ConfigSugar.GetAppString("EmailUserName");

            }
        }
        public static string GetEmailPassword
        {
            get
            {
                return ConfigSugar.GetAppString("EmailPassword");

            }
        }
        public static string GetEmailSmtp
        {
            get
            {
                return ConfigSugar.GetAppString("EmailSmtp");

            }
        }
    }
}
