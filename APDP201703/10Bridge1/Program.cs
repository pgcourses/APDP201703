using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Bridge1
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new EmailMessage
            {
                From = new EmailAddress { Address = "egy@teszt.hu", Display = "az első cím" },
                To = new EmailAddress { Address = "ketto@teszt.hu", Display = "a második cím" },
                Subject = "tesztüzenet",
                Message = "ez egy tesztüzenet, amit egy küld a kettőnek"
            };

            //Implementor
            var strategy = new SendWith();

            //Abstraction
            var service = new EmailService(strategy);
            service.Send(message);
            Console.WriteLine();

            //Concrete implementor
            var strategyMsx = new SendWithExchange();
            strategyMsx.Host = "1.1.1.1";
            strategyMsx.UserName = "MSXUser";
            strategyMsx.Password = "MSXPassword";

            //vegyük észre: nem kell új szerviz típust példányositani
            service = new EmailService(strategyMsx);
            service.Send(message);
            Console.WriteLine();

            var strategySG = new SendWithWithSendGrid();
            strategySG.HostUrl = "https://sendgrid.service.com";
            strategySG.ApiKey = "SG-APIKEY";

            service = new EmailService(strategySG);
            service.Send(message);
            Console.WriteLine();

            var strategyM = new SendWithMandrill();
            strategyM.HostUrl = "https://api.mandrill.com";
            strategyM.ClientSecret = "MANDRILL-SECRET";
            strategyM.ClientKey = "MANDRILL-KEY";

            service = new EmailService(strategyM);
            service.Send(message);

            Console.ReadLine();
        }
    }
}
