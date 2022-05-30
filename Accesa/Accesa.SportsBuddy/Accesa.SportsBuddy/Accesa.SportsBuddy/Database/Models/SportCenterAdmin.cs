using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class SportCenterAdmin
    {
        public SportCenterAdmin()
        {
            AdministratedSportCenters = new HashSet<AdministratedSportCenter>();
            EventCreatedBySportCenters = new HashSet<EventCreatedBySportCenter>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<AdministratedSportCenter> AdministratedSportCenters { get; set; }
        public virtual ICollection<EventCreatedBySportCenter> EventCreatedBySportCenters { get; set; }
    }
}
