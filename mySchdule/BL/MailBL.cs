using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Dal;
using System.Xml.Linq;

namespace BL
{
    public static class MailBL
    {
        //internal const string MessegesFilePath = @"D:\strauss&porush\מעודכן 16.07.19\ServerSide\BLL\BLL\MessegesXML.xml";
        public static bool SendEmail(string contactAddress, string subject, string body)
        {
            try
            {
                string FromMail = "schdule11@gmail.com‏";
                string Password = "s!123456";
                string emailTo = contactAddress;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(FromMail);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential(FromMail, Password);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static bool SendMassage(string adress, int typeCode, string password, string location)
        {
            ScheduleEntities DB = new ScheduleEntities();
            location += "mailXML.xml";
            //load the xml file
            XDocument myDoc = XDocument.Load(location);
            var q1 = myDoc.Root.Elements("massage").First(e => e.Attribute("code").Value == typeCode.ToString());
            string sub = q1.Attribute("subject").Value;
            string body = q1.Attribute("body").Value;
            body +="<br>"+password;
            return SendEmail(adress, sub, body);
        }

        public static bool mailEeserPassword(string adress, int typeCode, string newPassword, string location)
        {
            ScheduleEntities DB = new ScheduleEntities();
            location += "mailXML.xml";
            //load the xml file
            XDocument myDoc = XDocument.Load(location);
            var q1 = myDoc.Root.Elements("massage").First(e => e.Attribute("code").Value == typeCode.ToString());
            string sub = q1.Attribute("subject").Value;
            string body = q1.Attribute("body").Value;
            body += "<br>" + newPassword;
            return SendEmail(adress, sub, body);
        }



    }
}




