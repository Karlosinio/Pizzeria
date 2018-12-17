using CartBackend;
using CartBackend.Common.Models;
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
            BaseRepository<Order> repo = new BaseRepository<Order>();
            var one = repo.GetAll();
            //var two = repo.GetByID(1);

            //repo.Delete(1);

            //one = repo.GetAll();

            Order o = new Order
            {
                Id = 2,
                Comment = "asdgfdg",
                DiscountUsed = false,
                Deleted = false,
                Price = 200,
                User = new User { Id = 2 },
                OrderTimestamp = 1231231
            };
            repo.Update(o, o.Id);
            one = repo.GetAll();

        }
    }
}
