using _01Adapter.Resource;
using System;
using System.Collections.Generic;
using System.Data;

namespace _01Adapter
{
    /// <summary>
    /// 
    ///    Repository ----()------> Adatok(adatbázis)
    ///    ebből indirekcióval
    ///    Repository ----> IDbDataAdapter ------> Adatbázis
    /// 
    /// </summary>
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
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            var list = new List<Address>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                list.Add(new Address { EMail = row.Field<string>(GlobalStrings.TableColumnEMailAddress) });
            }

            return list;
        }
    }
}