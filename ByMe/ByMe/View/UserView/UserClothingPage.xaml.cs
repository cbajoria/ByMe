using ByMe.ViewModel.UserViewModel;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View.UserView
{

    public partial class UserClothingPage : TabbedPage
    {
        private UserClothingPageViewModel viewModel;
        public UserClothingPage()
        {
            InitializeComponent();
            viewModel = App.Locator.ClothingTab;
            BindingContext = viewModel;
            
        }

        public void cart_Clicked(object sender,EventArgs e)
        {
            Navigation.PushAsync(new UserCart());
        }
        public void searchClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserSearch());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
           
        }

        






    }
}
