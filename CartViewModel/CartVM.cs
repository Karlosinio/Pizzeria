﻿using CartBackend;
using CartBackend.Common.DTO;
using CartBackend.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Component = CartBackend.Common.Models.Component;


namespace CartViewModel
{
    public class CartVM : INotifyPropertyChanged
    {
        public ObservableCollection<ProductDTO> Products { get; set; }
        private List<Order_Product> ListOfProducts { get; set; }
        private double price = 0;
        public double Price { get {
                if(Products != null)
                {
                    price = 0;
                    foreach(var prod in Products)
                    {
                        price += prod.Price;
                    }
                }
                return price;
            } set {
                if(value != price)
                {
                    price = value;
                    RaisePropertyChanged("Price");
                }
            } }

        private int quantityAddDelete = 0;
        public int QuantityAddDelete
        {
            get
            {
                return quantityAddDelete;
            }
            set
            {
                if (value != quantityAddDelete)
                {
                    quantityAddDelete = value;
                    RaisePropertyChanged("QuantityAddDelete");
                }
            }
        }

        public ProductDTO SelectedProduct { get; set; }

        public CartVM()
        {
           
            DeleteAll = new DelegateCommand(DeleteAllProductFromCart);
            Delete = new DelegateCommand(DeleteProductFromCart);
            AddQuantity = new DelegateCommand(AddQuantityToProduct);
            Button_Add_Quantity = new DelegateCommand(Button_Add_Quantity_Change);
            Button_Delete_Quantity = new DelegateCommand(Button_Delete_Quantity_Change);
        }

        public ICommand DeleteAll { get; }
        public ICommand Order { get; }
        public ICommand Edit { get; }
        public ICommand Delete { get; }
        public ICommand AddQuantity { get; }
        public ICommand Button_Add_Quantity { get; }
        public ICommand Button_Delete_Quantity { get; }


        private void Button_Add_Quantity_Change()
        {
            QuantityAddDelete++;
        }

        private void Button_Delete_Quantity_Change()
        {
            if (quantityAddDelete > 0)
            {
                QuantityAddDelete--;
            }

        }

        private void AddQuantityToProduct()
        {
            if (SelectedProduct != null)
            {
                SelectedProduct.Quantity += QuantityAddDelete;

                Price = SelectedProduct.Quantity * SelectedProduct.Price;
                RaisePropertyChanged("Price");

                var index = Products.IndexOf(SelectedProduct);
                Products.Insert(index, SelectedProduct);
                Products.RemoveAt(index + 1);
                RaisePropertyChanged("Products");
            }
            
        }
        
        public List<ProductDTO> GetProducts()
        {
            var list = new List<ProductDTO>(Products);
            return list;
        }

        private void DeleteProductFromCart()
        {
            if (SelectedProduct != null)
                if (SelectedProduct.Quantity == QuantityAddDelete)
                {

                    Products.Remove(SelectedProduct);
                    RaisePropertyChanged("Price");


                }
                else if (SelectedProduct.Quantity> QuantityAddDelete)
                {

                    SelectedProduct.Quantity -= QuantityAddDelete;
                    var index = Products.IndexOf(SelectedProduct);
                    Products.Insert(index, SelectedProduct);
                    Products.RemoveAt(index + 1);

                    RaisePropertyChanged("Products");
                    RaisePropertyChanged("Price");

                }


        }

        private void DeleteAllProductFromCart()
        {
            if (SelectedProduct != null)
            {
                Price -= SelectedProduct.Price * SelectedProduct.Quantity;
                RaisePropertyChanged("Price");
                Products.Remove(SelectedProduct);
            }

        }

        //przeznaczone dla menu lub z ktorego miejsca będą dodawane produkty do koszyka
        public void AddProduct(ProductDTO product)
        {
            //check if product isn't in the cart already
            if (Products.Contains(product))
            {
                product.Quantity++;
                var id = Products.Where(x => x.Equals(product)).FirstOrDefault().Id;
                Products[id] = product;
            }
            else
            {
                Products.Add(product);
            }

            Price += product.Quantity * product.Price;
            RaisePropertyChanged("Price");
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
       
        #endregion
    }
}
