using EFMovieRentalDomain;
using EFUnivestityRentalData;
using Microsoft.EntityFrameworkCore;
using MovieRental.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Domain.Storage
{
    public interface IMovieStorage
    {
        Task<Movie> Delete(int Id);
        Task<List<Movie>> Get();
        Task<Movie> Get(int Id);
        Task<Movie> Post(Movie movie);
        Task<Movie> Update(int Id, Movie newMovie);
    }

    public class MovieStorage : IMovieStorage
    {
        private static MovieRentalContext context = new MovieRentalContext();

        public async Task<Movie> Delete(int Id)
        {
            var movie = await context.Movies.FindAsync(Id);

            if (movie is null)
                throw new MovieNotFoundException($"Movie {Id} - Not Found");

            context.Movies.Remove(movie);
            await context.SaveChangesAsync();

            return movie;
        }

        public async Task<List<EFMovieRentalDomain.Movie>> Get()
        {
            var movies = await context.Movies.ToListAsync();
            return movies;
        }

        public async Task<EFMovieRentalDomain.Movie> Get(int Id)
        {
            var movie = await context.Movies.FindAsync(Id);
            return movie;
        }

        public async Task<Movie> Post(EFMovieRentalDomain.Movie movie)
        {
            await context.AddAsync(movie);

            await context.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie> Update(int Id, EFMovieRentalDomain.Movie newMovie)
        {
            var movie = await context.Movies.FindAsync(Id);

            if (movie is null)
                throw new MovieNotFoundException($"Movie {Id} - Not Found");

            movie.Title = newMovie.Title;
            movie.Description = newMovie.Description;
            movie.PosterStock = newMovie.PosterStock;
            movie.TrailerLink = newMovie.TrailerLink;
            movie.SalePrice = newMovie.SalePrice;
            movie.Likes = newMovie.Likes;
            movie.Availability = newMovie.Availability;
            await context.SaveChangesAsync();

            return movie;
        }
    }
}
