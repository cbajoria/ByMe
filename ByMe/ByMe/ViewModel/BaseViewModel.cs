

using Acr.UserDialogs;
using ByMe.Model.Response;
using ByMe.Model.UserModel;
using ByMe.View.AdminView;
using ByMe.View.UserView;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ByMe.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        //public INavigationService NavigationService;

        //public void ExecuteItemPageCommand(string type)
        //{
        //    NavigationService.NavigateTo(App.SecondPage);
        //    // App.navigation.PushAsync(new AddItem(type));
        //}


        //private string productQuantyInCart;
        //public string ProductQuantyInCart
        //{
        //    get { return productQuantyInCart; }
        //    set { productQuantyInCart = value; RaisePropertyChanged("ProductQuantyInCart"); }
        //}


        private string totalqty;
        public string Totalqty
        {
            get { return totalqty; }
            set { totalqty = value; RaisePropertyChanged("Totalqty"); }
        }

        private string totalprice;
        public string TotalPrice
        {
            get { return totalprice; }
            set { totalprice = value; RaisePropertyChanged("TotalPrice"); }
        }
        private int cartCount;
        public int CartCount
        {
            get { return cartCount; }
            set { cartCount = value; RaisePropertyChanged("CartCount"); }
        }

       
        public static ObservableCollection<ProductModel> cartList = new ObservableCollection<ProductModel>();

        public int GetQty()
        {
            int obj = cartList.Count;
            return obj;
        }

        public double GetPrice()
        {
            double price=0;
            foreach (var item in cartList)
            {
               price= item.Price +price ;
            }
            return price;
        }


        public void AddCartCount()
        {
            CartCount = cartList.Count;
        }

        #region AddCommand
        private Command addCommand;
        public Command AddCommand
        {
            get
            {
                return new Command<ProductModel>(item =>
                {
                    if (item.Qty <= 0)
                    {
                        UserDialogs.Instance.Alert("Item Not Available", null, "OK");
                    }
                    else
                    {

                        item.Qty = item.Qty-1;
                        cartList.Add(item);
                        AddCartCount();
                        UserDialogs.Instance.Alert("Added to Cart", "Success", "OK");

                    }
                });
            }

        }
        public void ExecuteAddToCartCommand(ProductModel pm)
        {
            if (pm.Qty <= 0)
            {
                UserDialogs.Instance.Alert("Item Not Available", null, "OK");
            }
            else
            {
                // pm.Qty =int.Parse(ProductQuantyInCart);         
                pm.Qty = pm.Qty - 1;
                cartList.Add(pm);
                AddCartCount();
                UserDialogs.Instance.Alert("Added to Cart", null, "OK");
            }
        }

        private Command deleteCommand;
        public Command DeleteCommand
        {
            get
            {
                return new Command<ProductModel>(item =>
                {
                    cartList.Remove(item);
                    item.Qty = item.Qty + 1;
                    AddCartCount();
                   int i= GetQty();
                    Totalqty = i.ToString();
                    double q=GetPrice();
                    TotalPrice = q.ToString();
                    UserDialogs.Instance.Alert("Deleted from cart", "Success", "OK");

                });
            }

        }


        #endregion



      

        public async Task<ObservableCollection<ProductModel>> GetProduct()
        {
            ObservableCollection<ProductModel> productList = null;


            UserDialogs.Instance.ShowLoading();
            Rest_Response rest_result = await WebService.GetData("Product/GetProductList");
            if (rest_result != null)
            {
                if (rest_result.status_code == 200)
                {
                    RootObjectProduct data = JsonConvert.DeserializeObject<RootObjectProduct>(rest_result.response_body);
                    if (data.StatusCode == 200)
                    {
                        productList = data.Result;
                    }

                }

            }
            UserDialogs.Instance.HideLoading();
            return productList;
        }




        public bool IsValidPassword(string strnIn)
        {
            try
            {
                return Regex.IsMatch(strnIn, "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

            }
            catch (RegexMatchTimeoutException)
            {
                return false;

            }
        }


        public bool IsValidEmail(string strnIn)
        {
            try
            {
                return Regex.IsMatch(strnIn, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

            }
            catch (RegexMatchTimeoutException)
            {
                return false;

            }
        }


        public bool IsValidMobile(string strIn)
        {
            int length = strIn.Length;
            if (length > 10)
                return false;
            return true;
        }











    }



}
