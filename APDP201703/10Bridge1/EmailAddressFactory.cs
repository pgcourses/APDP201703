using System;

namespace _10Bridge1
{
    public class EmailAddressFactory
    {
        public static EmailAddress GetNewAddress(string address, string display)
        {
            return new EmailAddress { Address = address, Display = display };
        }
    }
}