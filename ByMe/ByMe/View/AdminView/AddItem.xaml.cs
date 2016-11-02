using ByMe.ViewModel.AdminViewModel;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ByMe.View.AdminView
{
    public partial class AddItem : ContentPage
    {
        byte[] resizedImage;
        private AddItemViewModel addViewModel;

        public AddItem(string type)
        {
            InitializeComponent();

            addViewModel = App.Locator.AddItem;
            BindingContext = addViewModel;
            addViewModel.Type = type;
        }

        public void btnImageCalled(object sender, EventArgs e)
        {

            ChooseImageGallery();
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
                        addViewModel.ItemImage = Convert.ToBase64String(resizedImage);
                        System.Diagnostics.Debug.WriteLine(addViewModel.ItemImage);//show the value at runtime
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
