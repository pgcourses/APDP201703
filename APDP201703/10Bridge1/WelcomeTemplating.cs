using System;

namespace _10Bridge1
{
    public class WelcomeTemplating : AbstractTemplating
    {
        protected override string GetMessage(Person person)
        {
            return $"Kedves {person.Name}! A cég nevében szeretnénk üdvözölni a cégnél";
        }

        protected override string GetSubject(Person person)
        {
            return "Üdvözlet az új kollégáknak";
        }
    }
}