using Acr.UserDialogs;
using ByMe.Model.Response;
using ByMe.Model.UserModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ByMe.Helpers;
using ByMe.global;
using ByMe.View.UserView;

namespace ByMe.ViewModel.UserViewModel
{
   public class UserEditProfileViewModel :BaseViewModel
    {
        #region PropertyDeclaration

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

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; RaisePropertyChanged(() => Password); }
        }

        private string mobile;
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; RaisePropertyChanged(() => Mobile); }
        }

        #endregion

        
        public UserEditProfileViewModel()
        {
           
            UserModel user = App.baseUser;
            Email = user.EmailId;
            Mobile = user.MobileNo;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
            _Base64_Img =user.UserImage;
        }



        private Command editProfileCommand;
        public Command EditProfileCommand
        {
            get
            {
                return editProfileCommand ?? (editProfileCommand = new Command(() => ExecuteEditProfileCommand()));
            }
        }

        private bool CheckValidations()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                UserDialogs.Instance.Alert("Please enter firstname", null, "Cancel");
                return false;
            }
            else if (_Base64_Img == null)
            {
                UserDialogs.Instance.Alert("Upload Image", null, "Cancel");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(LastName))
            {
                UserDialogs.Instance.Alert("Please enter LastName", null, "Cancel");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(Mobile))
            {
                UserDialogs.Instance.Alert("Please enter Mobile", null, "Cancel");
                return false;
            }
            else
            {
                return true;
            }
        }
        private async void ExecuteEditProfileCommand()
        {

            if (CheckValidations())
            {
                App.baseUser.FirstName = FirstName;
                App.baseUser.LastName = LastName;
                App.baseUser.MobileNo = Mobile;
                if(_Base64_Img.Equals(App.baseUser.UserImage))
                {
                    App.baseUser.UserImage = null;
                }
                else
                {
                    App.baseUser.UserImage = _Base64_Img;
                }
               
               
                UserDialogs.Instance.ShowLoading();
                Rest_Response rest_result = await WebService.PostData(App.baseUser, "User/UserProfileUpdate");
                if (rest_result != null)
                {
                    if (rest_result.status_code == 200)
                    {
                        RootObjectUserModel data = JsonConvert.DeserializeObject<RootObjectUserModel>(rest_result.response_body);
                        if (data.StatusCode == 200)
                        {
                            var userobj = data.user_detail;
                            UserDialogs.Instance.Alert("Registered", null, "OK");
                            App.baseUser = userobj;
                            App.Current.MainPage = new UserMasterController();
                            //App.setting_Model.userModel = userobj;
                            //var sUser = JsonConvert.SerializeObject(App.setting_Model);
                            //Settings.GeneralSettings = sUser;

                        }

                    }
                    else
                    {
                        UserDialogs.Instance.Alert("User Already registered");
                    }

                }
                UserDialogs.Instance.HideLoading();

            }


        }


    }
}
