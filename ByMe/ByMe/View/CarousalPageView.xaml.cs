using ByMe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View
{
    public partial class CarousalPageView : CarouselPage
    {
        public CarousalPageView()
        {
            InitializeComponent();
            BindingContext = App.Locator.Carousal;
            ItemsSource = CarousalViewModel.listOfCarousal;
        }
        public void SkipCalled(object sender,EventArgs e)
        {
           App.Current.MainPage= new NavigationPage(new LoginPage())
           { BarBackgroundColor = Color.FromHex("2DCA71"), BarTextColor = Color.White };


        }
    }
}
