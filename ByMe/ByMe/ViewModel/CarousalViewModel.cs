using ByMe.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ByMe.ViewModel
{
    public class CarousalViewModel : BaseViewModel
    {
      public static  List<CarousalModel> listOfCarousal;

        public CarousalViewModel()
        {
            listOfCarousal = new List<CarousalModel>()
            {
                new CarousalModel() { image="icon.png",heading="Your e-commerce store on mobile",detail="Your photos are organized and searchable by the places and things in them",bulletImage="first.png",skipButton="Skip",startButton="    "},
                new CarousalModel() {image="carousal.png",heading="Find your Favorite Things faster",detail="Never worry about running out of space on your phone again. ",bulletImage="second.png",skipButton="Skip",startButton="    " },
                new CarousalModel() {image="carousal1.png",heading="Easy to purchase",detail="Pool photos with friends and family using shared albums",bulletImage="third.png",skipButton="Start",startButton="    " },

            };

        }
    }
}
