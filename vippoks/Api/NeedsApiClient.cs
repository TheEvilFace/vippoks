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
        public class NeedsApiClient : BaseApiClient
        {
            private string NEEDS_API_URL = API_BASE_URL + "/needs";

            public void Delete(int id)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(NEEDS_API_URL + $@"/{id}/delete/");
                request.ContentType = CONTENT_TYPE;
                request.Method = METHOD_GET;
                this.makeRequest(request);
            }

            public void UpdateById(int id, int client_id, int realtor_id, double price, int realty_type)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(NEEDS_API_URL + $@"/{id}/update/");
                request.ContentType = CONTENT_TYPE;
                request.Method = METHOD_POST;

                object realtorDataRequest = new { client_id, realtor_id, price, realty_type };

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(realtorDataRequest));
                }

                this.makeRequest(request);
            }

            public void Create(int client_id, int realtor_id, double price, int realty_type_id)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(NEEDS_API_URL + @"/create");
                request.ContentType = CONTENT_TYPE;
                request.Method = METHOD_POST;

                object realtorDataRequest = new { client_id, realtor_id, price, realty_type_id };

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(realtorDataRequest));
                }

                this.makeRequest(request);
            }
            public List<NeedsEntity> GetTypes()
            {
                List<NeedsEntity> needsEntity = new List<NeedsEntity>();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(NEEDS_API_URL + @"/get");
                request.ContentType = CONTENT_TYPE;
                request.Method = METHOD_GET;

                string res = this.makeRequest(request);
                ApiDefaultResponse defaultResponse = JsonConvert.DeserializeObject<ApiDefaultResponse>(res);

                JArray innerResponse = (JArray)defaultResponse.response;
                JObject[] types = innerResponse.Select(jv => (JObject)jv).ToArray();

                foreach (JObject type in types)
                {
                    needsEntity.Add(getOfferFromJson(type));
                }

                return needsEntity;
            }

            private NeedsEntity getOfferFromJson(JObject jObject)
            {
                JObject jNeedsEntity = JObject.Parse(jObject.ToString());
                JToken jId = jNeedsEntity["id"];
                JToken jMinPrice = jNeedsEntity["min_price"];
                JToken jMaxPrice = jNeedsEntity["max_price"];
                JToken jClientEntity = jNeedsEntity["client"];
                JToken jRealtorEntity = jNeedsEntity["realtor"];
                JToken jRealtyTypeEntity = jNeedsEntity["realty_type"];

                return new NeedsEntity
                {
                    id = Int32.Parse(jId.ToString()),
                    minPrice = Double.Parse(jMinPrice.ToString(), CultureInfo.InvariantCulture),
                    maxPrice = Double.Parse(jMaxPrice.ToString(), CultureInfo.InvariantCulture),
                    client = jClientEntity.ToObject<ClientEntity>(),
                    realtor = jRealtorEntity.ToObject<RealtorEntity>(),
                    realty_type = jRealtyTypeEntity.ToObject<RealtyTypeEntity>()
                };

            }
        }
    }



