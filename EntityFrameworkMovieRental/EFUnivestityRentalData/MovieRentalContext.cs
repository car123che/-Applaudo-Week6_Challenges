using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EFMovieRentalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUnivestityRentalData
{
    public class MovieRentalContext: DbContext
    {

        public override int SaveChanges()
        {
            //How to intercept what is going to be saved and manipulate it
            var entries = ChangeTracker.Entries().Where(q => q.State == EntityState.Added || q.State == EntityState.Modified); // This returns an Inumerable

            foreach (var item in entries)
            {
                var auditableObject = (BaseDomain)item.Entity;

                if (item.State == EntityState.Added)
                    auditableObject.CreatedDate = DateTime.Now.ToString();

                if (item.State == EntityState.Modified)
                    auditableObject.UpdatedDate = DateTime.Now.ToString();

            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //How to intercept what is going to be saved and manipulate it
            var entries = ChangeTracker.Entries().Where(q => q.State == EntityState.Added || q.State == EntityState.Modified); // This returns an Inumerable

            foreach (var item in entries)
            {
                var auditableObject = (BaseDomain)item.Entity;

                if (item.State == EntityState.Added)
                    auditableObject.CreatedDate = DateTime.Now.ToString();

                if(item.State == EntityState.Modified)
                    auditableObject.UpdatedDate = DateTime.Now.ToString();

            }

            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-KAP3NP1H; Initial Catalog=MovieRental; persist security info=True; Integrated Security=SSPI;")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();  //to use sql server, connection string

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ADD VALIDATION TO OUR TABLES
            modelBuilder.ApplyConfiguration(new MovieConfiguration() );
            modelBuilder.ApplyConfiguration(new TagConfiguration() );
            modelBuilder.ApplyConfiguration(new MovieTagConfiguration() );
            modelBuilder.ApplyConfiguration(new UserConfiguration() );

        }


        public DbSet<Movie> Movies { get; set; }  //set or rules of reading a table
        public DbSet<Tag> Tags { get; set; }  //set or rules of reading a table
        public DbSet<MovieTag> MovieTags { get; set; }  //set or rules of reading a table
        public DbSet<User> Users { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Sell> Sells { get; set; }


    }
}
