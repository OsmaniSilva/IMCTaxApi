using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TaxConsoleApp.Models
{
    public class JsonContent : StringContent
    {
        public JsonContent(object content) : base(JsonConvert.SerializeObject(content))
        {
        }

        public JsonContent(object content, Encoding encoding) : base(JsonConvert.SerializeObject(content), encoding)
        {
        }

        public JsonContent(object content, Encoding encoding, string mediaType) : base(JsonConvert.SerializeObject(content), encoding, mediaType)
        {
        }
    }
}
