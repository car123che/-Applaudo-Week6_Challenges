using Microsoft.EntityFrameworkCore;
using EFMovieRentalDomain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUnivestityRentalData
{
    public class MovieConfiguration: IEntityTypeConfiguration<Movie>
    {
       

        public void Configure(EntityTypeBuilder<Movie> builder)
        {

            // ----- Varchar ------
            builder.Property(p => p.Title).HasMaxLength(35);
            builder.Property(p => p.Description).HasMaxLength(100);
            builder.Property(p => p.TrailerLink).HasMaxLength(500);


            // ------ Index ------------
            builder.HasIndex(h => h.Title);
            builder.HasIndex(h => h.SalePrice);

            // SEEDING DATA
            builder.HasData(
                    new Movie { Id = 1, Title = "Avengers", Description = "Marvel Studios Avenger", PosterStock = 5, TrailerLink = "Avengers.com", SalePrice = 10.52, Likes = 80 },
                    new Movie { Id = 2, Title = "Avengers 2", Description = "Marvel Studios Avenger", PosterStock = 4, TrailerLink = "Avengers.com", SalePrice = 13.52, Likes = 90 },
                    new Movie { Id = 3, Title = "El origen", Description = "Dicaprio el origen", PosterStock = 3, TrailerLink = "ELROGINE.COM", SalePrice = 12.52, Likes = 50 },
                    new Movie { Id = 4, Title = "Nemo", Description = "Nemo nemo", PosterStock = 4, TrailerLink = "Nemo.com", SalePrice = 9.52, Likes = 70 }
            );




        }

    }
}
