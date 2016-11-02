using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ByMe.Util
{
    class ValidatePhoneNo : TriggerAction<Entry>
    {
        
        protected override void Invoke(Entry sender)
        {
          int length=sender.Text.Length;
            sender.TextColor = length == 10 ? Color.Black : Color.Red;
            if (length > 10)
                sender.Text = sender.Text.Substring(0, 10);


        }
    }



}
