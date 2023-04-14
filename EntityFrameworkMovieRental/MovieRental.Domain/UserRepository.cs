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
    public interface IUserRepository
    {
        Task<EFMovieRentalDomain.User> Post(EFMovieRentalDomain.User newUser);
        Task<List<EFMovieRentalDomain.User>> Get();
        Task<EFMovieRentalDomain.User> Get(int Id);
        Task<string> Delete(int Id);
        Task<string> Update(int Id, EFMovieRentalDomain.User newUser);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IUserStorage _userStorage;

        public UserRepository(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }
        public async Task<string> Delete(int Id)
        {
            var user = await _userStorage.Delete(Id);
            return $"User: {user.Name} - deleted";
        }

        public async Task<List<User>> Get()
        {
            var users = await _userStorage.Get();
            return users;
        }

        public async Task<User> Get(int Id)
        {
            var user = await _userStorage.Get(Id);

            if (user is null)
                throw new UserNotFoundException($"user {Id} - Not Found");

            return user;
        }

        public async Task<User> Post(User newUser)
        {
            var user = await _userStorage.Post(newUser);
            return user;
        }

        public async Task<string> Update(int Id, User newUser)
        {
            var user = await _userStorage.Update(Id, newUser);
            return $"User: {user.Name} -  updated";
        }
    }
}
