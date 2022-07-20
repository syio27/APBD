using Converter.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Converter
{
    class Serializer
    {
        public void Serialize(string toPath, University university)
        {
            var jsonString = JsonSerializer.Serialize(university);
            File.WriteAllText(toPath, jsonString);
        }
    }
}
