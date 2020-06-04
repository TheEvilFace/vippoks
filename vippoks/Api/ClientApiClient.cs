using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using vippoks.Api.Entities;

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
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(CLIENT_API_URL + $@"/{id}/delete");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;
            this.makeRequest(request);
        }

        public void UpdateById(int id, string name, string surname, string patronymic, string phone, string email)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(CLIENT_API_URL + $@"/{id}/update");
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

        public List<ClientEntity> GetClients()
        {
            List<ClientEntity> сlientEntities = new List<ClientEntity>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(CLIENT_API_URL + @"/get");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;

            string res = this.makeRequest(request);
            ApiDefaultResponse defaultResponse = JsonConvert.DeserializeObject<ApiDefaultResponse>(res);

            JArray innerResponse = (JArray)defaultResponse.response;
            JObject[] types = innerResponse.Select(jv => (JObject)jv).ToArray();

            foreach (JObject type in types)
            {
                сlientEntities.Add(JsonConvert.DeserializeObject<ClientEntity>(type.ToString()));
            }

            return сlientEntities;
        }
    }
}