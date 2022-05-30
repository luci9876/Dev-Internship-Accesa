using Accesa.SportsBuddy.Database;
using Accesa.SportsBuddy.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accesa.SportsBuddy.Repositories.Interfaces
{
    public class AddressRepository : GenericRepository<AddressRepository>, IAddressRepository
    {
        public AddressRepository(SportsBuddyDBContext dBContext) : base(dBContext)
        {

        }

        public SportsBuddyDBContext SportsBuddyDBContext
        {
            get { return Context as SportsBuddyDBContext; }
        }
        
        public int AddAddress(Address address)
        {
            SportsBuddyDBContext.Addresses.Add(address);
            SportsBuddyDBContext.SaveChanges();
            return address.Id;  
        }

    }
}
