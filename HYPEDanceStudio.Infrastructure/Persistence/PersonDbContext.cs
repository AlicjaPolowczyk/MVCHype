using HYPEDanceStudio.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Infrastructure.Persistence
{
    public class PersonDbContext : IdentityDbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Domain.Entities.Assignment> Assignemnts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                .OwnsOne(c=>c.ContactDetails);

            

        }

    }
}
