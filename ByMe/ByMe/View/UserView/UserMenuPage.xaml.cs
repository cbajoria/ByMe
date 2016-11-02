using ByMe.global;
using ByMe.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View.UserView
{
    public partial class UserMenuPage : ContentPage
    {

        public ListView MenuOptionListView //expose list to public i.e. MenuController
        {
            get { return menuOptionListView; }
        }
        private UserMenuItemViewModel userMenu;
        public UserMenuPage()
        {
            InitializeComponent();
            userMenu = App.Locator.UserMenu;
            BindingContext = userMenu;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            userMenu.FirstName = App.baseUser.FirstName;
            userMenu.LastName = App.baseUser.LastName;
            userMenu.Email = App.baseUser.EmailId;
            
            lblName.Text = App.baseUser.FirstName + " " + App.baseUser.LastName;
            lblEmail.Text = App.baseUser.EmailId;
            if (App.baseUser.AccessToken == null)
            {
                imageName.Source = Constant.BaseUserImageUrl + App.baseUser.UserImage;
            }
            else
            {
                imageName.Source = App.baseUser.UserImage;
            }

            //if (App.setting_Model.userModel != null)
            //{
            //    lblName.Text = App.setting_Model.userModel.FirstName + App.setting_Model.userModel.LastName;
            //    lblEmail.Text = App.setting_Model.userModel.EmailId;
            //    imageName.Source= App.setting_Model.userModel.UserImg;
            //  //  var base64EncodedBytes = Convert.FromBase64String(image);
            //   //imageName.Source= ImageSource.FromStream(() => new MemoryStream(base64EncodedBytes));
            //}
        }

    }
}
