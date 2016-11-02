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

using Android.Graphics;
using Xamarin.Forms;
using System.IO;
using ByMe.Droid;

[assembly:Dependency(typeof(ImageResizer))]

namespace ByMe.Droid
{
    public class ImageResizer : IImageResizer
    {
        #region
        public byte[] ResizeImage(byte[] imageData, float width, float height)
        {

            //load the bitmap
            Bitmap originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);//0 is percantage of compression

            // to set in particular ratio
            float fileHeight = originalImage.Height;
            float fileWidth = originalImage.Width;

            //var Height = originalImage.Height;
            //var Width = originalImage.Width;

            //if (Height > Width)
            //{
            //    fileHeight = height;
            //    float wid = Height / height;
            //    fileWidth = Width / wid;
            //}else
            //{
            //    fileHeight = width;
            //    float wid = Width / width;
            //    fileWidth = Height / wid;
            //}


            Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage,(int) fileWidth,(int) fileHeight, false);

            using(MemoryStream ms=new MemoryStream())//convert bitmap to memorystream
            {
                resizedImage.Compress(Bitmap.CompressFormat.Png, 100, ms);
                return ms.ToArray();
            }

            #endregion
        }
    }
}