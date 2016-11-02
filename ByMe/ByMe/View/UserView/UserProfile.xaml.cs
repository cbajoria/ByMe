using ByMe.global;
using ByMe.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View.UserView
{
    public partial class UserProfile : ContentPage
    {
        private UserProfileViewModel userProfile;
        public UserProfile()
        {
           
            InitializeComponent();
            userProfile = App.Locator.UserProfile;
            BindingContext = userProfile;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            userProfile._Base64_Img = App.baseUser.UserImage;
            userProfile.FirstName = App.baseUser.FirstName;
            userProfile.LastName = App.baseUser.LastName;
            userProfile.Email = App.baseUser.EmailId;
            userProfile.Mobile = App.baseUser.MobileNo;
            if (App.baseUser.AccessToken == null)
            {
                image.Source = Constant.BaseUserImageUrl + App.baseUser.UserImage;
            }
            else
            {
                image.Source = App.baseUser.UserImage;
            }


        }

        private void BtnEdit_Clicked(object sender, EventArgs e)
        {

            this.Navigation.PushAsync(new UserEditProfile());

        }
    }
}
