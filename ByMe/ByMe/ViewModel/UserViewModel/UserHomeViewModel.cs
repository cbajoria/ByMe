using ByMe.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.ViewModel.UserViewModel
{
    public class Zoo
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
    public class UserHomeViewModel:BaseViewModel
    {
        private ObservableCollection<ProductModel> productList;
        public ObservableCollection<ProductModel> ProductList
        {
            get { return productList; }
            set
            {
                productList = value;
                RaisePropertyChanged("ProductList");
            }
        }
        public ObservableCollection<Zoo> Zoos { get; set; }
        public UserHomeViewModel()
        {
            Task.Run(() => Init());
            Zoos = new ObservableCollection<Zoo>
            {
                new Zoo
                {
                    ImageUrl ="home1",
                    Name = "dot1.png"
                },
                new Zoo
                {
                    ImageUrl ="home3",
                    Name = "dot2.png"
                },
                new Zoo
                {
                    ImageUrl ="home2",
                    Name = "dot3.png"
                }
            };
        }



      

        public async Task Init()
        {
            ProductList = await GetProduct();

            var query = (from p in ProductList
                         select p).Take(5);
            ProductList = new ObservableCollection<ProductModel>(query);


        }
    }


}




