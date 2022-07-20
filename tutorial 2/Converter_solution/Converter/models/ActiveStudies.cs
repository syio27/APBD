using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Converter.models
{
    [Serializable]
    public class ActiveStudies
    {
        private string _name;

        private int _count;

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("numberOfStudents:")]
        public int Count { get; set; }
    }
}
