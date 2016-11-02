using ByMe.Model.UserModel;
using ByMe.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View.UserView
{
    public partial class OrderPlaced : ContentPage
    {
        private OrderPlacedViewModel viewModel;
        public OrderPlaced()
        {
            InitializeComponent();
            viewModel = App.Locator.OrderPlaced;
            BindingContext = viewModel;
        }

        public async void HomeClicked(object sender,EventArgs e)
        {
            App.Current.MainPage = new UserMasterController();
        }


    }
}
