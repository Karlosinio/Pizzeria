using CartBackend;
using CartBackend.Common.DTO;
using CartBackend.Common.Models;
using CartBackend.Services;
using CartViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Model;

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
                User = new CartBackend.Common.Models.User { Id = 2 },
                OrderTimestamp = 1231231
            };

            Component comp = new Component
            {
                Id = 1,
                Name = "sss",
                Price = 33
            };

            ComponentDTO dto = new ComponentDTO
            {
                Component = comp,
                Quantity = 3
            };
            Component comp2 = new Component
            {
                Id = 2,
                Name = "ssasdasds",
                Price = 337
            };

            ComponentDTO dto2 = new ComponentDTO
            {
                Component = comp2,
                Quantity = 2
            };
            Component comp3 = new Component
            {
                Id = 3,
                Name = "sssasdasd",
                Price = 332
            };

            ComponentDTO dto3 = new ComponentDTO
            {
                Component = comp3,
                Quantity = 7
            };

            List<ComponentDTO> list = new List<ComponentDTO>
            {
                dto,
                dto2,
                dto3
            };




            ProductDTO productDTO = new ProductDTO
            {
                Id = 1,
                Name = "name",
                Category = "kategoria",
                Price = 20,
                Available = true,
                Quantity = 77

            };
            ProductDTO productDTO2 = new ProductDTO
            {
                Id = 2,
                Name = "name2",
                Category = "kategoria2",
                Price = 25,
                Available = true,
                Quantity = 7
            };

            List<ProductDTO> prod = new List<ProductDTO>
            {
                productDTO,
                productDTO2
            };

            OrderDTO orderDTO = new OrderDTO
            {
                Order = o,
                Products = prod
            };

            CartVM vm = new CartVM();

            vm.AddProduct(productDTO);
            vm.AddProduct(productDTO);
            vm.AddProduct(productDTO);
            vm.AddProduct(productDTO);
            //service.Insert(orderDTO);

            //InvoiceManager inn = new InvoiceManager();
            //inn.Generate(vm.GetProducts());
            //inn.GenerateAndSend(vm.GetProducts());

        }
    }
}

            /*
            InvoiceManager inn = new InvoiceManager();
            inn.Generate(vm.GetProducts(), "Rachunek.pdf", new DeliveryBackend.Model.Invoice()
            {
                m_ID = 1,
                m_Name = ""
            },false);
            //inn.GenerateAndSend(vm.GetProducts());


            /*
            AddressManager manager = new AddressManager();
            DeliveryBackend.Model.Address add = new DeliveryBackend.Model.Address("test", 23,"xd", "Halo", "22");
            add.id = 1;
            manager.Update(1, add);
            */
