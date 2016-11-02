using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByMe.Model.Response
{
    public partial class Tools
    {
        public static string serialize_json(object obj)
        {
            return serialize_json(obj, new JsonSerializerSettings { });
        }

        public static string serialize_json(object obj, JsonSerializerSettings serializeSettings)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None, serializeSettings);
                return json;
            }
            catch (Exception)
            {
                Debug.WriteLine("serialize_json unable to serialize JSON string");
                throw new Exception();
            }
        }
    }
}
