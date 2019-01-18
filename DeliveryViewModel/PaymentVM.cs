using CartBackend.Common.DTO;
using CartBackend.Common.Models;
using CartViewModel;
using DeliveryBackend.Model;
using DeliveryBackend.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            DeliveryManager man = new DeliveryManager();
            man.Create(model.GetOrder(), man.GetDO(deli.CheckDelivery()), deli.AddressModel);
        }

    }
}
