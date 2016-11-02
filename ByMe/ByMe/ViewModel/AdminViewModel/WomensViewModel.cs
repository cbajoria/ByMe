using ByMe.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.ViewModel.AdminViewModel
{
    public class WomensViewModel :BaseViewModel
    {
        private ObservableCollection<ProductModel> womenList;
        public ObservableCollection<ProductModel> WomenList
        {
            get { return womenList; }
            set
            {
                womenList = value;
                RaisePropertyChanged("WomenList");
            }
        }

        public WomensViewModel()
        {
            Task.Run(() => Init());
        }
        public async Task Init()
        {
            WomenList = await GetProduct();

            var query = from p in WomenList
                        where p.Type == "Women"
                        select p;
            WomenList = new ObservableCollection<ProductModel>(query);


        }
    }
}
