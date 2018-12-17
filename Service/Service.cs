using System.Collections.Generic;
using MenuModel;
using System.Net;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ServiceNS
{
    public class Service
    {
        public ObservableCollection<product> GetProducts()
        {
            using(WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("http://127.0.0.1:8080/server/api/product/get_all");
                return JsonConvert.DeserializeObject<ObservableCollection<product>>(json);
            }
        }
    }
}
