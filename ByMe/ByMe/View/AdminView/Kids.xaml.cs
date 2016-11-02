using ByMe.ViewModel.AdminViewModel;
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
    public partial class Kids : ContentPage
    {
        private KidsViewModel kidViewModel;
        public Kids()
        {
        
            InitializeComponent();
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
            kidViewModel = App.Locator.AdminKids;
            BindingContext = kidViewModel;

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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await kidViewModel.Init();
        }
        public void itemTapped(object sender, ItemTappedEventArgs e)
        {

            this.Navigation.PushAsync(new ProductDescription(e.Item));
        }
    
        public void Add(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddItem("Kid"));
        }
    }
}
