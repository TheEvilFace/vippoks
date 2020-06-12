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
    public sealed class RealtorApiClient : BaseApiClient
    {
        private string REALTOR_API_URL = API_BASE_URL + "/realtors";
        
        public void Delete(int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTOR_API_URL + $@"/{id}/delete/");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;
            this.makeRequest(request);
        }

        public ApiDefaultResponse Get(int id)
        {
            if(id != 0)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTOR_API_URL + $@"/{id}/get" );
                request.ContentType = CONTENT_TYPE;
                request.Method = METHOD_GET;
                string res = this.makeRequest(request);
                return JsonConvert.DeserializeObject<ApiDefaultResponse>(res);
            }
            else
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTOR_API_URL + @"/get");
                request.ContentType = CONTENT_TYPE;
                request.Method = METHOD_GET;
                string res = this.makeRequest(request);
                return JsonConvert.DeserializeObject<ApiDefaultResponse>(res);
            }
        }

        public void UpdateById(int id, string name, string surname, string patronymic, string partPercentage)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTOR_API_URL + $@"/{id}/update/");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_POST;
            
            object realtorDataRequest = new {name,  surname,  patronymic, part_percentage = partPercentage};
            
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(realtorDataRequest));
            }

            this.makeRequest(request);
        }

        public void Create(string name, string surname, string patronymic, string partPercentage)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTOR_API_URL + @"/create");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_POST;
            
            object realtorDataRequest = new {name,  surname,  patronymic, part_percentage = partPercentage};
            
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(realtorDataRequest));
            }

            this.makeRequest(request);
        }

        public List<RealtorEntity> GetRealtors()
        {
            List<RealtorEntity> realtorEntities = new List<RealtorEntity>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTOR_API_URL + @"/get");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;

            string res = this.makeRequest(request);
            ApiDefaultResponse defaultResponse = JsonConvert.DeserializeObject<ApiDefaultResponse>(res);

            JArray innerResponse = (JArray)defaultResponse.response;
            JObject[] types = innerResponse.Select(jv => (JObject)jv).ToArray();

            foreach (JObject type in types)
            {
                realtorEntities.Add(JsonConvert.DeserializeObject<RealtorEntity>(type.ToString()));
            }

            return realtorEntities;
        }
    }
}