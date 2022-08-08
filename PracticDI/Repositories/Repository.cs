using PracticDI.Repositories.Interfaces;
using PracticDI.Models;
using PracticDI.Data;

namespace PracticDI.Repositories
{
    public class Repository : IRepository
    {
        private readonly DBPersonContext _context;
        public void AddPerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }

        public List<Person> GetPersons()
        {
            // В экземпляре объекта не задана ссылка на объект."
            return _context.Persons.ToList();
        }
    }
}
