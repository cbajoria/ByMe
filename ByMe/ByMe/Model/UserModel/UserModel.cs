using ByMe.global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.Model.UserModel
{
    public class UserModel
    {

            public int Id { get; set; }
            public string AccountType { get; set; }
            public bool IsAdmin { get; set; }
            public string EmailId { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserImage { get; set; }
            public string MobileNo { get; set; }
            public object AccessToken { get; set; }
            public string ModifyDate { get; set; }
           // public string UserImg { get { return string.Format(Constant.BaseUserImageUrl + UserImage); }}
    }

        public class RootObjectUserModel
        {
            public int StatusCode { get; set; }
            public UserModel user_detail { get; set; }
            public string ResponseMessage { get; set; }
        }
    public class RootObjectLoginUserModel
    {
        public int StatusCode { get; set; }
        public UserModel user_detail { get; set; }
    }
    public class UserAddress
    {
        public string HomeNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }

    }


}

