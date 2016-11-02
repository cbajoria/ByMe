using Acr.UserDialogs;
using ByMe.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View.UserView
{
    public partial class UserCart : ContentPage
    {
        private UserCartViewModel userCart;
        public UserCart()
        {
            InitializeComponent();
            Title = "Cart";
            userCart = App.Locator.Cart;
            BindingContext = userCart;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            userCart.Init();
            int i = userCart.GetQty();
            userCart.Totalqty = Convert.ToString(i);
            double price = userCart.GetPrice();
            userCart.TotalPrice = Convert.ToString(price);
        }

       public void proceedToCheckout(object sender,EventArgs e)
        {
            if (userCart.GetQty() <= 0)
            {
                UserDialogs.Instance.Alert("Cart is empty", null, "OK");
            }
            else
            {
                Navigation.PushAsync(new ProceedToCheckout());
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            userCart.AddCartCount();
        }

    }
}
