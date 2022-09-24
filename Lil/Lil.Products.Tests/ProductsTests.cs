using Lil.Products.Controllers;
using Lil.Products.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Products.Tests
{
    [TestClass]
    public class ProductsTests
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            var productsProvider = new ProductsProvider();
            var productsController = new ProductsController(productsProvider);

            /*ID del producto*/
            var result = productsController.GetAsync("5").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetProductId()
        {
            var productsProvider = new ProductsProvider();

            bool result = productsProvider.isProductId("1");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetProductName()
        {
            var productsProvider = new ProductsProvider();

            bool result = productsProvider.IsProductName("Producto 1");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetProductPrice()
        {
            var productsProvider = new ProductsProvider();

            bool result = productsProvider.isProductPrice(1 * 3.14);

            Assert.IsTrue(result);
        }
    }
}
