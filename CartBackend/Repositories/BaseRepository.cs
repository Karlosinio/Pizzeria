 using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend
{
    public class BaseRepository<T>
    {
        private string name = typeof(T).Name.ToLower() + "s";

        public List<T> GetAll()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/"  + name +"/get_all");

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return list;
            }
        }

        public T GetByID(int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/" + name + "/" + id);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                var list = JsonConvert.DeserializeObject<T>(result);
                return list;
            }
        }

        public int Insert(T model)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/" + name + "/");
            request.Method = "POST";
            request.ContentType = "application/json";

            var json = JsonConvert.SerializeObject(model, new JsonSerializerSettings
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
                return Int32.Parse(result);
            }
        }

        public void Update(T model, int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/" + name + "/" + id);
            request.Method = "PUT";
            request.ContentType = "application/json";

            var json = JsonConvert.SerializeObject(model, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var response = request.GetResponse();
        }

        public void Delete(int id)
        {
            var name = typeof(T).Name.ToLower();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/" + name + "/" + id);
            request.Method = "DELETE";
        }

    }
}
