using Accesa.SportsBuddy.Database;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.DTO;
using Accesa.SportsBuddy.Repositories;
using Accesa.SportsBuddy.Repositories.Interfaces;
using Accesa.SportsBuddy.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Services
{
    public class SportCenterService : ISportCenterService
    {
        private readonly SportsBuddyDBContext _context;
        public ISportCenterRepository SportCenters { get; set; }
        public IMapper mapper { get; set; }
        public SportCenterService(SportsBuddyDBContext context)
        {
            _context = context;
            SportCenters = new SportCenterRepository(context, mapper);
        }

        public Address AddressUpdate(Address address, SportCenterDTO sportCenterDto)
        {
            if (!String.IsNullOrWhiteSpace(sportCenterDto.AddressNavigation.City)) address.City = sportCenterDto.AddressNavigation.City;
            if (!String.IsNullOrWhiteSpace(sportCenterDto.AddressNavigation.Country)) address.Country = sportCenterDto.AddressNavigation.Country;
            if (sportCenterDto.AddressNavigation.Latitude.HasValue) address.Latitude = sportCenterDto.AddressNavigation.Latitude;
            if (sportCenterDto.AddressNavigation.Longitude.HasValue) address.Longitude = sportCenterDto.AddressNavigation.Longitude;
            if (!String.IsNullOrWhiteSpace(sportCenterDto.AddressNavigation.PostalCode)) address.PostalCode = sportCenterDto.AddressNavigation.PostalCode;
            if (!String.IsNullOrWhiteSpace(sportCenterDto.AddressNavigation.State)) address.State = sportCenterDto.AddressNavigation.State;
            if (!String.IsNullOrWhiteSpace(sportCenterDto.AddressNavigation.Street)) address.Street = sportCenterDto.AddressNavigation.Street;
            return address;
        }

    }
}
