using System;
using System.Collections.Generic;
using System.Data;

namespace _01Adapter
{
    public class AddressDbDataAdapterRepository : IAddressRepository
    {
        private IDbDataAdapter adapter;

        public AddressDbDataAdapterRepository(IDbDataAdapter adapter)
        {
            if (adapter == null) { throw new ArgumentNullException(nameof(adapter)); }
            this.adapter = adapter;
        }

        public IList<Address> GetAddresses()
        {
            throw new NotImplementedException();
        }
    }
}