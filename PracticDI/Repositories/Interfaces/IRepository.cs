using PracticDI.Models;

namespace PracticDI.Repositories.Interfaces
{
    public interface IRepository
    {
        List<Person> GetPersons();
        void AddPerson(Person person);
        void DeletePerson(int id);
        void SavePerson();
    }
}
