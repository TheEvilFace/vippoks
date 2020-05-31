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
    public sealed class RealtiesApiClient : BaseApiClient
    {
        private string REALTIES_API_URL = API_BASE_URL + "/realties";

        public ApiDefaultResponse Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTIES_API_URL + @"/get");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;
            string res = this.makeRequest(request);
            return JsonConvert.DeserializeObject<ApiDefaultResponse>(res);
        }

        public void Delete(int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTIES_API_URL + $@"/{id}/delete");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;
            this.makeRequest(request);
        }

        public void UpdateById(int id, int floor, string city, string street, string house, int type_id, int flat, float area, int floors_count, string latitude, string longitude)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTIES_API_URL + $@"/{id}/update");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_POST;

            object realtiesDataRequest = new { city, street, house, type_id, flat, floor ,area, floors_count, latitude, longitude };
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(realtiesDataRequest));
            }

            this.makeRequest(request);
        }

        public void Create( int floor,  string city, string street, string house, int type_id, int flat, float area, int floors_count, string latitude, string longitude)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTIES_API_URL + @"/create");

            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_POST;

            object realtiesDataRequest = new { floor, city, street, house, type_id, flat, area, floors_count, latitude, longitude };
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(realtiesDataRequest));
            }

            this.makeRequest(request);
        }
        public List<RealtyTypeEntity> GetTypes()
        {
            List<RealtyTypeEntity> realtyTypeEntities = new List<RealtyTypeEntity>();
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTIES_API_URL + @"/types/get");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;

            string res = this.makeRequest(request);
            ApiDefaultResponse defaultResponse = JsonConvert.DeserializeObject<ApiDefaultResponse>(res);

            JArray innerResponse = (JArray) defaultResponse.response;
            JObject[] types = innerResponse.Select(jv => (JObject)jv).ToArray();
            
            foreach (JObject type in types)
            {
                realtyTypeEntities.Add(JsonConvert.DeserializeObject<RealtyTypeEntity>(type.ToString()));
            }
            
            return realtyTypeEntities;
        }
    }
}
