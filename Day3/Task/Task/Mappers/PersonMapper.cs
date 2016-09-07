using Task.Infrastructure;
using Task.Models;

namespace Task.Mappers
{
    public static class PersonMapper
    {
        public static Person ToPerson(this PersonInfoModel person)
        {
            return new Person
            {
                Name = person.Name,
                Age = person.Age,
                Rank = person.Rank,
                Side = person.Side,
                Id = person.Id
            };
        }

        public static PersonInfoModel ToPersonInfoModel(this Person person)
        {
            return new PersonInfoModel
            {
                Name = person.Name,
                Age = person.Age,
                Rank = person.Rank,
                Side = person.Side,
                Id = person.Id
            };
        }
    }
}