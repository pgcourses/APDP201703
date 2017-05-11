using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Bridge1
{
    /// <summary>
    /// Adapter minta: implementáció UTÁN, két meglévő osztály összekötéséhez használjuk
    /// (Értelmes módon, az újrafelhasználhatóság megtartásával, összekötünk két egymással 
    /// jelenleg nem együttműködő osztályt.
    /// 
    /// Híd minta: implementáció ELŐTT eleve olyan szerkezetet hozunk létre, ahol gyenge csatolás miatt
    /// az egyes elemek lecserélhetőek.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //A híd minta bevezetéséhez és tesztjéhez
            TestBridge1();

            //A dekorátor/proxy/facade
            //TestBridgeAndDecoratorAndProxy();

            Console.ReadLine();

        }

        private static void TestBridgeAndDecoratorAndProxy()
        {
            var officeAddress = new EmailAddress { Address = "iroda@hivatali.hu", Display = "Az iroda email címe" };

            //előre tudom, hogy hidat akarok használni,
            //leválasztom a konkrét megvalósítást a használattól
            //ez az adatok tárolásánál a repository minta
            var repo = new PersonRepository();

            //csak példa, ilyeneket lehet csinálni a repoban, de most nem kell
            //var person = repo.Get(1); 
            //var person = repo.Create(person); 
            //var person = repo.Delete(person); 
            //var person = repo.Update(person); 

            var person = repo.GetBirthdayPersons();

            var sendWith = AbstractSendWith.Factory<SendWith>();
            var service = new EmailService(sendWith);
            //készítünk egy olyan szervizt, ami naplót is készít
            //ezt dekorátor mintával tudjuk megtenni, ha a szerviz kódját nem módosíthatjuk.

            //Akkor működik, ha a függvény, amit dekorálni akarok virtuális VAGY
            //akkor működik, ha a saját felületemet tudom használni
            var serviceWithLogger = new EmailServiceWithLogger(service, sendWith);

            //Ha az eredeti felületet kell használnom, ÉS nem virtuális az eredeti függvény, 
            //akkor nem fogja meghívni semmi az én függvényemet, ez így sosem fog naplózni.
            //EmailService serviceWithLogger = new EmailServiceWithLogger(service, sendWith);

            //PROXY minta: ha a proxy osztály felületének a használatát ki lehet kényszeríteni.
            //egyéb nevek: Wrapper/burkoló
            var serviceProxy = new EmailServiceProxy(service, sendWith);

            //A proxy osztályt akkor használjuk, ha például
            // - a fejlesztéskor nem áll rendelkezésre a végleges megvalósítás
            // - hálózaton keresztül kapcsolódunk, és szeretnénk tesztet írni,
            //   - jogosultságot implementálni
            //   - cache-t implementálni.

            //Facade: amikor az eredeti osztály felülete nagyon bonyolult, akkor
            //        egy egyszerű könnyebben felhasználható felületet adunk.
            // Például:
            //       Sok komolyabb workflow-t implementáló WebAPI ad saját kliens könyvtárat.
            //       Például: Paypal fizetés

            var message = new EmailMessage
            {
                From = officeAddress,
                To = person.EmailAddress,
                Subject = "üdvözlet",
                Message = "Boldog születésnapot"
            };

            serviceWithLogger.Send(message);
        }

        private static void TestBridge1()
        {
            var message = new EmailMessage
            {
                From = new EmailAddress { Address = "egy@teszt.hu", Display = "az első cím" },
                To = new EmailAddress { Address = "ketto@teszt.hu", Display = "a második cím" },
                Subject = "tesztüzenet",
                Message = "ez egy tesztüzenet, amit egy küld a kettőnek"
            };

            //Concrete implementor
            var strategy = AbstractSendWith.Factory<SendWith>();

            //Abstraction
            var service = new EmailService(strategy);
            service.Send(message);
            Console.WriteLine();

            //Concrete implementor
            var strategyMsx = AbstractSendWith.Factory<SendWithExchange>();

            //vegyük észre: nem kell új szerviz típust példányositani
            service = new EmailService(strategyMsx);
            service.Send(message);
            Console.WriteLine();
            //Concrete implementor
            var strategySG = AbstractSendWith.Factory<SendWithSendGrid>();

            service = new EmailService(strategySG);
            service.Send(message);
            Console.WriteLine();
            //Concrete implementor
            var strategyM = AbstractSendWith.Factory<SendWithMandrill>();

            service = new EmailService(strategyM);
            service.Send(message);

        }
    }
}
