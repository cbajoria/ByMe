using Acr.UserDialogs;
using ByMe.AdminView;
using ByMe.global;
using ByMe.Model.Response;
using ByMe.Model.UserModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ByMe.ViewModel.AdminViewModel
{
    public class ProductDescriptionViewModel:BaseViewModel
    {
        #region property declaration

        private ProductModel product;
        public ProductModel Product
        {
            get { return product; }
            set { product = value; RaisePropertyChanged("Product"); }
        }
        #endregion

        #region Command
        private Command deleteItemCommand;
        public Command DeleteItemCommand
        {
            get
            {
                return deleteItemCommand ?? (deleteItemCommand = new Command(() => ExecuteDeleteItemCommand()));
            }
        }
       

        #endregion

        private async void ExecuteDeleteItemCommand()
        {
            UserDialogs.Instance.ShowLoading();
            Rest_Response rest_result = await WebService.PostData(product, "Product/DeleteProduct");
            if (rest_result != null)
            {
                if (rest_result.status_code == 200)
                {
                    RootObjectProduct data = JsonConvert.DeserializeObject<RootObjectProduct>(rest_result.response_body);
                    if (data.StatusCode == 200)
                    {
                        var userobj = data.Result;
                      //  await GetProduct();
                        UserDialogs.Instance.Alert("Object Deleted", null, "OK");
                        App.Current.MainPage = new AdminMasterController();
                    }

                }
                else
                {
                    UserDialogs.Instance.Alert("Cannot be deleted",null,"ok");
                }

            }
            UserDialogs.Instance.HideLoading();
        }

      


        }





    }
