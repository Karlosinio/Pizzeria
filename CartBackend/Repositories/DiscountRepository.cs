using CartBackend.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Repositories
{
    public class DiscountRepository : BaseRepository<Discount>
    {
        public Discount GetByCode(string code)
        {
            var list = base.GetAll();

            return list.Where(x => x.Code.Equals(code)).FirstOrDefault();
        }
    }
}
