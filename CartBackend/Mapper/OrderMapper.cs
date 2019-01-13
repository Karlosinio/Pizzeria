using CartBackend.Common.DTO;
using CartBackend.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Mapper
{
    public static class OrderMapper
    {

        public static Order_Product ProductDTOtoOrderProduct(ProductDTO productDTO)
        {
            var product = ProductDTOtoProduct(productDTO);

            Order_Product result = new Order_Product
            {
                Product = product,
                Quantity = productDTO.Quantity
            };

            return result;
        }

        public static Product ProductDTOtoProduct (ProductDTO productDTO)
        {
            Product product = new Product
            {
                Available = productDTO.Available,
                Category = productDTO.Category,
                Components = productDTO.ComponentToDisplay,
                Name = productDTO.Name,
                Price = productDTO.Price
            };

            return product;
        }

    }
}
