using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PracticDI.Models;
using PracticDI.Repositories.Interfaces;

namespace PracticDI.Pages.View
{
    public class IndexModel : PageModel
    {
        private readonly IRepository _repository;

        [BindProperty]
        public Person person { get; set; }
        public IndexModel(IRepository repository)
        {
            _repository = repository;
        }
        public List<Person> persons { get; set; }
        public void OnGet()
        {
            persons = _repository.GetPersons();
        }

        public IActionResult OnPost()
        {
            _repository.AddPerson(person);
            return RedirectToPage("");
        }

        public IActionResult OnPostDelete()
        {
            _repository.DeletePerson(person.Id);
            return RedirectToPage("");
        }

        public IActionResult OnPostSaveFile()
        {
            _repository.SavePerson();
            return RedirectToPage("");
        }

    }
}
