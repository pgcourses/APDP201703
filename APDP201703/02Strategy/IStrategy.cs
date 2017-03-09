using System.Collections.Generic;
using _01Adapter;

namespace _02Strategy
{
    public interface IStrategy
    {
        int Operation(IList<Address> list);
    }
}