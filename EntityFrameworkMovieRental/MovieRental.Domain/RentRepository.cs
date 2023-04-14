using EFMovieRentalDomain;
using EFMovieRentalDomain.Models;
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
    public interface IRentRepository
    {
        Task<string> Rent(int movieId, int userId);
        Task<string> Return(int movieId, int userId);

        Task<List<Movie>> GetMovieRented(int useriId);
        Task<List<Movie>> GetMoviesInAlphabeticOrder();
    }
    public class RentRepository : IRentRepository
    {
        private static MovieRentalContext context = new MovieRentalContext();
        public async Task<List<Movie>> GetMovieRented(int userId)
        {
            var movies = await context.Rents.Include(q => q.Movie).Where(q => q.UserId == userId).Select(
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

        public async Task<List<Movie>> GetMoviesInAlphabeticOrder()
        {
            var movies = await context.Movies.OrderBy(q => q.Title).ToListAsync();
            return movies;
        }

        public async Task<string> Rent(int movieId, int userId)
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

            // Rentar Pelicula
            var movieRented = new EFMovieRentalDomain.Rent() { MovieId = movieId, UserId = userId, returnDate = DateTime.Now.AddMonths(1).ToString() };
            await context.AddAsync(movieRented);
            // Salvar todos los cambios
            await context.SaveChangesAsync();

            return $"Pelicula {movieId}  rentada correctamente";
        }

        public async  Task<string> Return(int movieId, int userId)
        {
            var movie = await context.Movies.FindAsync(movieId);
            if (movie is null)
            {
                throw new MovieNotFoundException($"Movie: {movieId} - not found");
            }

            var user = await context.Users.FindAsync(userId);
            if (user is null)
            {
                throw new UserNotFoundException($"User: {userId} - not found");
            }

            // Sumar 1 al stock
            movie.Availability = movie.Availability + 1;

            // Devolver Pelicula
            await context.Database.ExecuteSqlRawAsync($"Delete from Rents WHERE MovieId = {movieId} and UserId = {userId}");
            // Salvar todos los cambios
            await context.SaveChangesAsync();

            return $"La Pelicula {movieId} fue retornada";
        }


    }
}
