using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accesa.SportsBuddy.DTO;
namespace Accesa.SportsBuddy.DTO
{
    public class AddressSportCenterDTO
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
