﻿using System;
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
            //TestBridge1();

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

            var sendWith = new SendWith();
            var service = new EmailService(sendWith);

            var message = new EmailMessage
            {
                From = officeAddress,
                To = person.EmailAddress,
                Subject = "üdvözlet",
                Message = "Boldog születésnapot"
            };

            service.Send(message);

            Console.ReadLine();

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

            //Concrete implementor
            var strategySG = new SendWithWithSendGrid();
            strategySG.HostUrl = "https://sendgrid.service.com";
            strategySG.ApiKey = "SG-APIKEY";

            service = new EmailService(strategySG);
            service.Send(message);
            Console.WriteLine();

            //Concrete implementor
            var strategyM = new SendWithMandrill();
            strategyM.HostUrl = "https://api.mandrill.com";
            strategyM.ClientSecret = "MANDRILL-SECRET";
            strategyM.ClientKey = "MANDRILL-KEY";

            service = new EmailService(strategyM);
            service.Send(message);

        }
    }
}
