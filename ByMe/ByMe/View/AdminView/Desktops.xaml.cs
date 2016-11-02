using ByMe.ViewModel.AdminViewModel;
using ByMe.ViewModel.UserViewModel;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View.AdminView
{
    public partial class Desktops : ContentPage
    {

        private DesktopsViewModel desktopViewModel;
        public Desktops()
        {
            InitializeComponent();
            desktopViewModel = App.Locator.AdminDesktop;
            BindingContext = desktopViewModel;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
            await desktopViewModel.Init();
        }
        private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (!e.IsConnected)
            {
                stkNoConnection.IsVisible = true;
                stk.IsVisible = false;
            }
            else
            {
                stkNoConnection.IsVisible = false;
                stk.IsVisible = true;
            }
        }


        public void Add(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddItem("Computer"));
        }
        public void itemTapped(object sender, ItemTappedEventArgs e)
        {

            this.Navigation.PushAsync(new ProductDescription(e.Item));
        }

    }
}
