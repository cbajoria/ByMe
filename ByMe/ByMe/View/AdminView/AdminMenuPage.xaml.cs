using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.AdminView
{
    public partial class AdminMenuPage : ContentPage
    {
        public ListView MenuOptionListView //expose list to public i.e. MenuController
        {
            get { return menuOptionListView; }
        }
        public AdminMenuPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.Menu;
        }
    }
}
