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
    public class MovieTagConfiguration : IEntityTypeConfiguration<MovieTag>
    {

        public void Configure(EntityTypeBuilder<MovieTag> builder)
        {

            // SEEDING DATA
            builder.HasData(
                   new MovieTag { Id = 1, MovieId = 1, TagId = 1 },
                   new MovieTag { Id = 2, MovieId = 1, TagId = 2 },
                   new MovieTag { Id = 3, MovieId = 2, TagId = 1 },
                   new MovieTag { Id = 4, MovieId = 2, TagId = 2 },
                   new MovieTag { Id = 5, MovieId = 3, TagId = 3 },
                   new MovieTag { Id = 6, MovieId = 4, TagId = 6 }
                   );


        }
    }
}
