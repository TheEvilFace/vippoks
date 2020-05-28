using System.IO;
using System.Net;
using Newtonsoft.Json;

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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTIES_API_URL + @"/delete/" + id);
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;
            this.makeRequest(request);
        }

        public void UpdateById(int id, string city, string street, string house, int type_id, int flat, float area, int floors_count, string latitude, string longitude)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTIES_API_URL + @"/update/" + id);
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_POST;

            object clientDataRequest = new { city, street, house, type_id, flat, area, floors_count, latitude, longitude};
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
              
            }
            var sad = (JsonConvert.SerializeObject(clientDataRequest));

            this.makeRequest(request);
        }

        public void Create(int id, string city, string street, string house, int type_id, int flat, float area, int floors_count, string lat, string Long)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTIES_API_URL + @"/create");

            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_POST;

            object clientDataRequest = new { city, street, house, type_id, flat, area, floors_count, lat, Long };
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(clientDataRequest));
            }

            this.makeRequest(request);
        }
    }
}
