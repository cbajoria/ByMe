using Acr.UserDialogs;
using ByMe.global;
using ByMe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View
{
    public partial class LoginWithGmail : ContentPage
    {
        private LoginWithGmailViewModel viewModel;
        public LoginWithGmail()
        {
            InitializeComponent();
            viewModel = App.Locator.LoginWithGmail;
            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Constant.IsFacebookLogin)
            {
                // UserDialogs.Instance.ShowLoading();
            }
            else if(Constant.IsGoogleLogin)
            {
                //UserDialogs.Instance.ShowLoading();
            }
            else
            {
                UserDialogs.Instance.HideLoading();
            }


        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            UserDialogs.Instance.HideLoading();
        }
    }
}
