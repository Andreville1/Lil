using Lil.Sales.Controllers;
using Lil.Sales.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Sales.Test
{
    [TestClass]
    public class SalesTest
    {
        /*Microsoft.AspNetCore.Mvc.Core*/
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            var salesProvider = new SalesProvider();
            var salesController = new SalesController(salesProvider);

            var result = salesController.GetAsync("1").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }

        [TestMethod]
        public void GetOrderId()
        {
            var salesProvider = new SalesProvider();

            bool result = salesProvider.isOrderId("0004");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetOrderCostumerId()
        {
            var salesProvider = new SalesProvider();

            bool result = salesProvider.isCustomerId("3");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetOrderItemQuantity()
        {
            var salesProvider = new SalesProvider();

            bool result = salesProvider.isOrderItemQuantity(2);

            Assert.IsTrue(result);
        }

    }
}