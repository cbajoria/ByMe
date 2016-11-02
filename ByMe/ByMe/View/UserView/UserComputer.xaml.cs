using ByMe.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View.UserView
{
    public partial class UserComputer : TabbedPage
    {
       //rivate UserComputerViewModel cviewModel;
        public UserComputer()
        {
            InitializeComponent();
          //cviewModel = App.Locator.ComputerTab;
          //BindingContext = cviewModel;
        }
        //public void cart_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new UserCart());
        //}
        public void searchClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserSearch());
        }



    }
}
