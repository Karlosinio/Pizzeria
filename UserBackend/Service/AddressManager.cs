using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Model;
    
    
namespace User.Service
{
    public class AddressManager
    {
        public Address Get(int id)
        {
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create($"http://127.0.0.1:8080/server/api/addresses/{id}");
            request.Method = "GET";
            request.ContentType = "application/json";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                var list = JsonConvert.DeserializeObject<Address>(result);
                return list;
            }
        }

        public bool Create(string name, int nip, string street, string city, string postalCode)
        {
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/addresses/");
            request.Method = "POST";
            request.ContentType = "application/json";
            Address add = new Address(){Name = name, City = city, PostalCode = postalCode, Street = street};

            var json = JsonConvert.SerializeObject(add);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
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

        public bool Remove(int id)
        {
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create($"http://127.0.0.1:8080/server/api/addresses/{id}");
            request.Method = "DELETE";
            request.ContentType = "application/json";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
