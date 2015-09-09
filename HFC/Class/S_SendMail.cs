using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace HFC.Class
{
    class S_SendMail
    {
        public static void Sendmail(string _from,string _to,string _subject,string _content)
        {
            // create mail message object
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_from,"IT LBC"); // put the from address here
            mail.To.Add(_to); // put to address here
            mail.Subject = _subject; // put subject here
             mail.Body = _content; // put body of email here               
            SmtpClient SmtpMail = new SmtpClient("mail.lbc.com.vn",25);            
            // and then send the mail 
            SmtpMail.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;   
            NetworkCredential netCred = new NetworkCredential("it@lbc.com.vn", "lbc789");           
            SmtpMail.Credentials = netCred;            
            SmtpMail.Send(mail);
            mail.Dispose();
            SmtpMail = null;
        }       
    }
}
