using CartBackend;
using CartBackend.Common.DTO;
using CartBackend.Common.Models;
using CartBackend.Services;
using CartViewModel;
using DeliveryBackend.Helpers;
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

        public double Price { get; set; }

        public string Street { get; set; }
        public int Number { get; set; } = 0;

        public string City { get; set; }
        public string PostalCode { get; set; }

        public bool pdf { get; set; } = true;

        private static Random random = new Random();

        public PaymentVM()
        {
            //Products = model.Products;
            Products = new ObservableCollection<ProductDTO>(DocumentData.products);
            Price = DocumentData.Price;
            DocumentData.PriceVat = Price/1.08;
            if (DocumentData.delivery == 3)
            {
                Street = DocumentData.UserAdd.street;
                Number = DocumentData.UserAdd.nip;
                City = DocumentData.UserAdd.city;
                PostalCode = DocumentData.UserAdd.postalCode;
            }
            else
            {
                Street = "Dostawa do domu";
                Number = 0;
                City = "Dostawa do domu";
                PostalCode = "Dostawa do domu";
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
                        Id = UserData.id
                    },

                },
                Products = this.Products.ToList()
            };
            service.Insert(order);

            DeliveryManager man = new DeliveryManager();
            InvoiceManager inv = new InvoiceManager();
            Delivery del = new Delivery();
            int delId = man.Create(order.Order, man.GetDO(DocumentData.delivery),DocumentData.UserAdd);
            Invoice in2 = new Invoice()
            {
                m_ID = delId,
                m_Name = DateTime.Today.ToString() + "_" + random.Next().ToString()
            };
            inv.Create(in2);
            DocumentData.delNb = in2.m_Name;
            if(pdf == true)
            {
                inv.Generate("Rachunek.pdf", in2);
            }
            else
            {
                inv.GenerateAndSend("Rachunek.pdf", in2);
            }

        }

    }
}
