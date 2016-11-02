using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ByMe.Util
{
    class ValidateEmail : TriggerAction<Entry>
    {

        protected override void Invoke(Entry sender)
        {
            //Color defaultcolor= sender.TextColor;
            string regexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Match matches = Regex.Match(sender.Text, regexPattern);
            if (matches.Success)
            {
                sender.TextColor = Color.Black;
            }
            else
            {
                sender.TextColor = Color.Red;
             
            }

            
        }
    }
}
