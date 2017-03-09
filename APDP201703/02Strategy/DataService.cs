using _01Adapter;
using System;

namespace _02Strategy
{
    public class DataService
    {
        private IAddressRepository repository;

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
        private IAddressRepository repository;

        public DataService2(IAddressRepository repository) 
            : base(repository) //mivel nincs alapértelmezett konstruktora, hiszen definiáltam egy paraméterest
        {
            if (repository == null) { throw new ArgumentNullException(nameof(repository)); }
            this.repository = repository;
        }

        //public new int Report(ReportType rt)
        //{

        //}

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