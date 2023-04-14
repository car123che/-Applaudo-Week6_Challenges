using EFMovieRentalDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUnivestityRentalData
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            // ----- Varchar ------
            builder.Property(p => p.Name).HasMaxLength(35);
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.Property(p => p.Phone).HasMaxLength(15);


            // ------ Index ------------
            builder.HasIndex(h => h.Email);

            // SEEDING DATA
            builder.HasData(
                    new User { Id = 1, Name = "Carlos Che", Age = 22, Email = "car123che@gmail.com", Phone = "41907419"},
                    new User { Id = 2, Name = "Agustin Mijangos", Age = 22, Email = "move123@gmail.com", Phone = "4587894" }
            );


        }
    }
}
