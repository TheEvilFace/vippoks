using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using vippoks.Api.Entities;


namespace vippoks
{
    public class DealsApiClient : BaseApiClient
    {
        private string Deals_API_URL = API_BASE_URL + "/deals";

        public void Delete(int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Deals_API_URL + $@"/{id}/delete/");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;
            this.makeRequest(request);
        }

        public void UpdateById(int id, int offer_id, int need_id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Deals_API_URL + $@"/{id}/update/");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_POST;

            object realtorDataRequest = new { offer_id, need_id };

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(realtorDataRequest));
            }

            this.makeRequest(request);
        }

        public void Create( int offer_id, int need_id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Deals_API_URL + @"/create");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_POST;

            object realtorDataRequest = new { offer_id, need_id };

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(realtorDataRequest));
            }

            this.makeRequest(request);
        }
        public List<DealEntity> GetTypes()
        {
            List<DealEntity> dealsEntity = new List<DealEntity>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Deals_API_URL + @"/get");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;

            string res = this.makeRequest(request);
            ApiDefaultResponse defaultResponse = JsonConvert.DeserializeObject<ApiDefaultResponse>(res);

            JArray innerResponse = (JArray)defaultResponse.response;
            JObject[] types = innerResponse.Select(jv => (JObject)jv).ToArray();

            foreach (JObject type in types)
            {
                dealsEntity.Add(getDealsFromJson(type));
            }

            return dealsEntity;
        }

        private DealEntity getDealsFromJson(JObject jObject)
        {
            JObject jDealsEntity = JObject.Parse(jObject.ToString());
            JToken jId = jDealsEntity["id"];
            JToken jOffers = jDealsEntity["offer"];
            JToken jNeeds = jDealsEntity["need"];

            return new DealEntity
            {
                id = Int32.Parse(jId.ToString()),
                offers = jOffers.ToObject<OfferEntity>(),
                needs = jNeeds.ToObject<NeedsEntity>(),
            };

        }
    }
}
