using Microsoft.AspNetCore.Mvc;
using MovieRental.Domain;
using MoviRentalApi.Models;

namespace MoviRentalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieRepository _movieService;

        public MovieController(ILogger<MovieController> logger, IMovieRepository movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<List<EFMovieRentalDomain.Movie>> Get()
        {
            var movies = await _movieService.Get();
            return movies;
        }

        [HttpGet("{Id}")]
        public async Task<EFMovieRentalDomain.Movie> GetMovie(int Id)
        {
            var movie = await _movieService.Get(Id);
            return movie;
        }


        [HttpPost]
        public async Task<EFMovieRentalDomain.Movie> Post([FromBody] MovieData movieData)
        {
            var newMovie = new EFMovieRentalDomain.Movie()
            {
                Title = movieData.Title,
                Description = movieData.Description,
                PosterStock = movieData.PosterStock,
                TrailerLink = movieData.TrailerLink,
                SalePrice = movieData.SalePrice,
                Likes = movieData.Likes,
                Availability = movieData.Availability
            };

            var movie = await _movieService.Post(newMovie);
            return movie;
        }

        [HttpDelete]
        public async Task<string> Delete(int Id)
        {
            var response = await _movieService.Delete(Id);
            return response;
        }

        [HttpPut]
        public async Task<string> Put(int Id, [FromBody] MovieData movieData)
        {
            var newMovie = new EFMovieRentalDomain.Movie()
            {
                Title = movieData.Title,
                Description = movieData.Description,
                PosterStock = movieData.PosterStock,
                TrailerLink = movieData.TrailerLink,
                SalePrice = movieData.SalePrice,
                Likes = movieData.Likes,
                Availability = movieData.Availability
            };

            var response = await _movieService.Update(Id, newMovie);
            return response;
        }

    }
}
