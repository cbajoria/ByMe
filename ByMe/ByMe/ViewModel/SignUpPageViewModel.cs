using Acr.UserDialogs;
using ByMe.Model.Response;
using ByMe.Model.UserModel;
using ByMe.View.UserView;
using Java.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ByMe.Helpers;

namespace ByMe.ViewModel
{
    public class SignUpPageViewModel : BaseViewModel
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
            set { firstName = value;RaisePropertyChanged(() => FirstName); }
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

        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; RaisePropertyChanged(() => ConfirmPassword); }
        }

        private string mobile;
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; RaisePropertyChanged(() => Mobile); }
        }

        #endregion

        #region registerCommand
        private Command registerCommand;
        public Command RegisterCommand
        {
            get
            {
                return registerCommand ?? (registerCommand = new Command(() => ExecuteRegisterCommand()));
            }
        }

        private bool CheckValidations()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                UserDialogs.Instance.Alert("Please enter firstname", null, "Cancel");
                return false;
            }
            else if (_Base64_Img==null)
            {
                UserDialogs.Instance.Alert("Upload Image", null, "Cancel");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(LastName))
            {
                UserDialogs.Instance.Alert("Please enter alstname", null, "Cancel");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(Password))
            {
                UserDialogs.Instance.Alert("Please enter password", null, "Cancel");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                UserDialogs.Instance.Alert("Please enter confirm Password", null, "Cancel");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(Email))
            {
                UserDialogs.Instance.Alert("Please enter email", null, "Cancel");
                return false;
            }

            else if (!Password.Equals(ConfirmPassword))
            {
                UserDialogs.Instance.Alert("Password and confirm password is not equal", null, "Cancel");
                return false;
            }
            else if (!IsValidEmail(Email))
            {
                UserDialogs.Instance.Alert("Incorrect Email id", null, "Cancel");
                return false;
            }
            else if (!IsValidPassword(Password))
            {
                UserDialogs.Instance.Alert("Password must contain a no.,capital letter,and size should be betwwen 8-15", null, "Cancel");
                return false;
            }
            //else if (!IsValidMobile(Mobile))
            //{
            //    UserDialogs.Instance.Alert("Invalid Mobile No.", null, "Cancel");
            //    return false;

            //}
            else
            {
                return true;
            }
        }
        private async void ExecuteRegisterCommand()
        {

            if (CheckValidations())
            {
                UserModel user = new UserModel();
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.EmailId = Email;
                user.AccountType = "normal";
                user.IsAdmin = false;
                user.Password = Password;
                user.UserImage = _Base64_Img;
                user.MobileNo = Mobile;
                
                UserDialogs.Instance.ShowLoading();
                Rest_Response rest_result = await WebService.PostData(user, "User/UserSignUp");
                if (rest_result != null)
                {
                    if (rest_result.status_code == 200)
                    {
                        RootObjectUserModel data = JsonConvert.DeserializeObject<RootObjectUserModel>(rest_result.response_body);
                        if (data.StatusCode == 200)
                        {
                            var userobj= data.user_detail;
                            App.baseUser = userobj;
                            App.setting_Model.userModel = userobj;
                            var sUser = JsonConvert.SerializeObject(App.setting_Model);
                            Settings.GeneralSettings = sUser;
                            UserDialogs.Instance.Alert("Registered", null, "OK");
                            App.Current.MainPage = new UserMasterController();

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

        #endregion
    }
}
