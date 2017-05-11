using System;

namespace _10Bridge1
{   
    /// <summary>
    /// Concrete implementor
    /// </summary>
    public class SendWithMandrill : AbstractSendWith
    {
        public string ClientKey { get; set; }
        public string ClientSecret { get; set; }
        public string HostUrl { get; set; }

        public override void Send(EmailMessage message)
        {
            Console.WriteLine("A következő üzenetet elküldtük a Mandrill szervizből API-val.");
            Console.WriteLine("HostUrl: {0}", HostUrl);
            Console.WriteLine("ClientSecret: {0}", ClientSecret);
            Console.WriteLine("ClientKey: {0}", ClientKey);
            Console.WriteLine("Küldő: {0}", message.From.Address);
            Console.WriteLine("Címzett: {0}", message.To.Address);
            Console.WriteLine("Tárgy: {0}", message.Subject);
            Console.WriteLine("Üzenet: {0}", message.Message);
        }

        protected override void Setup()
        {
            HostUrl = "https://api.mandrill.com";
            ClientSecret = "MANDRILL-SECRET";
            ClientKey = "MANDRILL-KEY";
        }
    }
}