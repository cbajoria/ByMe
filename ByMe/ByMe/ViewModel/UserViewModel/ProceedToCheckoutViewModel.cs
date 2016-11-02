using Acr.UserDialogs;
using ByMe.global;
using ByMe.Model.Response;
using ByMe.Model.UserModel;
using Newtonsoft.Json;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ByMe.ViewModel.UserViewModel
{
   public class ProceedToCheckoutViewModel :BaseViewModel
    {
        private string homeNo;
        public string HomeNo
        {
            get { return homeNo; }
            set { homeNo = value; RaisePropertyChanged("HomeNo"); }
        }
        private string street;
        public string Street
        {
            get { return street; }
            set { street = value; RaisePropertyChanged("Street"); }
        }
        private string city;
        public string City
        {
            get { return city; }
            set { city = value; RaisePropertyChanged("City"); }
        }
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; RaisePropertyChanged("State"); }
        }
        private string pincode;
        public string Pincode
        {
            get { return pincode; }
            set { pincode = value; RaisePropertyChanged("Pincode"); }
        }

        private Command saveAddress;
        public Command SaveAddress
        {
            get
            {
                return saveAddress ?? (saveAddress = new Command(() => ExecutesaveAddressCommand()));
            }
        }
        private Command placeOrder;
        public Command PlaceOrder
        {
            get
            {
                return placeOrder ?? (placeOrder = new Command(() => ExecutePlaceOrderCommand()));
            }
        }

        public async void ExecutePlaceOrderCommand()
        {
            UserDialogs.Instance.ShowLoading();
            foreach (var item in cartList)
            {
                item.Qty = 1;
            }
            Rest_Response rest_result = await WebService.PostData(cartList, "Product/PlaceOrder");
            if (rest_result != null)
            {
                if (rest_result.status_code == 200)
                {
                   //await GetProduct();
                    RootObjectProduct data = JsonConvert.DeserializeObject<RootObjectProduct>(rest_result.response_body);
                    if (data.StatusCode == 200)
                    {
                        CrossLocalNotifications.Current.Show("ByMe", "Your Order has Been Placed worth Rs."+ GetPrice());
                        cartList = new ObservableCollection<ProductModel>();        
                    }

                }
                else
                {
                    UserDialogs.Instance.Alert("User Already registered");
                }

            }
            UserDialogs.Instance.HideLoading();

        
    }

      


        private bool CheckValidations()
        {
            if (string.IsNullOrWhiteSpace(HomeNo))
            {
                UserDialogs.Instance.Alert("Please enter HomeNo", null, "Cancel");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(Street))
            {
                UserDialogs.Instance.Alert("Please enter Street", null, "Cancel");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(City))
            {
                UserDialogs.Instance.Alert("Please enter City", null, "Cancel");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(Pincode))
            {
                UserDialogs.Instance.Alert("Please enter confirm Pincode", null, "Cancel");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(State))
            {
                UserDialogs.Instance.Alert("Please enter State", null, "Cancel");
                return false;
            }
            
            else
            {
                return true;
            }
        }



        void ExecutesaveAddressCommand()
        {
            if (CheckValidations())
            {

                App.address.HomeNo = HomeNo;
                App.address.Street = Street;
                App.address.City = City;
                App.address.State = State;
                App.address.Pincode = Pincode;
                UserDialogs.Instance.Alert("address save", null, "Ok");
                Constant.IsAddressFilled = true;
            }
        }


    }
}
