using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
//  TABLE Animals(
//        IdAnimal int,
//        Name nvarchar(200),
//	      Description nvarchar(200),
//	      Category nvarchar(200),
//	      Area nvarchar(200),
//	      UNIQUE(IdAnimal)
//);
    public class Animals
    {
        [Required(ErrorMessage = "IdAnimal is requried")]
        public int IdAnimal { get; set; }

        [MaxLength(200, ErrorMessage = "Max length of Name is 200")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Max length of Description is 200")]
        public string Description { get; set; }

        [MaxLength(200, ErrorMessage = "Max length of Category is 200")]
        public string Category { get; set; }

        [MaxLength(200, ErrorMessage = "Max length of Area is 200")]
        public string Area { get; set; }
    }
}
