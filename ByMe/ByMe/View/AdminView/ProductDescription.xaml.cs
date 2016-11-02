using ByMe.global;
using ByMe.Model.UserModel;
using ByMe.ViewModel.AdminViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View.AdminView
{
    public partial class ProductDescription : ContentPage
    {
        ProductModel pm;
        private ProductDescriptionViewModel viewModel; 
        public ProductDescription(object obj)
        {
            InitializeComponent();
           pm = (ProductModel)obj;
            viewModel = App.Locator.AdminProduct;
            viewModel.Product = pm;
            BindingContext = viewModel;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            image.Source =Constant.BaseProductImageUrl+pm.Image;
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


        }



        public void EditProductClicked(object sender,EventArgs e)
        {
            Navigation.PushAsync(new EditProduct(pm));
        }
       
       
    }

   
}
