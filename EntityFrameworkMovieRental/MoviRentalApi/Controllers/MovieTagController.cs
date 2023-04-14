using EFMovieRentalDomain.Models;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Domain;

namespace MoviRentalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTagController : ControllerBase
    {
        private readonly IMovieTagRepository _movieTagService;

        public MovieTagController( IMovieTagRepository movieTagService)
        {
            _movieTagService = movieTagService;
        }

        [HttpGet("ByTag/{Id}")]
        public async Task<List<MovieTagsDetail>> GetByTag(int Id)
        {
            var movies = await _movieTagService.GetMovieTagsByTag(Id);
            return movies;
        }

        [HttpGet("ByMovie/{Id}")]
        public async Task<List<MovieTagsDetail>> GetByMovie(int Id)
        {
            var movies = await _movieTagService.GetMovieTagsByMovie(Id);
            return movies;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] EFMovieRentalDomain.MovieTag movieTagData)
        {
            var response = await _movieTagService.Post(movieTagData.MovieId, movieTagData.TagId);
            return response;
        }

        [HttpDelete]
        public async Task<string> Delete([FromBody] EFMovieRentalDomain.MovieTag movieTagData)
        {
            var response = await _movieTagService.Delete(movieTagData.MovieId, movieTagData.TagId);
            return response;
        }
    }

}
