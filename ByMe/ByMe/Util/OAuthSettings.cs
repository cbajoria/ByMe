using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.Util
{
    public class OAuthSettings
    {
        public string AuthorizeUrl { get; private set; }
        public string ClientId { get; private set; }
        public string RedirectUrl { get; private set; }
        public string Scope { get; private set; }

        public OAuthSettings(string clientId, string scope, string authorizeUrl, string redirectUrl)
        {
            this.ClientId = clientId;
            this.Scope = scope;
            this.AuthorizeUrl = authorizeUrl;
            this.RedirectUrl = redirectUrl;
        }
    }
}
