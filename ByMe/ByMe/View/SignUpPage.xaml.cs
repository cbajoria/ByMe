using Acr.UserDialogs;
using ByMe.View.UserView;
using ByMe.ViewModel;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View
{
    public partial class SignUpPage : ContentPage
    {
        byte[] resizedImage;
        private SignUpPageViewModel viewModel;

        public SignUpPage()
        {
            InitializeComponent();
            viewModel = App.Locator.SignUp;
            BindingContext = viewModel;
            // btnSubmit.Clicked += BtnSubmit_Clicked;
            Title = "SignUp";

        }

        private void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            if (txtFirstName.Text == null || txtLastName.Text == null || txtMob.Text == null || txtPassword.Text == null || txtConPassword.Text == null)
            {
                DisplayAlert("Alert", "Fill all Fields", "Cancel");
            }
            else
            {

                if (txtPassword.Text != null && txtPassword.Text != txtConPassword.Text)
                {
                    DisplayAlert("Alert", "Password and Confirm Password did not match", "Cancel");
                }
                else
                {

                    if (txtEmail.TextColor == Color.Red)
                    {
                        DisplayAlert("Alert", "Email is incorrect", "Cancel");
                    }
                    else
                    {

                        if (txtMob.TextColor == Color.Red)
                        {
                            DisplayAlert("Alert", "Mobile No. is incorrect", "Cancel");
                        }
                        else
                        {
                            App.Current.MainPage = new UserMasterController();

                        }

                    }
                }
            }

        }

        public void goBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public void btnImageCalled(object sender, EventArgs e)
        {
            ActionSheetConfig sa = new ActionSheetConfig();
            sa.Title = "Choose Image";

            sa.Add("Camera", delegate { ChooseImageCamera(); });

            sa.Add("Gallery", delegate { ChooseImageGallery(); });

            sa.SetCancel();
            UserDialogs.Instance.ActionSheet(sa);
        }

        async void ChooseImageCamera()
        {
            try
            {
                if (!CrossMedia.Current.IsCameraAvailable)
                {
                    await ((Page)Parent).DisplayAlert("No Camera", "No camera available", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = Guid.NewGuid().ToString() + ".jpeg"//default name or random no using guid
                });

                if (file == null)
                    return;
                //var image = new CustomeImage();//add image at runtitme
                imageName.Source = ImageSource.FromStream(() =>  //we bind memorystream with source
                {
                    var stream = file.GetStream();
                    byte[] imageData;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        stream.CopyTo(ms); //convert stream to memoryStream
                        imageData = ms.ToArray(); //then convert the memoryStream to ByteArray

                    }
                    //resize is done for memory optimization to reduce its pixel and size
                    var data = DependencyService.Get<IImageResizer>();
                    if (data != null)
                    {

                        resizedImage = data.ResizeImage(imageData, 450, 200);
                    }
                    if (resizedImage != null)
                    {
                        viewModel._Base64_Img = Convert.ToBase64String(resizedImage);
                        System.Diagnostics.Debug.WriteLine(viewModel._Base64_Img);//show the value at runtime
                    }

                    return new MemoryStream(resizedImage);
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.Message.ToString(), "cancel");
            }
            GC.Collect();
        }
        async void ChooseImageGallery()
        {
            try
            {
                if (!CrossMedia.Current.IsPickPhotoSupported) //this checks the format 
                {
                    //if not supported give display alert and get out
                    await ((Page)Parent).DisplayAlert("No Image", "No images available on Gallery", "Ok");
                    //Type casting is done with parent 
                    return;
                }
                var file = await CrossMedia.Current.PickPhotoAsync();//open gallery with photos that can be picked

                if (file == null)//if slected file is null
                    return;

                // var image = new CustomeImage();//add image at runtitme
                imageName.Source = ImageSource.FromStream(() =>  //we bind memorystream with source
                    {
                        var stream = file.GetStream();
                        byte[] imageData;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            stream.CopyTo(ms); //convert stream to memoryStream
                            imageData = ms.ToArray(); //then convert the memoryStream to ByteArray

                        }
                        //resize is done for memory optimization to reduce its pixel and size
                        var data = DependencyService.Get<IImageResizer>();
                        if (data != null)
                        {
                            resizedImage = data.ResizeImage(imageData, 450, 200);
                        }
                        if (resizedImage != null)
                        {
                            viewModel._Base64_Img = Convert.ToBase64String(resizedImage);
                            System.Diagnostics.Debug.WriteLine(viewModel._Base64_Img);//show the value at runtime
                        }
                        return new MemoryStream(resizedImage);
                    });

                

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.Message.ToString(), "cancel");
            }


            GC.Collect();
        }


    }



}



