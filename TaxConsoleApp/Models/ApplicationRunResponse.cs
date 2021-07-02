using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxConsoleApp.Models
{
    /// <summary>
    ///     Response from the application run
    /// </summary>
    public class ApplicationRunResponse
    {
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
