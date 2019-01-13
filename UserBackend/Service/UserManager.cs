using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using User.Model;

namespace User.Service
{
   public class UserManager
    {

        public bool Create(string nick, string name, string surname, Address address, Question question, string answer, string password)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/users/");
                request.Method = "POST";
                request.ContentType = "application/json";
//                JsonSerializer jsonSerializer = new JsonSerializer()
//                {
//                    NullValueHandling = NullValueHandling.Ignore
//                };
//                var json = JsonConvert.SerializeObject(add, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore});   
                string newUser = $"{{\"nick\": \"{nick}\",\"name\": \"{name}\",\"surname\": \"{surname}\",\"address\": {{\"name\":\"\" ,\"street\": \"\",\"city\": \"\",\"postalCode\": \"\"}},\"question\": {{\"id\": {question.Id},\"question\": \"{question.question}\"}},\"answer\": \"{answer}\",\"password\": \"{password}\"}}";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
//                streamWriter.Write(json);
                    streamWriter.Write(newUser);
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.Created)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("CONNECTION ERROR");
                throw;
            }
            return false;
        }

       // public int Login(string nick, string password)
        public int Login(string nick, string password)
        {
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/users/login/");
            request.Method = "POST";
            request.ContentType = "application/json";
            Model.User add = new Model.User() {Nick = nick, Password = password};

       //     var json = JsonConvert.SerializeObject(add);   
            string User = $"{{\"nick\": \"{nick}\",\"password\": \"{password}\"}}";


            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
               // streamWriter.Write(json);
                streamWriter.Write(User);
            }


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                   // return true;
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string responsestring = reader.ReadToEnd();
                        return int.Parse(responsestring);
                    }
                }
            }

            return 0;
        }
        public bool Logout(int id)
        {
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create($"http://127.0.0.1:8080/server/api/users/{id}/logout/");
            request.Method = "POST";
         //   request.ContentType = "application/json";
          //  Model.User add = new Model.User() {Id=id};

            //     var json = JsonConvert.SerializeObject(add);   
           // string User = $"{{\"id\": \"{id}\"}}";


            //using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            //{
            //    // streamWriter.Write(json);
            //    streamWriter.Write(User);
            //}


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }

        public Model.User Get(string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1:8080/server/api/users/{id}");
            request.Method = "GET";
            request.ContentType = "application/json";
            
            WebResponse myResponse = request.GetResponse();
            Stream rebut = myResponse.GetResponseStream();
            StreamReader readStream = new StreamReader(rebut, Encoding.UTF8);
            string info = readStream.ReadToEnd();
            
            var list = JsonConvert.DeserializeObject<Model.User>(info);
            return list;
        }

        public bool Update(string id, string name, string surname, Address address, string phone, string email)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1:8080/server/api/users/{id}/details/");
            request.Method = "PATCH";
            request.ContentType = "application/json";
//                JsonSerializer jsonSerializer = new JsonSerializer()
//                {
//                    NullValueHandling = NullValueHandling.Ignore
//                };
//                var json = JsonConvert.SerializeObject(add, new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore});   
            string updateUser = $"{{\"name\": \"{name}\",\"surname\": \"{surname}\",\"address\": {{\"name\":\"\" ,\"street\": \"\",\"city\": \"\",\"postalCode\": \"\"}},\"phone\": \"{phone}\",\"email\": \"{email}\"}}";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
//                streamWriter.Write(json);
                streamWriter.Write(updateUser);
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

    }
}
