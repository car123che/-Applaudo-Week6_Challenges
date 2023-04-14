using Microsoft.AspNetCore.Mvc;
using MovieRental.Domain;

namespace MoviRentalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieService;

        public MovieController( IMovieRepository movieService)
        {
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
        public async Task<EFMovieRentalDomain.Movie> Post([FromBody] EFMovieRentalDomain.Movie newMovie)
        {
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
        public async Task<string> Put(int Id, [FromBody] EFMovieRentalDomain.Movie newMovie)
        {
            var response = await _movieService.Update(Id, newMovie);
            return response;
        }

    }
}
