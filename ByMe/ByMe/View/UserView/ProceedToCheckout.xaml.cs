using Acr.UserDialogs;
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
    public partial class ProceedToCheckout : ContentPage
    {
        private ProceedToCheckoutViewModel checkoutViewModel;
        public ProceedToCheckout()
        {
            InitializeComponent();
            checkoutViewModel = App.Locator.Checkout;
            BindingContext = checkoutViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            int i = checkoutViewModel.GetQty();
            checkoutViewModel.Totalqty = Convert.ToString(i);
            double price = checkoutViewModel.GetPrice();
            checkoutViewModel.TotalPrice = Convert.ToString(price);
        }
        public void PlaceOrder(object sender,EventArgs e)
        {

            if (btn1.Image == "radiobtn.png" || btn2.Image == "radiobtn.png" || btn3.Image == "radiobtn.png" || btn4.Image == "radiobtn.png")
            {
                if (Constant.IsAddressFilled)
                {
                    checkoutViewModel.PlaceOrder.Execute(null);
                    Navigation.PushAsync(new OrderPlaced());
                   
                }
                else
                {
                    UserDialogs.Instance.Alert("Please Fill the Address", null, "Ok");
                }
            }
            else
            {
                UserDialogs.Instance.Alert("Please Select payment option", null, "Ok");
            }
        }
        public void btn1Clicked(object sender,EventArgs e)
        {
            btn1.Image = "radiobtn.png";
            btn2.Image = "radiobtnunchecked.png";
            btn3.Image = "radiobtnunchecked.png";
            btn4.Image = "radiobtnunchecked.png";
        }
        public void btn2Clicked(object sender, EventArgs e)
        {
            btn1.Image = "radiobtnunchecked.png";
            btn2.Image = "radiobtn.png";
            btn3.Image = "radiobtnunchecked.png";
            btn4.Image = "radiobtnunchecked.png";
        }

        public void btn3Clicked(object sender, EventArgs e)
        {
            btn1.Image = "radiobtnunchecked.png";
            btn2.Image = "radiobtnunchecked.png";
            btn3.Image = "radiobtn.png";
            btn4.Image = "radiobtnunchecked.png";
        }

        public void btn4Clicked(object sender, EventArgs e)
        {
            btn1.Image = "radiobtnunchecked.png";
            btn2.Image = "radiobtnunchecked.png";
            btn3.Image = "radiobtnunchecked.png";
            btn4.Image = "radiobtn.png";
        }


    }
}
