using DeliveryBackend.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CartBackend.Common.Models;
using System.IO;
using Newtonsoft.Json.Serialization;

namespace DeliveryBackend.Service
{

    public class DeliveryManager
    {
        public bool Create(Order order, DeliveryOption option, Address address)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1:8080/server/api/deliveries/");
            request.Method = "POST";
            request.ContentType = "application/json";

            string nw = $"{{\"address\": {{\"id\": {address.id} }}, \"deliveryOption\": {{ \"id\": {option.id}}},\"order\": {{\"id\": {order.Id}}}";

            //Delivery del = new Delivery(address, option, order);

            //var json = JsonConvert.SerializeObject(del);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(nw);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return true;
                }
            }

            return false;
        }

        public Delivery Get(int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1:8080/server/api/deliveries/{id}");
            request.Method = "GET";
            request.ContentType = "application/json";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                var list = JsonConvert.DeserializeObject<Delivery>(result);
                return list;
            }
        }

        public void Update(Delivery model, int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/deliveries/");
            request.Method = "PUT";
            request.ContentType = "application/json";

            var json = JsonConvert.SerializeObject(model);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var response = request.GetResponse();
        }

        public DeliveryOption GetDO(int id)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1:8080/server/api/deliveryoptions/{id}");
            request.Method = "GET";
            request.ContentType = "application/json";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                var list = JsonConvert.DeserializeObject<DeliveryOption>(result);
                return list;
            }
        }
    }
}
