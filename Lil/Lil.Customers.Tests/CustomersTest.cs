using Lil.Customers.Controllers;
using Lil.Customers.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Customers.Tests
{
    [TestClass]
    public class CustomersTest
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            var customersProvider = new CustomersProvider();
            var customersController = new CustomersController(customersProvider);

            var result = customersController.GetAsync("1").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }

        [TestMethod]
        public void GetAsyncReturnsNotFound()
        {
            var customersProvider = new CustomersProvider();
            var customersController = new CustomersController(customersProvider);

            var result = customersController.GetAsync("50").Result;

            Assert.IsNotNull(result);
            Assert.IsNotInstanceOfType(result, typeof(NotFoundObjectResult));
            
        }
    }
}