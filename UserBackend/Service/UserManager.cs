﻿using System;
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
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/users/");
            request.Method = "POST";
            request.ContentType = "application/json";
            Model.User add = new Model.User(nick, name, surname, address, question, answer, password);

//            var json = JsonConvert.SerializeObject(add);

            string adr ="{{\"name\": \"Test address\",   	 \"street\": \"Street 1\",   	 \"city\": \"City\",   	 \"postalCode\": \"12-345\"  }}";   
            string qeust = "{\"id\": 1,\"question\":\"question1\"}";


//            string newUser = $"{{\"nick\": {nick},\"name\":{name}, \"surname\":  {surname},\"address\": {adr},\"question\": {question},\"answer\": {answer},\"password\": {password} }}";
//            string newUser = $"{{\"nick\": \"{nick}\",\"name\":\"{name}\", \"surname\":  \"{surname}\",\"address\": {{\"id\": \"{address.id}\" }}, \"question\": \"{{\"id\": 1,\"question\":\"question1\"}}\",\"answer\": \"{answer}\",\"password\": \"{password}\" }}";

            string newUser =
                $"{{\"nick\": \"{nick}\",    \"name\": \"{name}\",    \"surname\": \"{surname}\",    \"address\": {{\"name\": \"Test address\",   	 \"street\": \"Street 1\",   	 \"city\": \"City\",   	 \"postalCode\": \"12-345\"  }},    \"question\": {{    	\"id\": 1,\"question\": \"Imię mojego psa\"    }},    \"answer\": \"{answer}\",    \"password\": \"{password}\"}}";



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



        
    }
}