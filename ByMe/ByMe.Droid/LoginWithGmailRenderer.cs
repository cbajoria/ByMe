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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;
using ByMe.View;
using ByMe.Droid;
using ByMe.ViewModel;
using System.Json;
using Newtonsoft.Json;
using ByMe.global;
using Acr.UserDialogs;

[assembly: ExportRenderer(typeof(LoginWithGmail), typeof(LoginWithGmailRenderer))]

namespace ByMe.Droid
{
   public class LoginWithGmailRenderer :PageRenderer
    {
        LoginWithGmailViewModel viewModel;
        OAuth2Authenticator auth;
        //private static readonly TaskScheduler UIScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            viewModel = new LoginWithGmailViewModel();

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = this.Context as Activity;

            if (Constant.IsGoogleLogin)
            {
                auth = new OAuth2Authenticator(
                //clientId: "858089811668-dk50ujvabh8aqr3ek5r60q24p1adep97.apps.googleusercontent.com",
               clientId: "380694676532-barrtug4jpe6gcmhk7a02odeos1bvnk0.apps.googleusercontent.com",
                                scope: "https://www.googleapis.com/auth/userinfo.email",    // The scopes for the particular API you're accessing. The format for this will vary by API.
                                authorizeUrl: new Uri("https://accounts.google.com/o/oauth2/auth"),   // the auth URL for the service
                                redirectUrl:new Uri( "https://www.googleapis.com/plus/v1/people/me"));   // the redirect URL for the service        


                auth.Completed += async (sender, eventArgs) =>
                {
                    if (eventArgs.IsAuthenticated)
                    {
                        var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                        UserDialogs.Instance.ShowLoading();
                        //App.Instance.SuccessfulLoginAction.Invoke();
                        // Use eventArgs.Account to do wonderful things
                        App.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);

                        // Now that we're logged in, make a OAuth2 request to get the user's info.
                        var request = new OAuth2Request("GET", new Uri("https://www.googleapis.com/oauth2/v2/userinfo"), null, eventArgs.Account);
                        //var request = new OAuth2Request("GET", new Uri(Constants.UserInfoUrl), null, e.Account);
                        var response = await request.GetResponseAsync();
                        if (response != null)
                        {
                            string userJson = response.GetResponseText();//All details of User in Json format which can be used further(can be stored in Manager and shown in view).
                            var obj = JsonValue.Parse(userJson);
                            viewModel.FirstName = (string)obj["given_name"];
                            viewModel.LastName = (string)obj["family_name"];
                            viewModel.Email = (string)obj["email"];
                            viewModel._Base64_Img = (string)obj["picture"];

                            if (!string.IsNullOrEmpty(accessToken))
                            {
                                viewModel.AccessToken = accessToken;
                                // viewModel.GoogleCommand.Execute(this);
                            }
                            //App.Instance.UserName = viewModel.FirstName + " " + viewModel.LastName;

                            App.baseUser.FirstName = viewModel.FirstName;
                            App.baseUser.LastName = viewModel.LastName;
                            App.baseUser.EmailId = viewModel.Email;
                            App.baseUser.UserImage = viewModel._Base64_Img;
                            App.baseUser.AccessToken = viewModel.AccessToken;
                             Constant.IsGoogleLogin = false;
                            App.Instance.SuccessfulLoginAction.Invoke();
                           

                           
                        }
                        else
                        {
                            // The user cancelled
                        }
                    }else
                    {
                        Constant.IsGoogleLogin = false;
                    }

                };
            }
            else if (Constant.IsFacebookLogin)
            {
                auth = new OAuth2Authenticator(
                 clientId: "384018465086414",
                 scope: "email",
                 authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                 redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

                //auth.AllowCancel = allowCancel;

                auth.Completed += async (sender, eventArgs) =>
                {
                    if (eventArgs.IsAuthenticated)
                    {
                        var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                        UserDialogs.Instance.ShowLoading();
                        //App.Instance.SuccessfulLoginAction.Invoke();
                        // Use eventArgs.Account to do wonderful things
                        App.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);

                        // Now that we're logged in, make a OAuth2 request to get the user's info.
                        var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me/"), null, eventArgs.Account);
                        //var request = new OAuth2Request("GET", new Uri(Constants.UserInfoUrl), null, e.Account);
                        var response = await request.GetResponseAsync();
                        if (response != null)
                        {
                            string userJson = response.GetResponseText();//All details of User in Json format which can be used further(can be stored in Manager and shown in view).
                            var obj = JsonValue.Parse(userJson);

                            viewModel.FirstName = (string)obj["first_name"];
                            viewModel.LastName = (string)obj["last_name"];
                            viewModel.Email = (string)obj["email"];
                            viewModel._Base64_Img = "https://graph.facebook.com/" + (string)obj["id"] + "/picture";

                            if (!string.IsNullOrEmpty(accessToken))
                            {
                                viewModel.AccessToken = accessToken;
                                // viewModel.GoogleCommand.Execute(this);
                            }

                            //App.Instance.UserName = viewModel.FirstName + " " + viewModel.LastName;
                            App.baseUser.FirstName = viewModel.FirstName;
                            App.baseUser.LastName = viewModel.LastName;
                            App.baseUser.EmailId = viewModel.Email;
                            App.baseUser.UserImage = viewModel._Base64_Img;
                            App.baseUser.AccessToken = viewModel.AccessToken;
                            Constant.IsFacebookLogin = false;
                            App.Instance.SuccessfulLoginAction.Invoke();
              
                        }
                        else
                        {
                            // The user cancelled
                        }
                    }
                    else
                    {
                        Constant.IsFacebookLogin = false;
                    }
                };
            }

            activity.StartActivity(auth.GetUI(activity));
        }
    }


}

  