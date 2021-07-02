using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxConsoleApp.Models
{

    public class TaxForOrderForCreationDto
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public float amount { get; set; }
        public float shipping { get; set; }
        public Line_ItemsForOrder[] line_items { get; set; }

        public static TaxForOrderForCreationDto NewTaxForOrderForCreationDto()
        {
            return new TaxForOrderForCreationDto
            {
                from_country = "US",
                from_zip = "07001",
                from_state = "NJ",
                to_country = "US",
                to_zip = "07446",
                to_state = "NJ",
                amount = float.Parse("16.50"),
                shipping = float.Parse("1.5"),
                line_items = new Line_ItemsForOrder[]
                {
                    new Line_ItemsForOrder
                    {
                        quantity = 1,
                        unit_price = float.Parse("15.0"),
                        product_tax_code = "31000"
                    }
                }
            };
        }
    }

    public class Line_ItemsForOrder
    {
        public int quantity { get; set; }
        public float unit_price { get; set; }
        public string product_tax_code { get; set; }
    }

    

}
