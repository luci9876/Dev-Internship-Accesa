using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class Address
    {
        public Address()
        {
            EventCreatedBySportCenters = new HashSet<EventCreatedBySportCenter>();
            Events = new HashSet<Event>();
            SportCenters = new HashSet<SportCenter>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public virtual ICollection<EventCreatedBySportCenter> EventCreatedBySportCenters { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<SportCenter> SportCenters { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
