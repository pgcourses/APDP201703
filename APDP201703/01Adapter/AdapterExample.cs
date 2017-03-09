using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace _01Adapter
{
    public class AdapterExample
    {
        public void Start()
        {
            // 1. legyen egy adatforrásunk
            ///////////////////////////////
            //ehelyett
            //var list = new List<string> { "gabor.plesz@gmail.com" };

            //egyik nagy előny, ha tervezési mintákat használunk
            //a KÖZÖS NYELV
            //ezért: az adatokat szolgáltató osztály neve: Repository
            var repo = new AddressRepository();


            // 2. legyen egy e-mail megoldásunk (=üzenetküldő megoldás)
            ///////////////////////////////////////////////////////////

            //var message = new MailMessage();
            //message.To.Add(new MailAddress("email cím"));
            //stb.

            //Ha ezzel a megoldással szeretnénk e-mailt küldeni, akkor 
            //hozzákötjük magunkat az SMTP küldéshez .NET megoldással.

            //Pedig van sendgrid/mailchimp
            //lehet, hogy sms-t akarunk majd később küldeni
            //stb.

            //a kód újrafelhasználhatóságának feltétele és biztosítéka,
            //ha az osztályaink/objektumainkra ez igaz_
            //High cohesion - low coupling

            // erős kohézió
            // gyenge csatolás

            //csatolás: két objektum akkor van csatolásban
            //ha az egyik módosítása NEM ZÁRJA KI a másik megváltozását.
            //minél erősebb a csatolás, annál valószínűbb, hogy meg is változik a második objektum.

            // [egyik objektum] ------ (csatolás) ------> [másik objektum]

            //mit lehet ellene tenni: indirekció:

            // [egyik objektum] ------ (csatolás) ------> [koztes objektum] ------ (csatolás) ------> [másik objektum]

            //így a két szélső objektum, ha jól csináljuk, akkor már nincs egymással kapcsolatban

            //Tehát indirekció: készítünk egy köztes osztályt
            var messageService = new MessageService();

            //és ezeket kössük össze
            var addressList = repo.GetAddresses();

            foreach (var address in addressList)
            {
                messageService.AddMessage(to: address.EMail, subject: "Ez az üzenet címe", text: "Ez az üzenet szövege");
            }

            messageService.SendMessages();


        }
    }
}