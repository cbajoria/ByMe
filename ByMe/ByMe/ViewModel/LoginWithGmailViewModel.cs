using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.ViewModel
{
    public class LoginWithGmailViewModel :BaseViewModel
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

        private string access_token;
        public string AccessToken
        {
            get { return access_token; }
            set { access_token = value; RaisePropertyChanged(() => AccessToken); }
        }

        #endregion
        public LoginWithGmailViewModel()
        {
           
        }
    }
}
