using Acr.UserDialogs;
using ByMe.global;
using ByMe.ViewModel.UserViewModel;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View.UserView
{
    public partial class UserEditProfile : ContentPage
    {
        byte[] resizedImage;
        private UserEditProfileViewModel editProfileViewModel;
        
        public UserEditProfile()
        {
            InitializeComponent();
            editProfileViewModel = App.Locator.UserEditProfile;
            BindingContext = editProfileViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.baseUser.AccessToken == null)
            {
                imageName.Source = Constant.BaseUserImageUrl + App.baseUser.UserImage;
                //editProfileViewModel._Base64_Img = Constant.BaseUserImageUrl + App.baseUser.UserImage;
            }
            else
            {
                imageName.Source = App.baseUser.UserImage;
            }
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
                        editProfileViewModel._Base64_Img = Convert.ToBase64String(resizedImage);
                        System.Diagnostics.Debug.WriteLine(editProfileViewModel._Base64_Img);//show the value at runtime
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
                        editProfileViewModel._Base64_Img = Convert.ToBase64String(resizedImage);
                        System.Diagnostics.Debug.WriteLine(editProfileViewModel._Base64_Img);//show the value at runtime
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

