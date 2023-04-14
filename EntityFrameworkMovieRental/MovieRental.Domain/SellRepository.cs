using EFMovieRentalDomain;
using EFUnivestityRentalData;
using Microsoft.EntityFrameworkCore;
using MovieRental.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Domain
{

    public interface ISellRepository
    {
        Task<string> Sell(int movieId, int userId);
        Task<List<Movie>> GetBoughtMovies(int userId);
    }

    public class SellRepository : ISellRepository
    {
        private static MovieRentalContext context = new MovieRentalContext();
        public async Task<List<Movie>> GetBoughtMovies(int userId)
        {
            var movies = await context.Sells.Include(q => q.Movie).Where(q => q.UserId == userId).Select(
                     q =>
                     new Movie
                     {
                         Title = q.Movie.Title,
                         Description = q.Movie.Description,
                         PosterStock = q.Movie.PosterStock,
                         TrailerLink = q.Movie.TrailerLink,
                         SalePrice = q.Movie.SalePrice,
                         Likes = q.Movie.Likes,
                         Availability = q.Movie.Availability
                     }
                 ).ToListAsync();

            return movies; 
        }

        public async Task<string> Sell(int movieId, int userId)
        {
            var movie = await context.Movies.FindAsync(movieId);
            if (movie is null || movie.Availability < 1)
            {
                throw new MovieNotFoundException($"Movie: {movieId} - not found");
            }


            var user = await context.Users.FindAsync(userId);
            if (user is null)
            {
                throw new UserNotFoundException($"User: {userId} - not found");
            }

            // Restar 1 al stock
            movie.Availability = movie.Availability - 1;

            // Comprar Pelicula
            var movieBought = new EFMovieRentalDomain.Sell() { MovieId = movieId, UserId = userId, SellDate = DateTime.Now.ToString() };
            await context.AddAsync(movieBought);
            // Salvar todos los cambios
            await context.SaveChangesAsync();

            return $"Pelicula {movieId}  comprada correctamente";
        }
    }
}
