using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace vippoks
{
    public sealed class ClientApiClient : BaseApiClient
    {
        private string CLIENT_API_URL = API_BASE_URL + "/clients";
        
        public ApiDefaultResponse Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(CLIENT_API_URL + @"/get");
            
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;
            string res = this.makeRequest(request);
            return JsonConvert.DeserializeObject<ApiDefaultResponse>(res);
        }

        public void Delete(int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(CLIENT_API_URL + @"/delete/" + id);
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;
            this.makeRequest(request);
        }

        public void UpdateById(int id, string name, string surname, string patronymic, string phone, string email)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(CLIENT_API_URL + @"/update/" + id);
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_POST;

            object clientDataRequest = new { name, surname, patronymic, phone, email};
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(clientDataRequest));
            }

            this.makeRequest(request);
        }
        
        public void Create(string name, string surname, string patronymic, string phone, string email)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(CLIENT_API_URL + @"/create");
            
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_POST;

            object clientDataRequest = new {name, surname, patronymic, phone, email};
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(clientDataRequest));
            }

            this.makeRequest(request);
        }
    }
}