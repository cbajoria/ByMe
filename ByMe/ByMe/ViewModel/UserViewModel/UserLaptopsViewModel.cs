using ByMe.Model.UserModel;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ByMe.ViewModel.UserViewModel
{
    public class UserLaptopsViewModel : BaseViewModel
    {

       private ObservableCollection<ProductModel> laptopList;
        public ObservableCollection<ProductModel> LaptopList
        {
            get { return laptopList; }
            set
            {
                laptopList = value;
                RaisePropertyChanged("LaptopList");
            }
        }

       public UserLaptopsViewModel()
        {
           Task.Run(()=> Init());
        }
        public async Task Init()
        {
            LaptopList = await GetProduct();

            var query = from p in LaptopList
                        where p.Type=="Laptop"
                        select p;
            LaptopList= new ObservableCollection<ProductModel>(query);


        }
      
    //    public LaptopsViewModel(INavigationService navigationService)
    //    {
    //        this.NavigationService = navigationService;
    //    }
    //    private Command itemPageCommand;
    //    public Command ItemPageCommand
    //    {
    //        get
    //        {
    //            return itemPageCommand ?? (itemPageCommand = new Command(() => ExecuteItemPageCommand("Laptops")));
    //        }
    //    }

}
}
