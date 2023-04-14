using EFUnivestityRentalData;
using Microsoft.EntityFrameworkCore;
using MovieRental.Domain.Exceptions;
using MovieRental.Domain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Domain
{
    public interface IMovieRepository
    {
       
        Task<List<EFMovieRentalDomain.Movie>> Get();
        Task<EFMovieRentalDomain.Movie> Get(int Id);
        Task<EFMovieRentalDomain.Movie> Post(EFMovieRentalDomain.Movie movie);
        Task<string> Delete(int Id);
        Task<string> Update(int Id, EFMovieRentalDomain.Movie newMovie);
    }

    public class MovieRepository : IMovieRepository
    {
        private static MovieRentalContext context = new MovieRentalContext();
        private readonly IMovieStorage _movieStorage;

        public MovieRepository(IMovieStorage movieStorage)
        {
            _movieStorage = movieStorage;
        }

        public async Task<string> Delete(int Id)
        {
            var movie = await _movieStorage.Delete(Id);

            return $"Movie: {movie.Title} - deleted";
        }

        public async Task<List<EFMovieRentalDomain.Movie>> Get()
        {
            var movies = await _movieStorage.Get();
            return movies;
        }

        public async Task<EFMovieRentalDomain.Movie> Get(int Id)
        {
            var movie = await _movieStorage.Get(Id);

            if( movie is null)
            {
                throw new MovieNotFoundException($"Movie {Id} - Not Found");
            }

            return movie;
        }

        public async Task<EFMovieRentalDomain.Movie> Post(EFMovieRentalDomain.Movie movie)
        {
            var movieCreated = await _movieStorage.Post(movie);

            return movieCreated;
        }

        public async Task<string> Update(int Id, EFMovieRentalDomain.Movie newMovie)
        {
           var movie = await _movieStorage.Update(Id, newMovie);

            return $"Movie: {movie.Title} -  updated";
        }

    }
}
