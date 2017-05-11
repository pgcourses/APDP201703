namespace _10Bridge1
{
    /// <summary>
    /// Dekorátor minta példa:
    /// ha nem férünk hozzá az eredeti kódhoz, és szeretnénk (egy kicsit)
    /// megváltoztatni a működését, akkor használjuk. Az eredeti példány Dependency Injection-nel
    /// ide megérkezik, meg is hívjuk, de a hívás előtt elvégezhetünk kisebb dolgokat.
    /// 
    /// További feltétel, hogy mi kezeljük a felhasználó oldali kódot, 
    /// így a saját felületünk megjelenése nem okoz gondot. (TODO)
    /// </summary>
    public class EmailServiceWithLogger : EmailService
    {
        private EmailService service;

        public EmailServiceWithLogger(EmailService service, AbstractSendWith sendWith) 
            : base(sendWith)
        {
            this.service = service;
        }

        public new void Send(EmailMessage message)
        {
            //Itt tudjuk a működést befolyásolni
            System.Console.WriteLine("------>-------> Levélküldés eleje");
            service.Send(message);
            System.Console.WriteLine("------>-------> Levélküldés vége");
        }

    }
}