using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Web;
using System.Net.Mail;

namespace FytSoa.Common
{
    public class EmailHelper
    {
        #region 发送电子邮件
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="smtpserver">SMTP服务器</param>
        /// <param name="userName">登录帐号</param>
        /// <param name="pwd">登录密码</param>
        /// <param name="nickName">发件人昵称</param>
        /// <param name="strfrom">发件人</param>
        /// <param name="strto">收件人</param>
        /// <param name="subj">主题</param>
        /// <param name="bodys">内容</param>
        public static void SendMail(string smtpserver, string userName, string pwd, string nickName, string strfrom, string strto, string subj, string bodys)
        {
            var smtpClient = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Host = smtpserver,
                UseDefaultCredentials = true,
                Credentials = new System.Net.NetworkCredential(userName, pwd)
            };
            //指定电子邮件发送方式
            //指定SMTP服务器
            //用户名和密码
            //MailMessage _mailMessage = new MailMessage(strfrom, strto);
            var from = new MailAddress(strfrom, nickName);
            var to = new MailAddress(strto);
            var mailMessage = new MailMessage(from, to)
            {
                Subject = subj,
                Body = bodys,
                BodyEncoding = Encoding.Default,
                IsBodyHtml = true,
                Priority = MailPriority.Normal
            };
            smtpClient.Send(mailMessage);
        }
        #endregion
    }
}
