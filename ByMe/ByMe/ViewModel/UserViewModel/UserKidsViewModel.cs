using ByMe.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.ViewModel.UserViewModel
{
   public class UserKidsViewModel :BaseViewModel
    {
        private ObservableCollection<ProductModel> kidList;
        public ObservableCollection<ProductModel> KidList
        {
            get { return kidList; }
            set
            {
                kidList = value;
                RaisePropertyChanged("KidList");
            }
        }

        public UserKidsViewModel()
        {
            Task.Run(() => Init());
        }
        public async Task Init()
        {
            KidList = await GetProduct();

            var query = from p in KidList
                        where p.Type == "Kid"
                        select p;
            KidList = new ObservableCollection<ProductModel>(query);


        }
    }
}
