using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxConsoleApp.Config
{
    public class TaxSettings
    {
        public string TaxApiUrl { get; set; }
        public string ApiKey { get; set; }

    }

    public static class ValidateData
    {
        public static bool ValidateZipCode(string zipCode)
        {
            int zip = 0;
            if (zipCode.Length == 5)
            {
                int.TryParse(zipCode, out zip);
            }
            return zipCode.Length == 5 && zip > 0;
        }
    }
}
