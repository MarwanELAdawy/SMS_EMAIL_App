using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

public class Mailer
{
    public static void SendMailMessage(string to, string bcc, string cc, string subject, string body)
    {
 
        MailMessage mMailMessage = new MailMessage();
        mMailMessage.From = new MailAddress("crmmailadmin@acig.com.sa");
        mMailMessage.To.Add(new MailAddress(to));
        if ((bcc != null) && (bcc != string.Empty))
        {
            mMailMessage.Bcc.Add(new MailAddress(bcc));
        }
        if ((cc != null) && (cc != string.Empty))
        {
         
            mMailMessage.CC.Add(new MailAddress(cc));
        }
        mMailMessage.Subject = subject;
        mMailMessage.Body = body;
        mMailMessage.IsBodyHtml = true;
        mMailMessage.Priority = MailPriority.Normal;
        SmtpClient mSmtpClient = new SmtpClient {
               Host = "mail.acig.com.sa",
               Port = 25,
               EnableSsl = true,
               DeliveryMethod = SmtpDeliveryMethod.Network,
               UseDefaultCredentials = false,
               Credentials = new NetworkCredential("crmmailadmin", "passwoRd5656")
           };
        mSmtpClient.Send(mMailMessage);
    }
}