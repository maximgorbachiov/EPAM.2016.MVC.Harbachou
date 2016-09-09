using System.Collections.Generic;
using System.Linq;

namespace Task.Infrastructure
{
    public class Repository
    {
        private readonly List<Person> persons = new List<Person>();
        private int currentId;

        public Repository()
        {
            Person myself = new Person
            {
                Name = "Maxim",
                Age = 20,
                Rank = "Djeday",
                Side = true
            };

            Person dartVaider = new Person
            {
                Name = "DartVaider",
                Age = 40,
                Rank = "Right hand of Sith's master",
                Side = false
            };

            Person obivanKenoby = new Person
            {
                Name = "Obivan",
                Age = 50,
                Rank = "Djeday",
                Side = true
            };

            Person badSoldier = new Person
            {
                Name = "Jonh",
                Age = 30,
                Rank = "Usual unit",
                Side = false
            };

            AddPerson(myself);
            AddPerson(obivanKenoby);
            AddPerson(dartVaider);
            AddPerson(badSoldier);
        }

        public int AddPerson(Person person)
        {
            person.Id = currentId++;
            persons.Add(person);

            return person.Id;
        }

        public void RemovePerson(Person person)
        {
            persons.Remove(FindPersonById(person.Id));
        }

        public Person FindPersonById(int id)
        {
            return persons.FirstOrDefault(person => person.Id == id);
        }

        public List<Person> GetAll()
        {
            return persons;
        }

        public void Save(Person personSideState)
        {
            foreach (var person in persons)
            {
                if (person.Id == personSideState.Id)
                {
                    person.Side = personSideState.Side;
                    break;
                }
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Rank { get; set; }

        public bool Side { get; set; }

        public int Id { get; set; }
    }
}