using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsApi.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }
        public string BirthDate { get; set; }
        public Studies Studies { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   IndexNumber == student.IndexNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IndexNumber);
        }
    }
}
