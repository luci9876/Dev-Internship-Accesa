using Accesa.SportsBuddy.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Controllers.Models
{
    public class RegisterAdminModel
    {
        [Required]
        public SportCenterAdminDTO sportCenterAdminDTO;
    }
}
