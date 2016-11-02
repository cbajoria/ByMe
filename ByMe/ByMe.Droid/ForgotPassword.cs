using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ByMe.Util.Interface;
using MimeKit;
using MailKit.Net.Smtp;
using ByMe.Droid;
using MailKit.Security;

[assembly: Xamarin.Forms.Dependency(typeof(ForgotPassword))]
namespace ByMe.Droid
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