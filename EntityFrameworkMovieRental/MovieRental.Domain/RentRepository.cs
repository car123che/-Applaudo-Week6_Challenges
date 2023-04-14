using EFMovieRentalDomain;
using EFMovieRentalDomain.Models;
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
    public interface IRentRepository
    {
        Task<string> Rent(int movieId, int userId);
        Task<string> Return(int movieId, int userId);

        Task<List<Movie>> GetMovieRented(int useriId);
        Task<List<Movie>> GetMoviesInAlphabeticOrder();
    }
    public class RentRepository : IRentRepository
    {
        private readonly IRentStorage _rentStorage;

        public RentRepository(IRentStorage rentStorage)
        {
            _rentStorage = rentStorage;
        }

        public async Task<List<Movie>> GetMovieRented(int userId)
        {
            var movies = await _rentStorage.GetMovieRented(userId);

            return movies;
        }

        public async Task<List<Movie>> GetMoviesInAlphabeticOrder()
        {
            var movies = await _rentStorage.GetMoviesInAlphabeticOrder();
            return movies;
        }

        public async Task<string> Rent(int movieId, int userId)
        {
            var result = await _rentStorage.Rent(movieId, userId);
            return result;
        }

        public async  Task<string> Return(int movieId, int userId)
        {
            var result = await _rentStorage.Return(movieId, userId);
            return result;
        }


    }
}
