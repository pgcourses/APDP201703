using System;

namespace _09Bridge
{
    public class EmailServiceWithExchange : EmailService
    {
        /// <summary>
        /// Az exchange szerver címe
        /// </summary>
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public override void Send(EmailMessage message)
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