
using ByMe.global;
using ByMe.Model.UserModel;
using ByMe.View;
using ByMe.View.UserView;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.ViewModel.UserViewModel
{
    public class UserMenuItemViewModel : BaseViewModel
    {

        private string _base64_Img;
        public string _Base64_Img
        {
            get { return _base64_Img; }
            set { _base64_Img = value; RaisePropertyChanged("_Base64_Img"); }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; RaisePropertyChanged(() => FirstName); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; RaisePropertyChanged(() => LastName); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; RaisePropertyChanged(() => Email); }
        }


        ObservableCollection<UserMenuItemModel> menuItems;
        public ObservableCollection<UserMenuItemModel> MenuItems
        {
            get { return menuItems; }
            set
            {
                menuItems = value;
                RaisePropertyChanged("menuItems");
            }
        }

        public UserMenuItemViewModel()
        {
            UserModel user = App.baseUser;
            Email = user.EmailId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            _Base64_Img =Constant.BaseUserImageUrl+ user.UserImage;

            MenuItems = new ObservableCollection<UserMenuItemModel>
                {
                     new UserMenuItemModel
                    {
                        MenuItemTitle="Home",MenuItemIconSource="home.png",PageType=typeof(UserHome)
                    },
                     new UserMenuItemModel
                    {
                        MenuItemTitle="Computer And Accessories",MenuItemIconSource="computer.png",PageType=typeof(UserComputer)
                    },
                      new UserMenuItemModel
                    {
                        MenuItemTitle="Clothing",MenuItemIconSource="shirt2.png",PageType=typeof(UserClothingPage)
                    },
                       new UserMenuItemModel
                    {
                        MenuItemTitle="Account",MenuItemIconSource="profileicon.png",PageType=typeof(UserProfile)
                    },
                        new UserMenuItemModel
                    {
                        MenuItemTitle="Logout",MenuItemIconSource="signout.png",PageType=typeof(LoginPage)
                    },

        };
        }
    }
}
