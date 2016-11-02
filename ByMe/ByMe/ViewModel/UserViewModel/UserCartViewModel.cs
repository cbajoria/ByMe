using ByMe.Model.UserModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.ViewModel.UserViewModel
{
    public class UserCartViewModel : BaseViewModel
    {
        ObservableCollection<ProductModel> ucartList;

        public ObservableCollection<ProductModel> UCartList
        {
            get { return ucartList; }
            set
            {
                ucartList = value;
                RaisePropertyChanged("UCartList");
            }
        }



        public UserCartViewModel()
        {
            Init();
        }
        public void Init()
        {
            UCartList = cartList;
        }



        }
}
