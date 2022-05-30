using System;
using System.Collections.Generic;

#nullable disable

namespace Accesa.SportsBuddy.Database.Models
{
    public partial class SportCenter
    {
        public SportCenter()
        {
            AdministratedSportCenters = new HashSet<AdministratedSportCenter>();
            TrainerSportCenters = new HashSet<TrainerSportCenter>();
            TrainingPrograms = new HashSet<TrainingProgram>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Address { get; set; }

        public virtual Address AddressNavigation { get; set; }
        public virtual ICollection<AdministratedSportCenter> AdministratedSportCenters { get; set; }
        public virtual ICollection<TrainerSportCenter> TrainerSportCenters { get; set; }
        public virtual ICollection<TrainingProgram> TrainingPrograms { get; set; }
    }
}
