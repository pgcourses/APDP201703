using System;
using System.Collections.Generic;
using _01Adapter;
using System.Linq;

namespace _02Strategy
{
    public class AvgStrategy : IStrategy
    {
        public int Operation(IList<Address> list)
        {
            return (int)list.Average(x => x.EmailCount);
        }
    }
}