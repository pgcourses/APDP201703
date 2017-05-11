using System;

namespace _10Bridge1
{
    public class BirthdayTemplating : AbstractTemplating
    {
        protected override string GetMessage(Person person)
        {
            return $"Kedves {person.Name}! A cég nevében szeretnénk boldog születésnapot kívánni";
        }

        protected override string GetSubject(Person person)
        {
            return "Születésnapi üdvözlet";
        }
    }
}