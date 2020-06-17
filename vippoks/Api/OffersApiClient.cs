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
    class OffersApiClient : BaseApiClient
    {
        private string OFFERS_API_URL = API_BASE_URL + "/offers";

        public void Delete(int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(OFFERS_API_URL + $@"/{id}/delete/");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;
            this.makeRequest(request);
        }

        public void UpdateById(int id ,int client_id, int realtor_id, double price, int realty_type)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(OFFERS_API_URL + $@"/{id}/update/");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_POST;

            object realtorDataRequest = new { client_id, realtor_id, price , realty_type };

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(realtorDataRequest));
            }

            this.makeRequest(request);
        }

        public void Create( int client_id, int realtor_id, double price, int realty_type_id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(OFFERS_API_URL + @"/create");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_POST;

            object realtorDataRequest = new { client_id, realtor_id, price, realty_type_id };

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(realtorDataRequest));
            }

            this.makeRequest(request);
        }
        public List<OfferEntity> Find( int client_id, int realtor_id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(OFFERS_API_URL + @"/get-by-participants");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_POST;
            List<OfferEntity> offersEntity = new List<OfferEntity>();

            object realtorDataRequest = new { client_id, realtor_id};

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(realtorDataRequest));
            }

            string res = this.makeRequest(request);

            ApiDefaultResponse defaultResponse = JsonConvert.DeserializeObject<ApiDefaultResponse>(res);

            JArray innerResponse = (JArray)defaultResponse.response;
            JObject[] types = innerResponse.Select(jv => (JObject)jv).ToArray();

            foreach (JObject type in types)
            {
                offersEntity.Add(getOfferFromJson(type));
            }
            return offersEntity;
        }

        public List<OfferEntity> GetOffers()
        {
            List<OfferEntity> offersEntity = new List<OfferEntity>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(OFFERS_API_URL + @"/get");
            request.ContentType = CONTENT_TYPE;
            request.Method = METHOD_GET;

            string res = this.makeRequest(request);
            ApiDefaultResponse defaultResponse = JsonConvert.DeserializeObject<ApiDefaultResponse>(res);

            JArray innerResponse = (JArray)defaultResponse.response;
            JObject[] types = innerResponse.Select(jv => (JObject)jv).ToArray();

            foreach (JObject type in types)
            {
                offersEntity.Add(getOfferFromJson(type));
            }

            return offersEntity;
        }

        private OfferEntity getOfferFromJson(JObject jObject)
        {
            JObject jOfferEntity = JObject.Parse(jObject.ToString());
            JToken jId = jOfferEntity["id"];
            JToken jPrice = jOfferEntity["price"];
            JToken jClientEntity = jOfferEntity["client"];
            JToken jRealtorEntity = jOfferEntity["realtor"];
            JToken jRealtyTypeEntity = jOfferEntity["realty_type"];

            return new OfferEntity
            {
                id     = Int32.Parse(jId.ToString()),
                price  = Double.Parse(jPrice.ToString(), CultureInfo.InvariantCulture),
                client = jClientEntity.ToObject<ClientEntity>(),
                realtor = jRealtorEntity.ToObject<RealtorEntity>(),
                realty_type = jRealtyTypeEntity.ToObject<RealtyTypeEntity>()
            };

        }
    }
}
