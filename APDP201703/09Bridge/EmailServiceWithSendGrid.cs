using System;

namespace _09Bridge
{
    public class EmailServiceWithSendGrid : EmailService
    {
        public string ApiKey { get; set; }
        public string HostUrl { get; internal set; }

        public override void Send(EmailMessage message)
        {
            Console.WriteLine("A következő üzenetet elküldtük a SendGrid szervizből API-val.");
            Console.WriteLine("HostUrl: {0}", HostUrl);
            Console.WriteLine("ApiKey: {0}", ApiKey);
            Console.WriteLine("Küldő: {0}", message.From.Address);
            Console.WriteLine("Címzett: {0}", message.To.Address);
            Console.WriteLine("Tárgy: {0}", message.Subject);
            Console.WriteLine("Üzenet: {0}", message.Message);
        }
    }
}