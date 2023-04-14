using Microsoft.AspNetCore.Mvc;
using MovieRental.Domain;
using MoviRentalApi.Models;

namespace MoviRentalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userService;

        public UserController( IUserRepository userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<EFMovieRentalDomain.User>> Get()
        {
            var users = await _userService.Get();
            return users;
        }

        [HttpGet("{Id}")]
        public async Task<EFMovieRentalDomain.User> GetUser(int Id)
        {
            var user = await _userService.Get(Id);
            return user;
        }

        [HttpPost]
        public async Task<EFMovieRentalDomain.User> Post([FromBody] EFMovieRentalDomain.User newUser)
        {
            var user = await _userService.Post(newUser);
            return user;
        }

        [HttpDelete]
        public async Task<string> Delete(int Id)
        {
            var response = await _userService.Delete(Id);
            return response;
        }


        [HttpPut]
        public async Task<string> Put(int Id, [FromBody] EFMovieRentalDomain.User newUser)
        {
            var response = await _userService.Update(Id, newUser);
            return response;
        }

    }
}
