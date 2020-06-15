using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace vippoks
{
    public sealed class AuthApiClient : BaseApiClient
    {
        public bool Auth(string login, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API_BASE_URL + @"/auth");
            request.Method = METHOD_POST;
            request.ContentType = CONTENT_TYPE;
            
            object authRequest = new {login, password};
            
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(authRequest));
            }

            string res = makeRequest(request);
            if (string.IsNullOrEmpty(res))
            {
                return false;
            }
            
            ApiDefaultResponse auth = JsonConvert.DeserializeObject<ApiDefaultResponse>(res);
            
            if (!string.IsNullOrEmpty(auth.response.ToString()))
            {
                return auth.response.Equals(true);
            }

            return false;
        }
    }
}