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
        mMailMessage.From = new MailAddress("do-not-reply@acig.com");
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
               Host = "smtp.gmail.com",
               Port = 587,
               EnableSsl = true,
               DeliveryMethod = SmtpDeliveryMethod.Network,
               UseDefaultCredentials = false,
               Credentials = new NetworkCredential("ubaidkhan88@gmail.com", "khan777111")
           };
        mSmtpClient.Send(mMailMessage);
    }
}