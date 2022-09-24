using Lil.Search.Models;
using Lil.Search.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;

namespace Lil.Search.Tests
{
    [TestClass]
    public class SearchTest
    {
        public IHttpClientFactory MakeMockedHttpReponseFactory(string response)
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            mockHttpMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                                              .ReturnsAsync(new HttpResponseMessage
                                              {
                                                  StatusCode = HttpStatusCode.OK,
                                                  Content = new StringContent(response),
                                              }).Verifiable();

            var client = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://127.0.0.1/;"),
            };

            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            return mockFactory.Object;
        }


        [TestMethod]
        public void GetSearchObject()
        {
            var mockedCustomerHttpFactory = MakeMockedHttpReponseFactory("{'Id':'1', 'Name':'Andre', 'City':'Orotina'}");

            var customerService = new CustomersService(mockedCustomerHttpFactory);

            var result = customerService.GetAsync("1").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Customer));
        }

        [TestMethod]
        public void GetSearchNonObject()
        {
            var mockedCustomerHttpFactory = MakeMockedHttpReponseFactory("{'Id':'1', 'Name':'Andre', 'City':'Orotina'}");

            var customerService = new CustomersService(mockedCustomerHttpFactory);

            var result = customerService.GetAsync("1").Result;

            Assert.IsNotNull(result);
            Assert.IsNotInstanceOfType(result, typeof(OrderItem));
        }

    }
}