using CartBackend.Common.Models;
using CartBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Services
{
    public class DiscountService : BaseService<Discount>
    {
        private DiscountRepository _repo = new DiscountRepository();

        public Discount GetByCode(string code)
        {
            return _repo.GetByCode(code);
        }
    }
}
