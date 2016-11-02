using ByMe.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.ViewModel.UserViewModel
{
   public class UserPenDrivesViewModel :BaseViewModel
    {

        private ObservableCollection<ProductModel> pendriveList;
        public ObservableCollection<ProductModel> PendriveList
        {
            get { return pendriveList; }
            set
            {
                pendriveList = value;
                RaisePropertyChanged("PendriveList");
            }
        }

        public UserPenDrivesViewModel()
        {
            Task.Run(() => Init());
        }
        public async Task Init()
        {
            PendriveList = await GetProduct();

            var query = from p in PendriveList
                        where p.Type == "Pendrive"
                        select p;
            PendriveList = new ObservableCollection<ProductModel>(query);


        }

    }
}
