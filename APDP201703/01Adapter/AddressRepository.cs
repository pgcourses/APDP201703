using System;
using System.Collections.Generic;

namespace _01Adapter
{
    public class AddressRepository : IAddressRepository
    {
        public AddressRepository()
        {
        }

        public IList<Address> GetAddresses()
        {
            return new List<Address> { new Address { EMail = "gabor.plesz@gmail.com" } };
        }
    }
}