using ByMe.AdminView;
using ByMe.global;
using ByMe.View.UserView;
using ByMe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View
{
    public partial class LoginPage : ContentPage
    {

        private LoginPageViewModel loginViewModel;

        public LoginPage()
        {
            InitializeComponent();
            loginViewModel = App.Locator.Login;
            BindingContext = loginViewModel;
            Title = "Login";   
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.setting_Model.userModel != null)
            {
                txtEmail.Text = App.setting_Model.userModel.EmailId;
                txtPassword.Text = App.setting_Model.userModel.Password;
                loginViewModel.ExecuteLoginCommand();
                //or redirect it to home page,whenever the user will open the open it will be send to home page
            }

        }

        private void BtnGP_Clicked(object sender, EventArgs e)
        {
            Constant.IsGoogleLogin = true;
            this.Navigation.PushAsync(new LoginWithGmail());
        }

        private void BtnFB_Clicked(object sender, EventArgs e)
        {
            Constant.IsFacebookLogin = true;
           this.Navigation.PushAsync(new LoginWithGmail());
        }


        //NavigationPage _NavPage;
        //public Page GetMainPage()
        //{
        //    var profilePage = new ProfilePage();
        //    _NavPage = new NavigationPage((Page)profilePage);
        //    return _NavPage;
        //}

        private void BtnForgot_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPassword());
        }


        private void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage()); 
        }


    }
}
