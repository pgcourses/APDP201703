using System;

namespace _10Bridge1
{
    /// <summary>
    /// Concrete implementor
    /// </summary>
    public class SendWithExchangeTest : SendWithExchange
    {
        public override void Send(EmailMessage message)
        {
            Console.WriteLine("A következő üzenetet elküldtük az Exchange szervizből SMTP-vel.");
            Console.WriteLine("Host: {0}, UserName: {1}", Host, UserName);
            Console.WriteLine("Küldő: {0}", message.From.Address);
            Console.WriteLine("Címzett: {0}", message.To.Address);
            Console.WriteLine("Tárgy: {0}", message.Subject);
            Console.WriteLine("Üzenet: {0}", message.Message);
        }

        protected override void Setup()
        {
            Host = "1.1.1.1";
            UserName = "MSXUser";
            Password = "MSXPassword";
       }

    }
}