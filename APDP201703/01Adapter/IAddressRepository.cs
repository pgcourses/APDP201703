using System.Collections.Generic;

namespace _01Adapter
{
    public interface IAddressRepository
    {
        IList<Address> GetAddresses();
    }
}