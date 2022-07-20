using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Converter.models
{
    [Serializable]
    public class Student
    {
        [JsonPropertyName("fname")]
        public string FirstName { get; set; }
        [JsonPropertyName("name")]
        public string LastName { get; set; }
        [JsonPropertyName("indexNumber")]
        public string StudentNum { get; set; }
        [JsonPropertyName("birthdate")]
        public DateTime BirthDate { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("mothersName")]
        public string MotherName { get; set; }
        [JsonPropertyName("fathersName")]
        public string FatherName { get; set; }

        public Studies Studies { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   FirstName == student.FirstName &&
                   LastName == student.LastName &&
                   StudentNum == student.StudentNum;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, StudentNum);
        }

        public static bool operator ==(Student left, Student right)
        {
            return EqualityComparer<Student>.Default.Equals(left, right);
        }

        public static bool operator !=(Student left, Student right)
        {
            return !(left == right);
        }
    }
}
