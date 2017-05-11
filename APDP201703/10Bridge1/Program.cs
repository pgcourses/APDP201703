using Ninject;
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
        private static StandardKernel kernel;

        static void Main(string[] args)
        {
            //A híd minta bevezetéséhez és tesztjéhez
            //TestBridge1();

            //Fel kell paraméterezni a Ninject-et:
            kernel = new StandardKernel();
            kernel.Bind<IPersonRepository>()
                  //.To<PersonRepositoryTestData>()
                  .To<PersonRepositorySimpleData>()
                  .InSingletonScope();

            //Console.WriteLine();
            //Console.WriteLine("++++++++ +++++++++++++ +++++++++++++++++");
            //Console.WriteLine();

            //A dekorátor/proxy/facade
            //TestBridgeAndDecoratorAndProxy();

            //A létrehozásokat becsomagoljuk egy speciális stratégiába, majd
            //a stratégiapéldányt átadjuk a szervíznek használatra.

            var birthdayMessageFactoryWithExchange = new BirthdayMessageFactoryWithExchange();
            var msgService = new MessageService(birthdayMessageFactoryWithExchange);

            msgService.Run();

            //Console.WriteLine();
            //Console.WriteLine("++++++++ +++++++++++++ +++++++++++++++++");
            //Console.WriteLine();

            var factory = new WelcomeMessageFactoryWithSendGrid();
            msgService = new MessageService(factory);

            msgService.Run();
            Console.ReadLine();

        }

        private static void TestBridgeAndDecoratorAndProxy()
        {
            var officeAddress = EmailAddressFactory.GetOfficeAddress();

            //előre tudom, hogy hidat akarok használni,
            //leválasztom a konkrét megvalósítást a használattól
            //ez az adatok tárolásánál a repository minta

            //EZ HELYETT
            //var repo = new PersonRepository();
            //EZ: Repo példányosítása DI framework-kel
            //https://www.hanselman.com/blog/ListOfNETDependencyInjectionContainersIOC.aspx
            //https://ayende.com/blog/2886/building-an-ioc-container-in-15-lines-of-code
            //http://kenegozi.com/blog/2008/01/17/its-my-turn-to-build-an-ioc-container-in-15-minutes-and-33-lines
            //http://blogs.clariusconsulting.net/kzu/funq-screencast-series-on-how-to-building-a-di-container-using-tdd/
            //http://structuremap.github.io/quickstart/

            //amit használunk, az a ninject: http://www.ninject.org/
            var repo = kernel.Get<IPersonRepository>();

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

            var message = EmailMessage.Factory
            (
                from: officeAddress,
                to: person.EmailAddress,
                subject: "üdvözlet",
                message: "Boldog születésnapot"
            );

            serviceWithLogger.Send(message);
        }

        private static void TestBridge1()
        {
            EmailMessage message = EmailMessage.Factory(
                from: EmailAddressFactory.GetNewAddress(address: "egy@teszt.hu", display: "az első cím"), 
                to: EmailAddressFactory.GetNewAddress(address: "ketto@teszt.hu", display: "a második cím"),
                subject: "tesztüzenet", 
                message: "ez egy tesztüzenet, amit egy küld a kettőnek");


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
