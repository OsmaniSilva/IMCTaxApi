using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using TaxConsoleApp.ApiRoutes;
using TaxConsoleApp.Config;
using TaxConsoleApp.Models;
using TaxConsoleApp.Services;
using Xunit;

namespace TaxConsoleAppTest
{
    public class UnitTest1
    {
        private ITaxServices taxService;
        private HttpClient http;

        public UnitTest1()
        {
            http = A.Fake<HttpClient>();
            var options = A.Fake<IOptions<TaxSettings>>();
            var taxCalculator = new TaxCalculator();

            taxService = new TaxServices(http, options, taxCalculator);
        }


        [Fact]
        [Trait("TaxServices", "GetTaxRateByLocationAsync")]
        public async Task GetTaxAmountGetTaxRateByLocationAsync_ShouldReturnCorrectValue()
        {
            var locationId = "33134";
            //act
            var result = await taxService.GetTaxRateByLocationAsync(locationId);
            //assert
            Xunit.Assert.True(result > 0);
        }

        [Fact]
        [Trait("TaxServices", "GetAllOrderAsync")]
        public async Task GetAllOrderAsync_ShouldReturnCount()
        {
            //act
            var result = await taxService.GetAllOrderAsync();
            //assert
            Xunit.Assert.True(result.Length > 0);
        }

    }
}
