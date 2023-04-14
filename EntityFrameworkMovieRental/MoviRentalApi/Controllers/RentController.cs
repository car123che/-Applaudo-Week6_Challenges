using EFMovieRentalDomain;
using EFMovieRentalDomain.Models;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Domain;
using MoviRentalApi.Models;

namespace MoviRentalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentController : ControllerBase
    {
        private readonly ILogger<RentController> _logger;
        private readonly IRentRepository _rentService;

        public RentController(ILogger<RentController> logger, IRentRepository rentService)
        {
            _logger = logger;
            _rentService = rentService;
        }

        [HttpGet("OrderedMovies")]
        public async Task<List<Movie>> GetMoviesOrderderInAlphabetic()
        {
            var movies = await _rentService.GetMoviesInAlphabeticOrder();
            return movies;
        }

        [HttpGet("MyMovies")]
        public async Task<List<Movie>> GetMyMoviesRented(int userId)
        {
            var movies = await _rentService.GetMovieRented(userId);
            return movies;
        }


        [HttpPost]
        public async Task<string> Post([FromBody] RentData rentData)
        {
            var response = await _rentService.Rent(rentData.moveiId, rentData.userId);
            return response;
        }

        [HttpDelete]
        public async Task<string> Delete([FromBody] RentData rentData)
        {
            var response = await _rentService.Return(rentData.moveiId, rentData.userId);
            return response;
        }


    }
}
