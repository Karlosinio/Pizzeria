using CartBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseRepository<Product> repo = new BaseRepository<Product>();
            var one = repo.GetAll();
            var two = repo.GetByID(1);

            //repo.Delete(1);

            //one = repo.GetAll();

            Product p = new Product
            {
                Name = "ssss",
                Components = "sadasd",
                Category = "asdasd",
                Price = 200,
                Available = true
            };

            repo.InsertUpdate(p);

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
