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

            Console.ReadLine();

        }
    }
}
