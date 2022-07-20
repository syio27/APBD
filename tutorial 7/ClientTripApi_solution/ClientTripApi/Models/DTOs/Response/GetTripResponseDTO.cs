using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTripApi.Models.DTOs.Response
{
    public class GetTripResponseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }

        public virtual ICollection<CountryTrip> Countries { get; set; }
        public virtual ICollection<ClientTrip> Clients { get; set; }
    }
}
