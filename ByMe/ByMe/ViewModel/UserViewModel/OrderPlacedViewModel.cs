 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.ViewModel.UserViewModel
{
   public class OrderPlacedViewModel :BaseViewModel
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

        public OrderPlacedViewModel()
        {
            City = App.address.City;
            HomeNo = App.address.HomeNo;
            Pincode = App.address.Pincode;
           State = App.address.State;
            Street = App.address.Street;

        }




    }
}
