using CartBackend.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public List<Order> GetRecentNumber(int number)
        {
            var list = base.GetAll();

            var numberOfElements = list.Count();

            var result = list.Skip(numberOfElements - number).ToList();

            return result;
        }

        //private GetLastElements(int number, List<Order> list)
        //{
        //    using(var e = list.GetEnumerator())
        //    {
        //        while (count < number && )
        //    }
        //}

    }
}
