using Accesa.SportsBuddy.Database;
using Accesa.SportsBuddy.Database.Models;
using Accesa.SportsBuddy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Accesa.SportsBuddy.DTO;
using AutoMapper;
using Accesa.SportsBuddy.Services;

namespace Accesa.SportsBuddy.Repositories
{
    public class SportCenterRepository : GenericRepository<SportCenter>, ISportCenterRepository
    {
        private readonly IMapper _mapper;
        public SportCenterRepository(SportsBuddyDBContext dBContext, IMapper mapper) : base(dBContext)
        {
            _mapper = mapper;
        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }

        public SportCenterDTO CreateSportCenter(SportCenterDTO sportCenterDto)
        {
            try
            {
                if (sportCenterDto == null || sportCenterDto.Name == null)
                {
                    throw new Exception("The record is null");
                }
                SportCenter sportcenter = new SportCenter
                {
                    Name = sportCenterDto.Name
                };
                if (!sportCenterDto.Address.HasValue || (SportsBuddyDBContext.Addresses.Where(a => a.Id == sportCenterDto.Address).SingleOrDefault() == null))
                {
                    if (sportCenterDto.AddressNavigation == null)
                    {
                        throw new Exception("The address is null");
                    }
                    Address address = _mapper.Map<Address>(sportCenterDto.AddressNavigation);
                    SportsBuddyDBContext.Add(address);
                    SportsBuddyDBContext.SaveChanges();
                    sportcenter.Address = address.Id;
                }
                else
                {
                    sportcenter.Address = (int)sportCenterDto.Address;
                }
                SportsBuddyDBContext.Add(sportcenter);
                SportsBuddyDBContext.SaveChanges();
                var result = _mapper.Map<SportCenterDTO>(sportcenter);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public void DeleteSportCenterById(int id)
        {
            try
            {
                var result = SportsBuddyDBContext.SportCenters.SingleOrDefault(s => s.Id == id);
                if (result != null)
                {
                    SportsBuddyDBContext.SportCenters.Remove(result);
                    SportsBuddyDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Invalid Id");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public void EditSportCenter(int id, SportCenterDTO sportCenterDto)
        {
            try
            {
                var sportcenter = SportsBuddyDBContext.SportCenters.SingleOrDefault(s => s.Id == id);
                if (sportcenter == null || sportCenterDto == null)
                {
                    throw new Exception("The record is null");
                }
                if (sportCenterDto.Name != null)
                {
                    sportcenter.Name = sportCenterDto.Name;
                }
                bool existsAddressNavigation = (sportCenterDto.AddressNavigation != null);
                var addressIdValue = SportsBuddyDBContext.Addresses.Where(a => a.Id == sportCenterDto.Address).SingleOrDefault();
                if (!sportCenterDto.Address.HasValue || addressIdValue == null)
                {
                    if (!existsAddressNavigation)
                    {
                        throw new Exception("The address is null");
                    }
                    Address address = _mapper.Map<Address>(sportCenterDto.AddressNavigation);
                    SportsBuddyDBContext.Add(address);
                    SportsBuddyDBContext.SaveChanges();
                    sportcenter.Address = address.Id;
                    
                }
                else
                {
                    if (existsAddressNavigation)
                    {
                        var sportCenterService = new SportCenterService(SportsBuddyDBContext);
                        addressIdValue = sportCenterService.AddressUpdate(addressIdValue, sportCenterDto);
                        SportsBuddyDBContext.SaveChanges();

                    }
                    sportcenter.Address = addressIdValue.Id;
                    SportsBuddyDBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public IEnumerable<SportCenter> GetAllSportCenters()
        {
            try
            {
                return SportsBuddyDBContext.SportCenters.Include(s => s.AddressNavigation);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public SportCenter GetSportCenterById(int id)
        {
            try
            {
                return SportsBuddyDBContext.SportCenters.Include(a => a.AddressNavigation).SingleOrDefault(s => s.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
