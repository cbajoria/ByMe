using ByMe.Model;
using ByMe.View;
using ByMe.View.AdminView;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.ViewModel
{
    public class MenuItemViewModel : BaseViewModel
    {
        List<MenuItemModel> menuItems;
        public List<MenuItemModel> MenuItems
        {
            get { return menuItems; }
            set
            {
                menuItems = value;
                RaisePropertyChanged("menuItems");
            }
        }

        public MenuItemViewModel()
        {
            MenuItems = new List<MenuItemModel>
                {
                     new MenuItemModel
                    {
                        MenuItemTitle="Computer And Accessories",MenuItemIconSource="computer.png", PageType=typeof(ComputerPage)
                    },
                      new MenuItemModel
                    {
                        MenuItemTitle="Clothing",MenuItemIconSource="shirt2.png",PageType=typeof(Clothing)
                    },
                       new MenuItemModel
                    {
                        MenuItemTitle="Report",MenuItemIconSource="report.png",PageType=typeof(Report)
                    },
                        new MenuItemModel
                    {
                        MenuItemTitle="Logout",MenuItemIconSource="signout.png",PageType=typeof(LoginPage)
                    },

        };
        }
    }
}
