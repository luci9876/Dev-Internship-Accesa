using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace Accesa.SportsBuddy.DTO
{
    public class SportCenterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Address { get; set; }
        public AddressSportCenterDTO AddressNavigation { get; set; }
    }
}
