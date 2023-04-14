using EFMovieRentalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFUnivestityRentalData;
using Microsoft.EntityFrameworkCore;
using EFMovieRentalDomain.Models;
using MovieRental.Domain.Storage;

namespace MovieRental.Domain
{
     
    public interface IMovieTagRepository
    {
        Task<string> Post(int movieId, int tagId);
        Task<string> Delete(int movieId, int tagId);

        Task<List<MovieTagsDetail>> GetMovieTagsByMovie(int moveiId);
        Task<List<MovieTagsDetail>> GetMovieTagsByTag(int tagId);
    }


    public class MovieTagRepository : IMovieTagRepository
    {
        private readonly IMovieTagStorage _movieTagStorage;

        public MovieTagRepository( IMovieTagStorage movieTagStorage)
        {
            _movieTagStorage = movieTagStorage;
        }

        public async Task<string> Delete(int movieId, int tagId)
        {
            var result = await _movieTagStorage.Delete(movieId, tagId);

            return result;
        }

        public async Task<List<MovieTagsDetail>> GetMovieTagsByMovie(int moveiId)
        {
            var movies = await _movieTagStorage.GetMovieTagsByMovie(moveiId);
            return movies;
        }

        public async Task<List<MovieTagsDetail>> GetMovieTagsByTag(int tagId)
        {
            var movies = await _movieTagStorage.GetMovieTagsByTag(tagId);

            return movies;
        }

        public async Task<string> Post(int movieId, int tagId)
        {
            var result = await _movieTagStorage.Post(movieId, tagId);

            return result;
        }


    }


}
