using _01Adapter;
using _01Adapter.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Strategy
{
    public class AddressStrategyTestRepo : IAddressRepository
    {
        public IList<Address> GetAddresses()
        {
            return new List<Address>
            {
                new Address { EMail = GlobalStrings.TesztEmailAddress1, EmailCount=1, VIP=true },
                new Address { EMail = GlobalStrings.TesztEmailAddress2, EmailCount=7 },
                new Address { EMail = GlobalStrings.TesztEmailAddress3, EmailCount=2 },
                new Address { EMail = GlobalStrings.TesztEmailAddress4, EmailCount=3 },
                new Address { EMail = GlobalStrings.TesztEmailAddress5, EmailCount=9 },
                new Address { EMail = GlobalStrings.TesztEmailAddress6, EmailCount=5, VIP=true },
                new Address { EMail = GlobalStrings.TesztEmailAddress7, EmailCount=3 },
                new Address { EMail = GlobalStrings.TesztEmailAddress8, EmailCount=2 },
                new Address { EMail = GlobalStrings.TesztEmailAddress9, EmailCount=7 },
                new Address { EMail = GlobalStrings.TesztEmailAddress10, EmailCount=10 }
            };
        }
    }
}
