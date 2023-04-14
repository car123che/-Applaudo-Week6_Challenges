using EFMovieRentalDomain;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Domain;
using MoviRentalApi.Models;

namespace MoviRentalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellController : ControllerBase
    {
        private readonly ISellRepository _sellService;

        public SellController( ISellRepository sellService)
        {
            _sellService = sellService;
        }

        [HttpGet("MyMovies")]
        public async Task<List<Movie>> GetMyMoviesRented(int userId)
        {
            var movies = await _sellService.GetBoughtMovies(userId);
            return movies;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] SellData sellData)
        {
            var response = await _sellService.Sell(sellData.moveiId, sellData.userId);
            return response;
        }

    }
}
