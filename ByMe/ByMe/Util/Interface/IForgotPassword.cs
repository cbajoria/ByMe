using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.Util.Interface
{
    public interface IForgotPassword
    {
        void mailPassword(string email);
    }
}
