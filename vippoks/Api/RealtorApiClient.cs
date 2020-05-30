using System.IO;
using System.Net;
using Newtonsoft.Json;

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

        public ApiDefaultResponse Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REALTOR_API_URL + @"/get");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;
            string res = this.makeRequest(request);
            return JsonConvert.DeserializeObject<ApiDefaultResponse>(res);
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

    }
}