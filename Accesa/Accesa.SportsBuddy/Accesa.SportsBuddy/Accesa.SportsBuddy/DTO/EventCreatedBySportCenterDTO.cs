using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.DTO
{
    public class EventCreatedBySportCenterDTO
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Goal { get; set; }
        public int AddressId { get; set; }
        public DateTime StartDate { get; set; }
        public string Duration { get; set; }

        public AddressDTO Address { get; set; }
        public SportCenterAdminDTO Author { get; set; }
    }
}
