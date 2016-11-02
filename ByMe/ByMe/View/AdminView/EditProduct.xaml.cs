using ByMe.global;
using ByMe.Model.UserModel;
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

    public partial class EditProduct : ContentPage
    {
        byte[] resizedImage;
        ProductModel product;
        private EditProductViewModel viewModel;
        public EditProduct(ProductModel pm)
        {
            InitializeComponent();
            viewModel = App.Locator.AdminEditProduct;
            viewModel.Product = pm;
            product = pm;
            BindingContext = viewModel;

        }
        protected override void OnAppearing()
        {
            
            base.OnAppearing();
            imageName.Source =Constant.BaseProductImageUrl+product.Image;
            txtName.Text = product.Name;
            txtPrice.Text = product.Price.ToString();
            txtQuantity.Text = product.Qty.ToString();
            txtDescription.Text = product.Desc;
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
                        viewModel.ItemImage = Convert.ToBase64String(resizedImage);
                        System.Diagnostics.Debug.WriteLine(viewModel.ItemImage);//show the value at runtime
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
