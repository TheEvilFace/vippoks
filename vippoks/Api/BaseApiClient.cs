using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace vippoks
{
    public class BaseApiClient
    {
        protected const string API_BASE_URL = "http://213.80.189.122:6782/api";
        protected const string CONTENT_TYPE = "application/json";
        protected const string METHOD_POST = "POST";
        protected const string METHOD_GET = "GET";
        
        
        protected string makeRequest(HttpWebRequest request)
        {
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEnd();
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
                return "";
            }
           
        }
    }
}