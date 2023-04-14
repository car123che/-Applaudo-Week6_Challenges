using EFMovieRentalDomain;
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

    public interface ISellRepository
    {
        Task<string> Sell(int movieId, int userId);
        Task<List<Movie>> GetBoughtMovies(int userId);
    }

    public class SellRepository : ISellRepository
    {
        private readonly ISellStorage _sellStorage;

        public SellRepository(ISellStorage sellStorage)
        {
            _sellStorage = sellStorage;
        }

        public async Task<List<Movie>> GetBoughtMovies(int userId)
        {
            var movies = await _sellStorage.GetBoughtMovies(userId);

            return movies; 
        }

        public async Task<string> Sell(int movieId, int userId)
        {
            var result = await _sellStorage.Sell(movieId, userId);

            return result;
        }
    }
}
