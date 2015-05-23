using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Script.Serialization;
using Antlr.Runtime;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json;

namespace WebApi.Controllers.api
{
    [JsonObject]
    public class Orders
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title{ get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
