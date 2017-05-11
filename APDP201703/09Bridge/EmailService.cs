using System;

namespace _09Bridge
{
    public class EmailService
    {

        public void Send(EmailMessage message)
        {
            Console.WriteLine("A következő üzenetet elküldtük:");
            Console.WriteLine("Küldő: {0}", message.From.Address);
            Console.WriteLine("Címzett: {0}", message.To.Address);
            Console.WriteLine("Tárgy: {0}", message.Subject);
            Console.WriteLine("Üzenet: {0}", message.Message);
        }
    }
}