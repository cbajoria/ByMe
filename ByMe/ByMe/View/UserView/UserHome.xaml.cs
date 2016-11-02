using ByMe.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View.UserView
{
    public partial class UserHome : ContentPage
    {
        private UserHomeViewModel viewModel;
        public UserHome()
        {
            InitializeComponent();
            viewModel = App.Locator.UserHome;
            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.AddCartCount();
            txtWelcome.Text = App.baseUser.FirstName;

        }

        public void searchClicked(object sender,EventArgs e)
        {
            Navigation.PushAsync(new UserSearch());
        }
        public void cart_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserCart());
        }
        public void OnTapped(object sender,EventArgs e)
        {
            Navigation.PushAsync(new UserClothingPage());
        }
        public void clothingClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserClothingPage());
        }
        public void ElectronicClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserComputer());
        }
        public void OnTappedE(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserComputer());
        }
    }
}
