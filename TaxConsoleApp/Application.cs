using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Serilog;
using TaxConsoleApp.Config;
using TaxConsoleApp.Models;
using TaxConsoleApp.Services;

namespace TaxConsoleApp
{
    public class Application
    {
        private readonly ITaxServices _taxServices;
        private string zipCode = string.Empty;
        private string[] arrayOrders;
        /// <summary>
        ///     Constructor is used to inject services/IOptions that we need here
        /// </summary>
        /// <param name="taxServices"></param>
        public Application(ITaxServices taxServices)
        {
            _taxServices = taxServices;
        }

        // Async application starting point
        public async Task<ApplicationRunResponse> Run()
        {
            ApplicationRunResponse response = new ApplicationRunResponse();

            await GetTaxRateByLocation();
            await GetAllOrders();
            await CalculateTaxByOrder();


            //Log.Information($"{_taxSettings.Value.TaxApiUrl} <{_taxSettings.Value.TaxApiUrl}>");

            return response;
        }

        #region My Methods

        private async Task GetAllOrders()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("Get all orders");
            arrayOrders = await _taxServices.GetAllOrderAsync();
            Console.WriteLine($"Order numbers: {string.Join(", ", arrayOrders)}");
            Console.WriteLine("=========================================");
            Console.WriteLine("Press Enter key to continue ...");
            Console.ReadLine();
        }

        private async Task CalculateTaxByOrder()
        {
            try
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("Calculate taxes by Order");

                //foreach (var order in arrayOrders)
                //{
                //Console.WriteLine($"Order number: {order} => Tax to collect: {await _taxServices.CalculateTaxForAnOrderAsync(order)}"); ;
                //}
                Console.WriteLine($"Order number: {arrayOrders[0]} => Tax to collect: {await _taxServices.CalculateTaxForAnOrderAsync(arrayOrders[0])}");
                Console.WriteLine("Press Enter key to continue ...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private async Task GetTaxRateByLocation()
        {
            try
            {
                Console.WriteLine("Get tax rate by location");
                ValidateZipCode();
                if (zipCode != String.Empty)
                {
                    var res = await _taxServices.GetTaxRateByLocationAsync(zipCode);
                    Console.WriteLine($"Rate for zip code {zipCode} is equal to {res}");
                    Console.WriteLine("=========================================");
                    Console.WriteLine("Press Enter key to continue ...");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void ValidateZipCode()
        {
            if (!ValidateData.ValidateZipCode(zipCode))
            {
                Console.WriteLine("Enter a valid US Zip Code:");
                zipCode = Console.ReadLine();

                if (!ValidateData.ValidateZipCode(zipCode))
                {
                    ValidateZipCode();
                }
            }
        }

        #endregion

    }
}
