using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CVIMS.Api.Infrastructure.Models
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            var serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(this, serializerSettings);
        }
    }
}
