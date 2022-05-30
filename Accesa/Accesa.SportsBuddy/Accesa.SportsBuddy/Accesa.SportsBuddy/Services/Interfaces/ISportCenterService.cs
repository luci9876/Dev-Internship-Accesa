using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services.Interfaces
{
    public interface ISportCenterService
    {
        ISportCenterRepository SportCenters {get;set;}
        Address AddressUpdate(Address address,SportCenterDTO sportCenterDTO);
    }
}
