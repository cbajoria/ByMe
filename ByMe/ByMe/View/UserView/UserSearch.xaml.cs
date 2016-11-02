using ByMe.Model.UserModel;
using ByMe.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View.UserView
{
    public partial class UserSearch : ContentPage
    {
        private UserSearchViewModel viewModel;
        public UserSearch()
        {
            InitializeComponent();
            viewModel = App.Locator.UserSearch;
            BindingContext = viewModel;
        }
        public void goBack(object sender,EventArgs e)
        {
            Navigation.PopAsync();
        }

        public async void  searchTextChanged(object sender,EventArgs e)
        {


          await  viewModel.Init();
          var list=  (from r in viewModel.PList
             where r.Name.ToLowerInvariant().Contains(txtSearchBar.Text.ToLowerInvariant()) ||r.Type.ToLowerInvariant().Contains(txtSearchBar.Text.ToLowerInvariant())
             select r).ToList();
            viewModel.PList = new ObservableCollection<ProductModel>(list);
            
        }
        public void itemTapped(object sender, ItemTappedEventArgs e)
        {

            this.Navigation.PushAsync(new UserProductDescription(e.Item));
        }
        public void cart_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserCart());
        }
    }
}
