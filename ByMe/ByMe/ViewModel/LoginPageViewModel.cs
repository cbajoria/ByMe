using Acr.UserDialogs;
using ByMe.AdminView;
using ByMe.Model.Response;
using ByMe.Model.UserModel;
using ByMe.View.UserView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ByMe.Helpers;
using Plugin.LocalNotifications;

namespace ByMe.ViewModel
{
    public class LoginPageViewModel :BaseViewModel
    {
        #region propertydeclaration
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
        #endregion
        #region LoginCommand
        private Command loginCommand;
        public Command LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new Command(() => ExecuteLoginCommand()));
            }
        }


        private bool CheckValidations()
        {


            if (string.IsNullOrWhiteSpace(Password))
            {
                UserDialogs.Instance.Alert("Please enter password", null, "Cancel");
                return false;
            }

            else if (string.IsNullOrWhiteSpace(Email))
            {
                UserDialogs.Instance.Alert("Please enter email", null, "Cancel");
                return false;
            }


            else if (!IsValidEmail(Email))
            {
                UserDialogs.Instance.Alert("Incorrect Email id", null, "Cancel");
                return false;
            }
            //else if (!IsValidPassword(Password))
            //{
            //    UserDialogs.Instance.Alert("Password must contain a no.,capital letter,and size should be betwwen 8-15", null, "Cancel");
            //    return false;
            //}
            else
            {
                return true;
            }
        }
        public async void ExecuteLoginCommand()
        {

            if (CheckValidations())
            {
                UserModel user = new UserModel();
                user.EmailId = Email;
                user.Password = Password;
                UserDialogs.Instance.ShowLoading();
                Rest_Response rest_result = await WebService.PostData(user, "User/UserLogin");
                if (rest_result != null)
                {
                    if (rest_result.status_code == 200)
                    {
                        RootObjectLoginUserModel data = JsonConvert.DeserializeObject<RootObjectLoginUserModel>(rest_result.response_body);
                        if (data.StatusCode == 200)
                        {
                            var userobj = data.user_detail;
                            if (userobj.IsAdmin)
                            {
                                App.Current.MainPage = new AdminMasterController();
                            }
                            else
                            {
                              
                                App.baseUser = userobj;
                                App.setting_Model.userModel = userobj;
                                var sUser = JsonConvert.SerializeObject(App.setting_Model);
                                Settings.GeneralSettings = sUser;
                                App.Current.MainPage = new UserMasterController();
                           

                            }
                        }
                        else
                        {
                            UserDialogs.Instance.Alert("Invalid Username or Password", null, "OK");
                        }

                    }

                }
                UserDialogs.Instance.HideLoading();

            }


        }

#endregion
    }
}
