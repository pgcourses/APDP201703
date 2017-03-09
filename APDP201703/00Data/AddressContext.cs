using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00Data
{
    public class AddressContext : DbContext
    {
        public DbSet<MyAddress> MyAddresses { get; set; }
    }
}
