using System;

namespace _09Bridge
{
    /// <summary>
    /// Az email küldés alaposztálya, ebből kiindulva készítjük el a speciális (konkrét) megoldásokat
    /// </summary>
    public class EmailService
    {

        /// <summary>
        /// Ezt majd minden osztály átírja és a sajátját fogja implementálni
        /// </summary>
        /// <param name="message"></param>
        public virtual void Send(EmailMessage message)
        {
            Console.WriteLine("A következő üzenetet elküldtük a teszt szervizből:");
            Console.WriteLine("Küldő: {0}", message.From.Address);
            Console.WriteLine("Címzett: {0}", message.To.Address);
            Console.WriteLine("Tárgy: {0}", message.Subject);
            Console.WriteLine("Üzenet: {0}", message.Message);
        }
    }
}