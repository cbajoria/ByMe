using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ByMe.Util
{
   public class ValidatePassword : TriggerAction<Entry>

    {

        protected override void Invoke(Entry sender)
        {

            // int length = sender.Text.Length;
            // sender.TextColor = length>8 ? Color.Black : Color.Red;

            //  Entry entry = (Entry)sender;
            sender.TextColor = IsValidPassword(sender.Text) ? Color.Black : Color.Red;
        }

        bool IsValidPassword(string strnIn)
        {

            if (String.IsNullOrEmpty(strnIn))
                return false;
            try
            {
                return Regex.IsMatch(strnIn, "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

            }
            catch (RegexMatchTimeoutException)
            {
                return false;

            }
        }
    }
}