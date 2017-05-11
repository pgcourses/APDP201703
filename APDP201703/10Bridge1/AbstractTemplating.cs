using System;

namespace _10Bridge1
{
    public abstract class AbstractTemplating
    {
        public EmailMessage GetMessageFor(Person person)
        {
            var from = EmailAddressFactory.GetOfficeAddress();
            var to = EmailAddressFactory.GetNewAddress(person.EmailAddress.Address, person.EmailAddress.Display);

            string subject = GetSubject(person);
            string message = GetMessage(person);

            return EmailMessage.Factory(from, to, subject, message);

        }

        protected abstract string GetMessage(Person person);

        protected abstract string GetSubject(Person person);
    }
}