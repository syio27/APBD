using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Converter.models
{
    [Serializable]
    public class University
    {
        private string _author = "Sagidulla Baglan";
        private DateTime _today = DateTime.Today;

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime Today { get; set; }

        public HashSet<Student> Studetns { get; set; }

        public HashSet<ActiveStudies> ActiveStudies { get; set; }

    }
}
