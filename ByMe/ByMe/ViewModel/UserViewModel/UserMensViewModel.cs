using ByMe.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.ViewModel.UserViewModel
{
   public class UserMensViewModel :BaseViewModel
    {
        private ObservableCollection<ProductModel> menList;
        public ObservableCollection<ProductModel> MenList
        {
            get { return menList; }
            set
            {
                menList = value;
                RaisePropertyChanged("MenList");
            }
        }

        public UserMensViewModel()
        {
            Task.Run(() => Init());
        }
        public async Task Init()
        {
            MenList = await GetProduct();

            var query = from p in MenList
                        where p.Type == "Men"
                        select p;
            MenList = new ObservableCollection<ProductModel>(query);


        }
    }
}
