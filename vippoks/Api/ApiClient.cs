using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace vippoks
{
    public class ApiClient
    {
        private const string API_BASE_URL = "http://213.80.189.122:6782/api";
        

        public bool Auth(string login, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API_BASE_URL + @"/auth");
            request.Method = "POST";
            request.ContentType = "application/json";
            
            object authRequest = new {
                login = login,
                password = password
            };
            
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(authRequest));
            }

            string res = makeRequest(request);
            api_default auth = JsonConvert.DeserializeObject<api_default>(res);
            
            
            if (!string.IsNullOrEmpty(auth.response.ToString()))
            {
                return auth.response.Equals(true);
            }

            return false;
        }

        private string makeRequest(HttpWebRequest request)
        {
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Что-то пошло не так. Текст ошибки: " + e.Message);
                return "";
            }
           
        }

    }
}