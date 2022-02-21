using BackendTestWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTestWork
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<HistoricPerson> HistoricPersons { get; set; }
    }
}
