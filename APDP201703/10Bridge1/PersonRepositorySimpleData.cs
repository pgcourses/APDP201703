using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Bridge1
{
    public class PersonRepositorySimpleData : IPersonRepository
    {
        public Person GetBirthdayPersons()
        {
            return new Person
            {
                Name = "Kolléga a második repo-ból",
                EmailAddress = new EmailAddress { Address = "kollegaa2dikrepobol@hivatali.hu", Display = "Céges email" }
            };
        }

        public List<Person> GetPersonForMessages()
        {
            return new List<Person>(new Person[] {
                new Person
                {
                    Name = "Kolléga a második repo-ból",
                    EmailAddress = new EmailAddress { Address = "kollegaa2dikrepobol@hivatali.hu", Display = "Céges email" }
                }
            });
        }
    }
}
