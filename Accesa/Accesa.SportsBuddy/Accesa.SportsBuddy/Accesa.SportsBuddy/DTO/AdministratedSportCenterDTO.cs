using Accesa.SportsBuddy.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.DTO
{
    public partial class AdministratedSportCenterDTO
    {
        public int Id { get; set; }
        public int SportCenterAdminId { get; set; }
        public int SportCenterId { get; set; }
        public SportCenterDTO SportCenter { get; set; }
        public SportCenterAdminAdministratedDTO SportCenterAdmin { get; set; }
    }
}