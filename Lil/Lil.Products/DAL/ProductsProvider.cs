using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Products.Models;

namespace Lil.Products.DAL
{
    public class ProductsProvider : IProductsProvider
    {
        private List<Product> repo = new List<Product>();
        public ProductsProvider()
        {
            for (int i = 0; i < 100; i++)
            {
                repo.Add(new Product()
                {
                    Id = (i+1).ToString(),
                    Name = $"Producto {i+1}",
                    Price = i * 3.14
                });
            }
        }
        Task<Product?> IProductsProvider.GetAsync(string id)
        {
            var product = repo.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }

        public bool IsProductName(string productName)
        {
            bool isName = false;
            foreach (var product in repo)
            {
                if (product.Name == productName)
                {
                    isName = true;
                    break;
                }
            }
            return isName;
        }

        public bool isProductPrice(double productPrice)
        {
            bool isPrice = false;
            foreach (var product in repo)
            {
                if (product.Price == productPrice)
                {
                    isPrice = true;
                    break;
                }
            }
            return isPrice;
        }

        public bool isProductId(string productId)
        {
            bool isId = false;
            foreach (var product in repo)
            {
                if (product.Id == productId)
                {
                    isId = true;
                    break;
                }
            }
            return isId;
        }
    }
}
