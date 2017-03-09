using _01Adapter.Resource;
using System;
using System.Collections.Generic;

namespace _01Adapter
{
    public class AddressTestRepository : IAddressRepository
    {
        public AddressTestRepository()
        {
        }

        public IList<Address> GetAddresses()
        {
            return new List<Address> { new Address { EMail = GlobalStrings.TesztEmailAddress } };
        }
    }
}