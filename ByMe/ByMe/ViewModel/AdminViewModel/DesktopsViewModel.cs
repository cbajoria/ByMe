using ByMe.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.ViewModel.AdminViewModel
{
   public class DesktopsViewModel:BaseViewModel
    {

        private ObservableCollection<ProductModel> computerList;
        public ObservableCollection<ProductModel> ComputerList
        {
            get { return computerList; }
            set
            {
                computerList = value;
                RaisePropertyChanged("ComputerList");
            }
        }

        public DesktopsViewModel()
        {
            Task.Run(() => Init());
        }
        public async Task Init()
        {
            ComputerList = await GetProduct();

            var query = from p in ComputerList
                        where p.Type == "Computer"
                        select p;
            ComputerList = new ObservableCollection<ProductModel>(query);


        }
    }
}
