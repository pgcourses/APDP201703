using System;
using System.Collections.Generic;

namespace _10Bridge1
{
    public class PersonRepositoryTestData : IPersonRepository
    {
        List<Person> data = new List<Person>();
        public PersonRepositoryTestData()
        {
            data.Add(
                    new Person
                    {
                        Name = "Születésnapos Kolléga",
                        EmailAddress = new EmailAddress { Address = "kollega@hivatali.hu", Display = "Céges email" }
                    });
            data.Add(
                    new Person
                    {
                        Name = "Második Kolléga",
                        EmailAddress = new EmailAddress { Address = "kollega2@hivatali.hu", Display = "Céges email" }
                    });
            data.Add(
                    new Person
                    {
                        Name = "Harmadik Kolléga",
                        EmailAddress = new EmailAddress { Address = "kollega3@hivatali.hu", Display = "Céges email" }
                    });
        }

        public Person GetBirthdayPersons()
        {
            return data[0];
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPersonForMessages()
        {
            return data;
        }
    }
}