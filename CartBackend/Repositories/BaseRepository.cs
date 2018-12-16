using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend
{
    public class BaseRepository<T>
    {

        public List<T> GetAll()
        {
            var name = typeof(T).Name.ToLower();
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
            var name = typeof(T).Name.ToLower();

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

        public void InsertUpdate(T model)
        {
            var name = typeof(T).Name.ToLower();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/" + name);
            request.Method = "POST";
            request.ContentType = "application/json";

            var json = JsonConvert.SerializeObject(model);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        public void Delete(int id)
        {
            var name = typeof(T).Name.ToLower();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/" + name + "/" + id);
            request.Method = "DELETE";
        }

    }
}
