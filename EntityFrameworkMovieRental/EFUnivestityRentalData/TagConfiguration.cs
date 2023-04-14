using EFMovieRentalDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFUnivestityRentalData
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {

            // ----- Varchar ------
            builder.Property(p => p.Name).HasMaxLength(35);


            // ------ Index ------------
            builder.HasIndex(h => h.Name).IsUnique();
            

            // SEEDING DATA
            builder.HasData(
                     new Tag { Id = 1, Name = "Accion" },
                     new Tag { Id = 2, Name = "Comedia" },
                     new Tag { Id = 3, Name = "Niños" },
                     new Tag { Id = 4, Name = "Suspenso" },
                     new Tag { Id = 5, Name = "Misiones" },
                     new Tag { Id = 6, Name = "Animadas" }
                     );


        }

    }
}
