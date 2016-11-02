using ByMe.Util.Interface;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View
{
    public partial class ForgotPassword : ContentPage
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }
        public void ForgotPwdClicked(object sender,EventArgs e)
        {

            DependencyService.Get<IForgotPassword>().mailPassword(emailaddress.Text);
        }
    }
}
