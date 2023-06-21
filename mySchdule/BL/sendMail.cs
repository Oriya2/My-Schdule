using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using Entities;
using Dal;

namespace BL
{


public class sendMail

    {
        //מחלקה זו אחראית על שליחת כל המיילים בפרויקט


        //{פונקציה זו מקבלת את העובד ומס' ההודעה ומסווגת את שליחתה עפ"י הגדרות ההתקשרות של המשתמש

        //public static void SendMassage(EmployeeDTO employee, eMessegeText mt, int absenceId = 0)
        //{
        //    XDocument myDoc = XDocument.Load(MessegesFilePath);
        //    var q1 = myDoc.Root.Elements("messege").First(e => e.Attribute("name").Value == mt.ToString());
        //    string sub = q1.Attribute("subject").Value;
        //    string body = q1.Attribute("body").Value;
        //    switch (mt)
        //    {
        //        case eMessegeText.AskSubBeforeEmbedding:
        //            body += employee.UserCode;
        //            break;
        //        case eMessegeText.SupervisorAbsenceConfirm:
        //            sub += employee.FirstName + " " + employee.LastName;
        //            body += employee.UserCode + "/" + absenceId;
        //            break;
        //        default:
        //            break;
        //    }
        //    var c = DB.EmployeeContacts_tbl.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId && e.ContactPriority == 1);
        //    switch (c.ContactId)
        //    {
        //        case (int)eConnections.Mail:

        //            SendEmail(c.ContactAddress, sub, body);
        //            return;
        //    }

        //}



        //public static void Func(string adressMail)
        //{
        //    Mail.SendEmail(adressMail, "I try to send mail!!", "you are lucky!!");
        //}
       
    }
    }

