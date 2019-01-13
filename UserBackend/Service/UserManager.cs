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
    class UserManager
    {

        //        public bool Create(string nick, string name, string surname, Address address, Question question, string answer, string password)
        public bool Create(string nick, string name, string surname, string address, string question, string answer, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/users/");
            request.Method = "POST";
            request.ContentType = "application/json";
            Model.User add = new Model.User(nick, name, surname, address, question, answer, password);

            //            var json = JsonConvert.SerializeObject(add);   
            string newUser = $"{{\"nick\": \"{nick}\",\"name\": \"{name}\",\"surname\": \"{surname}\",\"address\": {{\"name\":\"\" ,\"street\": \"\",\"city\": \"\",\"postalCode\": \"\"}},\"question\": {{\"id\": 1,\"question\": \"Imię mojego psa\"}},\"answer\": \"{answer}\",\"password\": \"{password}\"}}";


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

            return false;
        }
        public bool Login(string nick, string password)
        {
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/users/login/");
            request.Method = "POST";
            request.ContentType = "application/json";
            // Model.User add = new Model.User(nick, password);

            //            var json = JsonConvert.SerializeObject(add);   
            string User = $"{{\"nick\": \"{nick}\",\"password\": \"{password}\"}}";


            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                //                streamWriter.Write(json);
                streamWriter.Write(User);
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


        public void Get(string id)
        {
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1:8080/server/api/users/{id}");
//            request.Method = "GET";
//            request.ContentType = "application/json";
            
//            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
//            using (Stream stream = response.GetResponseStream())
//            using (StreamReader reader = new StreamReader(stream))
//            {
//                var result = reader.ReadToEnd();
//                var list = JsonConvert.DeserializeObject<DeliveryOption>(result);
//                return list;
//            }

//            string sURL;
//            sURL = $"http://127.0.0.1:8080/server/api/users/{id}";
//            WebRequest wrGETURL;
//            wrGETURL = WebRequest.Create(sURL);
//            Stream objStream;
//            objStream = wrGETURL.GetResponse().GetResponseStream();
//            StreamReader objReader = new StreamReader(objStream);
//
//            string sLine = "";
//            int i = 0;
//
//            while (sLine!=null)
//            {
//                i++;
//                sLine = objReader.ReadLine();
//                if (sLine!=null)
//                    Console.WriteLine("{0}:{1}",i,sLine);
//            }
//            Console.ReadLine();
            
        }


    }
}
