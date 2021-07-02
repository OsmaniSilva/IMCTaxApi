using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxConsoleApp.ApiRoutes
{
    public static class ApiRoutes
    {
        public const string LocationRates = "rates/";
        public const string TaxForOrders = "taxes/";

        public const string AllOrders =
            "transactions/orders?from_transaction_date=2015/05/01&to_transaction_date%09=2015/05/31";
    }
}
