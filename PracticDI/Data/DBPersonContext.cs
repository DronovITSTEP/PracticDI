using Microsoft.EntityFrameworkCore;
using PracticDI.Models;

namespace PracticDI.Data
{
    public class DBPersonContext : DbContext
    {
        public DBPersonContext(DbContextOptions<DBPersonContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; } = default!;
    }
}
