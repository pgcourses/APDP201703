using System.Collections.Generic;

namespace _10Bridge1
{
    public interface IPersonRepository
    {
        Person GetBirthdayPersons();
        List<Person> GetPersonForMessages();
    }
}