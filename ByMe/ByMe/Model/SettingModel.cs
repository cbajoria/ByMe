using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.Model
{
    public class SettingModel
    {
        public UserModel.UserModel userModel { get; set; }
        public bool IsNotFirstTime { get; set; }
    }
}
