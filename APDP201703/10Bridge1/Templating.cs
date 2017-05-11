using System;

namespace _10Bridge1
{
    public class Templating
    {
        public EmailMessage GetMessageFor(Person person)
        {
            var from = EmailAddressFactory.GetOfficeAddress();
            var to = EmailAddressFactory.GetNewAddress(person.EmailAddress.Address, person.EmailAddress.Display);

            string subject = GetSubject(person);
            string message = GetMessage(person);

            return EmailMessage.Factory(from, to, subject, message);

        }

        private string GetMessage(Person person)
        {
            return $"Kedves {person.Name}! A cég nevében szeretnénk boldog születésnapot kívánni";
        }

        private string GetSubject(Person person)
        {
            return "Születésnapi üdvözlet";
        }
    }
}