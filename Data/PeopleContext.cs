using EFDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //dodajemy parę kluczy do tabeli pośredniczącej do relacji many to many
            builder.Entity<PersonGroup>()
            .HasKey(pg => new { pg.PersonId, pg.GroupId });
            //w tabeli posredniczacej PersonGroup
            builder.Entity<PersonGroup>()
            .HasOne<Person>(pg => pg.Person) // dla jednej osoby
            .WithMany(p => p.PersonGroups) // jest wiele PersonGroups
            .HasForeignKey(p => p.PersonId); // a powizanie jest realizowane przez klucz obcy PersonId
                                             //w tabeli posredniczacej PersonGroup
            builder.Entity<PersonGroup>()
            .HasOne<Group>(pg => pg.Group) // dla jednej grupy
            .WithMany(g => g.PersonGroups) // jest wiele PersonGroups
            .HasForeignKey(g => g.GroupId); // a powizanie jest realizowane przez klucz obcy GroupId
        }
    }
}
