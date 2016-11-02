using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace ByMe.Droid
{
    //main launcher true for making it first scree
    //theme for styling
    //configuration is used to handle screen size and rotation mode
    //@ will search where is style in whole application
    [Activity(MainLauncher = true, Theme = "@style/Theme.Splash", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //intent is used to perform some operation like going from one activity to another activity
            //context is known as environment in android
            //context has activity
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            //its a lifecycle part of activity
            //it will get deleted...activity will get end..back button will cant take to this page anymore
            Finish();
        }
    }
}