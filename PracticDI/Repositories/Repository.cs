using PracticDI.Repositories.Interfaces;
using PracticDI.Models;
using PracticDI.Data;

namespace PracticDI.Repositories
{
    public class Repository : IRepository
    {
        private readonly DBPersonContext _context;

        public Repository (DBPersonContext context)
        {
            _context = context;
        }

        public void AddPerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void DeletePerson(int id)
        {
            var person = _context.Persons.Find(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges();
            }
        }

        public List<Person> GetPersons()
        {
            var persons = from p in _context.Persons select p;
            // В экземпляре объекта не задана ссылка на объект."
            return persons.ToList();
        }

        public void SavePerson()
        {
            using (FileStream fs = new FileStream("/Test/test.txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    var people = GetPersons();
                    foreach (var i in people)
                    {
                        sw.WriteLine(i.Name + " " + i.Surname + " " + i.BirthDay + 
                            " " + i.OtherInfo);
                    }
                }
            }
        }
    }
}
