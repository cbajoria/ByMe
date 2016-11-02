using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe
{
   public interface IImageResizer
    {
        byte[] ResizeImage(byte[] imageData, float width, float height);


    }


}
