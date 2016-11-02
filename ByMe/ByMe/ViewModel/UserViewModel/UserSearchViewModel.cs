using ByMe.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.ViewModel.UserViewModel
{
    public class UserSearchViewModel:BaseViewModel
    {
        private ObservableCollection<ProductModel> plist;
        public ObservableCollection<ProductModel> PList
        {
            get { return plist; }
            set
            {
                plist = value;
                RaisePropertyChanged("PList");
            }
        }

        public UserSearchViewModel()
        {
           // Task.Run(() => Init());
        }
        public async Task Init()
        {
            PList = await GetProduct();



        }
    }
}
