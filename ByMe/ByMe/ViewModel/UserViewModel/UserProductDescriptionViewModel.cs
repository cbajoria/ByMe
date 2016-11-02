using ByMe.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ByMe.ViewModel.UserViewModel
{
   public class UserProductDescriptionViewModel :BaseViewModel
    {


        private ProductModel product;
        public ProductModel Product
        {
            get { return product; }
            set { product = value; RaisePropertyChanged("Product"); }

        }

        private Command addToCart;
        public Command AddToCart
        {
            get
            {
                return addToCart ?? (addToCart = new Command(() => ExecuteAddToCartCommand(Product)));
            }
        }
    }
}
