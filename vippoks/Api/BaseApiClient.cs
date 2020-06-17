using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace vippoks
{
    public class BaseApiClient
    {
        protected const string API_BASE_URL = "http://213.80.188.97:6782/api";
        protected const string CONTENT_TYPE = "application/json";
        protected const string METHOD_POST = "POST";
        protected const string METHOD_GET = "GET";
        
        
        protected string makeRequest(HttpWebRequest request)
        {
            try
            {
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEnd();
            }
            catch (WebException webException)
            {
                MessageBox.Show(webException.Status == WebExceptionStatus.Timeout
                    ? @"Что-то пошло не так! Сообщение: Время ожидания ответа от сервера истекло."
                    : $@"Что-то пошло не так! Сообщение: {webException.Message}");

                return "";
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
                return "";
            }
        }
    }
    
    
}