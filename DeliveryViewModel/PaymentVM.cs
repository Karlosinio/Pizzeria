using CartBackend;
using CartBackend.Common.DTO;
using CartBackend.Common.Models;
using CartBackend.Services;
using CartViewModel;
using DeliveryBackend.Model;
using DeliveryBackend.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Model;

namespace DeliveryViewModel
{
    public class PaymentVM : BaseViewModel
    {
        public ObservableCollection<ProductDTO> Products { get; set; }
        public CartVM model { get; set; }
        public DeliveryVM deli {get;set;}

        public double Price { get; set; }

        public string Street { get; set; }
        public int Number { get; set; } = 0;

        public string City { get; set; }
        public string PostalCode { get; set; }
        private static Random random = new Random();

        public PaymentVM(CartVM cart, DeliveryVM deli1)
        {
            model = cart;
            Products = model.Products;
            Price = model.Price;
            deli = deli1;
            if (deli.CheckDelivery() == 3)
            {
                Street = deli.AddressModel.street;
                Number = deli.AddressModel.nip;
                City = deli.AddressModel.city;
                PostalCode = deli.AddressModel.postalCode;
            }

        }

        public void CreateDelivery()
        {
            var service = new OrderService();
            var order = new OrderDTO()
            {
                Order = new Order()
                {
                    Comment = "",
                    Deleted = false,
                    DiscountUsed = false,
                    OrderTimestamp = DateTime.Now.Date.Second,
                    Price = (float)this.Price,
                    User = new CartBackend.Common.Models.User()
                    {
                        Id = /* UserData.Id */ 1
                    },

                },
                Products = this.Products.ToList()
            };
            service.Insert(order);

            DeliveryManager man = new DeliveryManager();
            InvoiceManager inv = new InvoiceManager();
            Delivery del = new Delivery();
            int delId = man.Create(order.Order, man.GetDO(deli.CheckDelivery()), deli.AddressModel);
            Invoice in2 = new Invoice()
            {
                m_ID = delId,
                m_Name = DateTime.Today.ToString() + "_" + random.Next().ToString()
            };
            inv.Create(in2);
            UserData.email = "eloelo1230@gmail.com";
            inv.GenerateAndSend(Products.ToList(), "Rachunek.pdf", in2, deli.btn2);

        }

    }
}
