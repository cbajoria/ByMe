using ByMe.global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.Model.UserModel
{
   public class UserCartModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public string Desc { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public string ModifyDate { get; set; }
        public string ProductImage { get { return string.Format(Constant.BaseProductImageUrl + Image); } }
    }
}
