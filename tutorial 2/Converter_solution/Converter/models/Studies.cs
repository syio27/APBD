using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Converter.models
{
    [Serializable]
    public class Studies
    {
        [JsonPropertyName("name")]
        public string StudiesName { get; set; }

        [JsonPropertyName("mode")]
        public string Mode { get; set; }
    }
}
