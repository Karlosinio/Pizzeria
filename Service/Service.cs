using System.Collections.Generic;
using MenuModel;
using System.Net;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json.Serialization;

namespace ServiceNS
{
    public class Service
    {
        public ObservableCollection<product> GetProducts()
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("http://127.0.0.1:8080/server/api/products/get_all");
                return JsonConvert.DeserializeObject<ObservableCollection<product>>(json);
            }
        }

        public double GetAverageRating()
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("http://127.0.0.1:8080/server/api/ratings/get_average/");
                json = json.Substring(1, json.Length - 2);
                return double.Parse(json, CultureInfo.InvariantCulture);
            }
        }

        public void SendRate(int Rate, int id)
        {
            ratings r = new ratings();
            r.rate = Rate;
            r.user = new User(id);
            //r.ratingTimestamp = "1544978400000";
            //r.comment = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/ratings/");
            request.Method = "POST";
            request.ContentType = "application/json";

            var json = JsonConvert.SerializeObject(r, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                //var a = Int32.Parse(result);
            }
        }
    }
}
