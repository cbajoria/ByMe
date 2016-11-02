using ByMe.Helpers;
using ByMe.Model;
using ByMe.Model.UserModel;
using ByMe.Util;
using ByMe.View;
using ByMe.View.AdminView;
using ByMe.View.UserView;
using ByMe.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ByMe
{
    public class App : Application
    {
        public static UserModel baseUser = new UserModel();
        public static UserAddress address = new UserAddress();
        static App _Instance;
        static object _SyncRoot = new Object();
        public OAuthSettings OAuthSettings { get; private set; }



       



        public static App Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_SyncRoot)
                    {
                        _Instance = new App();
                        _Instance.OAuthSettings =
                            new OAuthSettings(
                                clientId: "380694676532-barrtug4jpe6gcmhk7a02odeos1bvnk0.apps.googleusercontent.com",
                                scope: "https://www.googleapis.com/auth/userinfo.email",    // The scopes for the particular API you're accessing. The format for this will vary by API.
                                authorizeUrl: "https://accounts.google.com/o/oauth2/auth",   // the auth URL for the service
                                redirectUrl: "https://www.googleapis.com/plus/v1/people/me");   // the redirect URL for the service        

                    }
                }
                return _Instance;
            }
        }
        
        string _Token;
        public string Token
        {
            get
            {
                return _Token;
            }
        }

        public bool IsAuthenticated
        {
            get { return !string.IsNullOrWhiteSpace(_Token); }
        }

        public void SaveToken(string token)
        {
            _Token = token;
            //broadcast a message that authentication is successful
            MessagingCenter.Send<App>(this, "Authenticated");

        }
        public Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() => App.Current.MainPage = new UserMasterController());
            }
        }


        private readonly static ViewModelLocator _locator = new ViewModelLocator();
        public static ViewModelLocator Locator
        {
            get { return _locator; }
        }

        public const string FirstPage = "Laptops";
        public const string SecondPage = "AddItem";

        public static SettingModel setting_Model = new SettingModel();

        public App()
        {
            //var nav = new NavigationService();

            //nav.Configure(FirstPage, typeof(Laptops));
            //nav.Configure(SecondPage, typeof(AddItem));

            //SimpleIoc.Default.Register<INavigationService>(() => nav);
            //var firstPage = new NavigationPage(new CarousalPageView());
            //nav.Initialize(firstPage);


            ////SimpleIoc.Default.Register<INavigationService>(() => nav);


            //MainPage = firstPage;


            // The root page of your application
            //check that the user is first time user or not
            //if first time user go on carousal page
            //otherwise go on login page
            setting_Model = JsonConvert.DeserializeObject<SettingModel>(Settings.GeneralSettings);
            if (setting_Model != null)
            {
                if (setting_Model.IsNotFirstTime)
                {
                    MainPage = new NavigationPage(new LoginPage())
                    { BarBackgroundColor = Color.FromHex("2DCA71"), BarTextColor = Color.White };
                }
                else
                {
                    MainPage = new NavigationPage(new CarousalPageView());
                }

            }
            else
            {
                setting_Model = new SettingModel();//as first time deserialisation will make setting model as null that why we have to initialize it
                setting_Model.IsNotFirstTime = true;
                var obj = JsonConvert.SerializeObject(setting_Model);
                Settings.GeneralSettings = obj; //again set the seeting model in settingkey hence next time set will not be null
                MainPage = new CarousalPageView();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
