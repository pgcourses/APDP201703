using _01Adapter;
using System;

namespace _02Strategy
{
    public class DataService
    {
        //Ha leszármaztatunk, akkor így kell, hogy a leszármaztatott is lássa
        protected IAddressRepository repository;

        public DataService(IAddressRepository repository)
        {
            if (repository == null) { throw new ArgumentNullException(nameof(repository)); }
            this.repository = repository;
        }

        public int GetSumEmailCount()
        {
            var list = repository.GetAddresses();

            var sum = 0;
            foreach (var addr in list)
            {
                sum += addr.EmailCount;
            }

            return sum;
        }

        public int GetAvgEmailCount()
        {
            var sum = GetSumEmailCount();
            var list = repository.GetAddresses();
            return sum / list.Count;
        }

        public virtual int Report(ReportType rt)
        {
            switch (rt)
            {
                case ReportType.Sum:
                    return GetSumEmailCount();
                case ReportType.Average:
                    return GetAvgEmailCount();
                default:
                    throw new ArgumentOutOfRangeException($"{nameof(rt)}: {rt}");
            }
        }

    }

    public class DataService2 : DataService
    {
        public DataService2(IAddressRepository repository) 
            : base(repository) //mivel nincs alapértelmezett konstruktora, hiszen definiáltam egy paraméterest
        {
            if (repository == null) { throw new ArgumentNullException(nameof(repository)); }
            this.repository = repository;
        }

        //Ez egy "új" függvényt definiál, így a két típus már nem lesz felcserélhető
        //public new int Report(ReportType rt)
        //{
        //}

        //Így igen, de ez csak akkor megy, ha az eredeti virtual
        public override int Report(ReportType rt)
        {
            var list = repository.GetAddresses();

            var sum = 0;
            foreach (var addr in list)
            {
                if (addr.VIP)
                {
                    sum += addr.EmailCount;
                }

            }
            return sum;
        }

    }

    public enum ReportType
    {
        Sum, Average
    }
}