using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class AdministratedSportCenter
    {
        public int Id { get; set; }
        public int SportCenterAdminId { get; set; }
        public int SportCenterId { get; set; }

        public virtual SportCenter SportCenter { get; set; }
        public virtual SportCenterAdmin SportCenterAdmin { get; set; }
    }
}
