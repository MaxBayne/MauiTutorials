using Api.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }

        public DbSet<Person> Persons { get; set; }

    }
}
