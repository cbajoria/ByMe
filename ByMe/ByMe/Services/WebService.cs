
using ByMe.Model.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ByMe.global;

namespace ByMe
{
    public class WebService
    {

        //public static string BaseUrl = "http://localhost:14748/api/";

        //public static string encoding = "application/x-www-form-urlencoded";
        public static string encoding = "application/json";

        //Post Data 
        public static async Task<Rest_Response> PostData(object body, string methodUrl)
        {
            Rest_Response resp = new Rest_Response();
            try
            {
                JObject json = null;
                string serialized_body = "";
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = null;

                string url = Constant.BaseUrl + methodUrl;
                serialized_body = JsonConvert.SerializeObject(body);

                //string getSerializeBody = String.Empty;
                //getSerializeBody = Tools.serialize_json(body, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });
                //serialized_body = "'" + getSerializeBody + "'";

                StringContent content = new StringContent(serialized_body, Encoding.UTF8, encoding);
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(encoding));
                response = await httpClient.PostAsync(url, content);

                var response_text = await response.Content.ReadAsStringAsync();

                json = JObject.Parse(await response.Content.ReadAsStringAsync());

                #region Build-Response-Object

                if (!string.IsNullOrEmpty(response_text))
                {
                    resp.content_length = response_text.Length;
                }
                else
                {
                    resp.content_length = 0;
                }

                resp.content_type = encoding;
                resp.response_body = response_text;
                resp.status_code = (int)response.StatusCode;

                #endregion

                #region Enumerate-Response
                bool rest_enumerate = true;
                if (rest_enumerate)
                {
                    Debug.WriteLine("rest_client response status_code " + resp.status_code + ": " + resp.content_length + "B for " + "POST" + " " + url);
                    Debug.WriteLine(resp.response_body);
                }

                #endregion

                httpClient.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return resp;
        }

        //Get Data
        public static async Task<Rest_Response> GetData(string methodUrl)
        {
            Rest_Response resp = new Rest_Response();
            try
            {
                JObject json = null;

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = null;

                string url = Constant.BaseUrl + methodUrl;
                response = await httpClient.GetAsync(url);

                var response_text = await response.Content.ReadAsStringAsync();

                json = JObject.Parse(await response.Content.ReadAsStringAsync());

                #region Build-Response-Object

                if (!string.IsNullOrEmpty(response_text))
                {
                    resp.content_length = response_text.Length;
                }
                else
                {
                    resp.content_length = 0;
                }

                resp.content_type = encoding;
                resp.response_body = response_text;
                resp.status_code = (int)response.StatusCode;

                #endregion

                #region Enumerate-Response
                bool rest_enumerate = true;
                if (rest_enumerate)
                {
                    Debug.WriteLine("rest_client response status_code " + resp.status_code + ": " + resp.content_length + "B for " + "POST" + " " + url);
                    Debug.WriteLine(resp.response_body);
                }

                #endregion

                httpClient.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return resp;
        }
    }
}
