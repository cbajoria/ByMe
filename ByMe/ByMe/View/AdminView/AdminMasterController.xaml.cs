using Acr.UserDialogs;
using ByMe.Model;
using ByMe.View;
using ByMe.View.AdminView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using static Android.Media.Audiofx.BassBoost;

namespace ByMe.AdminView
{
    public partial class AdminMasterController : MasterDetailPage
    {
        AdminMenuPage slideOutMenu;
        public AdminMasterController()
        {
            InitializeComponent();
            slideOutMenu = new AdminMenuPage();
            Master = slideOutMenu;
            Detail =new NavigationPage(new ComputerPage()) { BarBackgroundColor = Color.FromHex("2DCA71"), BarTextColor = Color.White };
            slideOutMenu.MenuOptionListView.ItemSelected += MenuOptionListView_ItemSelected;           
        }

        private void MenuOptionListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

                IsPresented = false;//slide the menu away 
                var selectedItem = e.SelectedItem as MenuItemModel;
                if (selectedItem != null)
                {
                if (selectedItem.PageType == typeof(LoginPage))
                {

                    ActionSheetConfig sa = new ActionSheetConfig();
                    sa.Title = "Are you sure uou want to logout?";

                    sa.Add("Yes", delegate {
                        App.Current.MainPage = new NavigationPage(new LoginPage())
                        {
                            BarBackgroundColor = Color.FromHex("2DCA71"),
                            BarTextColor = Color.White
                        };
                        //App.baseUser = null;
                    });

                    sa.Add("No", delegate { sa.SetCancel(); });

                    UserDialogs.Instance.ActionSheet(sa);

                    slideOutMenu.MenuOptionListView.SelectedItem = null;
                }
                else
                {
                    //find which item was selected
                    //Pagetype property of modal helps t o load the appropriate page
                    //Page activator creates an instance from the type at runtime
                    Detail = new NavigationPage((Page)Activator.CreateInstance(selectedItem.PageType))
                    { BarBackgroundColor = Color.FromHex("2DCA71"), BarTextColor = Color.White }; 
                    slideOutMenu.MenuOptionListView.SelectedItem = null;
                }
            }

        }
        }
    }

