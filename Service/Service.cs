using System.Collections.Generic;
using MenuModel;
using System.Net;
using Newtonsoft.Json;

namespace Service
{
    static public class Service
    {
        public static List<product> GetProducts()
        {
            using(WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("http://127.0.0.1:8080/server/api/product/get_all");
                return JsonConvert.DeserializeObject<List<product>>(json);
            }
        }
    }
}
