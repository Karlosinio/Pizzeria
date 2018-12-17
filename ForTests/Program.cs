using CartBackend;
using CartBackend.Common.DTO;
using CartBackend.Common.Models;
using CartBackend.Services;
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

            var service = new OrderService();

            Order o = new Order
            {
                Comment = "asdgfdg",
                DiscountUsed = false,
                Deleted = false,
                Price = 200,
                User = new User { Id = 2 },
                OrderTimestamp = 1231231
            };


            Product dto = new Product
            {
                Id = 1,
                Available = true,
                Category = "sadasd",
                Name = "sadasdas",
                Price = 200
            };


            Order_Product oo = new Order_Product();
            oo.Product = dto;

            OrderDTO orderDto = new OrderDTO
            {
                Order = o
            };
            orderDto.Products.Add(oo);

            var list = service.GetAll();

            service.Insert(orderDto);

        }
    }
}
