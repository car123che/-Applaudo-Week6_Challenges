using EFMovieRentalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFUnivestityRentalData;
using Microsoft.EntityFrameworkCore;
using EFMovieRentalDomain.Models;

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
        private static MovieRentalContext context = new MovieRentalContext();

        public async Task<string> Delete(int movieId, int tagId)
        {
            await context.Database.ExecuteSqlRawAsync($"Delete from MovieTags  WHERE MovieId = {movieId} and TagId = {tagId}");
            await context.SaveChangesAsync();

            return "Tag eliminado correctamente";
        }

        public async Task<List<MovieTagsDetail>> GetMovieTagsByMovie(int moveiId)
        {
            var movies = await context.MovieTags.Include(q => q.Movie).Select(
                     q =>
                     new MovieTagsDetail
                     {
                         Title = q.Movie.Title,
                         Description = q.Movie.Description,
                         PosterStock = q.Movie.PosterStock,
                         TrailerLink = q.Movie.TrailerLink,
                         SalePrice = q.Movie.SalePrice,
                         Likes = q.Movie.Likes,
                         Availability = q.Movie.Availability,
                         TagName = q.Tag.Name,
                         MovieId = q.MovieId,
                         TagId = q.TagId
                     }
                 ).Where(q => q.MovieId == moveiId).ToListAsync();

            return movies;
        }

        public async Task<List<MovieTagsDetail>> GetMovieTagsByTag(int tagId)
        {
            var movies = await context.MovieTags.Include(q => q.Movie).Select(
                     q =>
                     new MovieTagsDetail
                     {
                         Title = q.Movie.Title,
                         Description = q.Movie.Description,
                         PosterStock = q.Movie.PosterStock,
                         TrailerLink = q.Movie.TrailerLink,
                         SalePrice = q.Movie.SalePrice,
                         Likes = q.Movie.Likes,
                         Availability = q.Movie.Availability,
                         TagName = q.Tag.Name,
                         MovieId = q.MovieId,
                         TagId = q.TagId
                     }
                 ).Where(q => q.TagId == tagId).ToListAsync();

            return movies;
        }

        public async Task<string> Post(int movieId, int tagId)
        {
            var movieTag = new EFMovieRentalDomain.MovieTag() { MovieId = movieId, TagId = tagId };
            await context.AddAsync(movieTag);

            await context.SaveChangesAsync();

            return "Tag agregado correctamente";
        }


    }


}
