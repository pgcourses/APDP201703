using System;

namespace _10Bridge1
{
    public class SendWithExchange : ISendWith
    {
        public string Host { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public void Send(EmailMessage message)
        {
            Console.WriteLine("A következő üzenetet elküldtük az Exchange szervizből SMTP-vel.");
            Console.WriteLine("Host: {0}, UserName: {1}", Host, UserName);
            Console.WriteLine("Küldő: {0}", message.From.Address);
            Console.WriteLine("Címzett: {0}", message.To.Address);
            Console.WriteLine("Tárgy: {0}", message.Subject);
            Console.WriteLine("Üzenet: {0}", message.Message);
        }
    }
}