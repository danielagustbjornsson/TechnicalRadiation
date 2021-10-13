using System.Dynamic;
using System.Text.Json.Serialization;
//using Newtonsoft.Json;

namespace TechnicalRadiation.Models
{
    public class HyperMediaModel
    {
        public HyperMediaModel() { Links = new ExpandoObject(); }
        [JsonPropertyName("_links")]
        public ExpandoObject Links { get; set; }
    }
}