using System;
using System.Collections.Generic;
using _01Adapter;
using System.Linq;

namespace _02Strategy
{
    public class SumStrategy : IStrategy
    {
        public int Operation(IList<Address> list)
        {
            return list.Sum(x => x.EmailCount);
        }
    }
}