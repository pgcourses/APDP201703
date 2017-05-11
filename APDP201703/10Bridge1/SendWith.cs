﻿using System;

namespace _10Bridge1
{
    /// <summary>
    /// Concrete implementor
    /// </summary>
    public class SendWith : ISendWith
    {
        public void Send(EmailMessage message)
        {
            Console.WriteLine("A következő üzenetet elküldtük a teszt szervizből:");
            Console.WriteLine("Küldő: {0}", message.From.Address);
            Console.WriteLine("Címzett: {0}", message.To.Address);
            Console.WriteLine("Tárgy: {0}", message.Subject);
            Console.WriteLine("Üzenet: {0}", message.Message);
        }
    }
}