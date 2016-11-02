using ByMe.Model.UserModel;
using ByMe.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View.UserView
{
    public partial class UserProductDescription : ContentPage
    {
        ProductModel pm;
        private UserProductDescriptionViewModel productDescViewModel;
        public UserProductDescription(object obj)
        {
            InitializeComponent();
            pm = (ProductModel)obj; 
            productDescViewModel = App.Locator.ProductDesc;
            productDescViewModel.Product = pm;
            BindingContext = productDescViewModel;
        }
       
        protected async override void OnAppearing()
        {
            base.OnAppearing();

           // Prqty.Text = "1";
            image.Source = pm.ProductImage;
            name.Text = pm.Name;
            price.Text = pm.Price.ToString();
            desc.Text = pm.Desc;
            total.Text = pm.Qty.ToString();
            if (pm.Qty <= 0)
            {
                instock.Text = "Out Of Stock";
                instock.TextColor = Color.Red;
            }
            else
            {
                instock.Text = "In Stock";
                instock.TextColor = Color.Green;
            }


           productDescViewModel.AddCartCount();
        }
        public void cart_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserCart());
        }

    }
}
