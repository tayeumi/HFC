using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace HFC.Class
{
    class S_SendMail
    {
        public static void Sendmail(string _from, string _to, string _subject, string _content, string attachmentFilename1, string attachmentFilename2, string attachmentFilename3)
        {
            // create mail message object
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_from,"PTH Network Management"); // put the from address here
            mail.To.Add(_to); // put to address here
            mail.Subject = _subject; // put subject here
             mail.Body = _content; // put body of email here     
             if (attachmentFilename1 != null)
             {
                 // Create  the file attachment for this e-mail message.
                 Attachment data = new Attachment(attachmentFilename1, MediaTypeNames.Application.Octet);
                 // Add time stamp information for the file.
                 ContentDisposition disposition = data.ContentDisposition;
                 disposition.CreationDate = System.IO.File.GetCreationTime(attachmentFilename1);
                 disposition.ModificationDate = System.IO.File.GetLastWriteTime(attachmentFilename1);
                 disposition.ReadDate = System.IO.File.GetLastAccessTime(attachmentFilename1);
                 // Add the file attachment to this e-mail message.
                 mail.Attachments.Add(data);

             }
             if (attachmentFilename2 != null)
             {
                 // Create  the file attachment for this e-mail message.
                 Attachment data = new Attachment(attachmentFilename2, MediaTypeNames.Application.Octet);
                 // Add time stamp information for the file.
                 ContentDisposition disposition = data.ContentDisposition;
                 disposition.CreationDate = System.IO.File.GetCreationTime(attachmentFilename2);
                 disposition.ModificationDate = System.IO.File.GetLastWriteTime(attachmentFilename2);
                 disposition.ReadDate = System.IO.File.GetLastAccessTime(attachmentFilename2);
                 // Add the file attachment to this e-mail message.
                 mail.Attachments.Add(data);

             }
             if (attachmentFilename3 != null)
             {
                 // Create  the file attachment for this e-mail message.
                 Attachment data = new Attachment(attachmentFilename3, MediaTypeNames.Application.Octet);
                 // Add time stamp information for the file.
                 ContentDisposition disposition = data.ContentDisposition;
                 disposition.CreationDate = System.IO.File.GetCreationTime(attachmentFilename3);
                 disposition.ModificationDate = System.IO.File.GetLastWriteTime(attachmentFilename3);
                 disposition.ReadDate = System.IO.File.GetLastAccessTime(attachmentFilename3);
                 // Add the file attachment to this e-mail message.
                 mail.Attachments.Add(data);

             }
                // mail.Attachments.Add(new Attachment(attachmentFilename));
            SmtpClient SmtpMail = new SmtpClient("mail.phuthehung.vn",587);            
            // and then send the mail             
            SmtpMail.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            NetworkCredential netCred = new NetworkCredential("log@phuthehung.vn", "Pth12345");           
            SmtpMail.Credentials = netCred;            
            SmtpMail.Send(mail);
            mail.Dispose();
            SmtpMail = null;
        }       
    }
}
