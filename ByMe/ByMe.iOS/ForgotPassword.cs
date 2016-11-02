using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using ByMe.Util.Interface;
using MimeKit;
using MailKit.Net.Smtp;

using MailKit.Security;
using ByMe.IOS;

[assembly: Xamarin.Forms.Dependency(typeof(ForgotPassword))]
namespace ByMe.IOS
{
    public class ForgotPassword : IForgotPassword
    {
        public void mailPassword(string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ByMe", "chandrika1developer@gmail.com"));
            message.To.Add(new MailboxAddress("Chandrika ", "cmbajoria1993@gmail.com"));
            message.Subject = "Your ByMe Password";

            message.Body = new TextPart("plain")
            {
                Text = @"Your Password is:"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("chandrika1developer@gmail.com", "Ch@ndrika1111");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}