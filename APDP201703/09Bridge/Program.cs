using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09Bridge
{
    /// <summary>
    /// Feladat: egy olyan rendszer, ami különböző fajtájú üzeneteket képes kezelni:
    /// létrehozni, menteni, küldeni, megjeleníteni
    /// az ehhez szükséges infrastruktúra (címek, személyek) kezelése
    /// </summary>
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

            var service = new EmailService();
            service.Send(message);
            Console.WriteLine();


            var serviceMsx = new EmailServiceWithExchange();
            serviceMsx.Host = "1.1.1.1";
            serviceMsx.UserName = "MSXUser";
            serviceMsx.Password = "MSXPassword";
            serviceMsx.Send(message);
            Console.WriteLine();

            var serviceSG = new EmailServiceWithSendGrid();
            serviceSG.HostUrl = "https://sendgrid.service.com";
            serviceSG.ApiKey = "SG-APIKEY";
            serviceSG.Send(message);
            Console.WriteLine();

            var serviceM = new EmailServiceWithMandrill();
            serviceM.HostUrl = "https://api.mandrill.com";
            serviceM.ClientSecret = "MANDRILL-SECRET";
            serviceM.ClientKey = "MANDRILL-KEY";
            serviceM.Send(message);
            Console.ReadLine();

        }
    }
}
