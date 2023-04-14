using EFMovieRentalDomain;
using EFUnivestityRentalData;
using Microsoft.EntityFrameworkCore;
using MovieRental.Domain.Exceptions;
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
        private static MovieRentalContext context = new MovieRentalContext();
        public async Task<string> Delete(int Id)
        {
            var user = await context.Users.FindAsync(Id);

            if (user is null)
            {
                throw new UserNotFoundException($"User {Id} - Not Found");
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return $"User: {user.Name} - deleted";
        }

        public async Task<List<User>> Get()
        {
            var users = await context.Users.ToListAsync();
            return users;
        }

        public async Task<User> Get(int Id)
        {
            var user = await context.Users.FindAsync(Id);

            if (user is null)
            {
                throw new MovieNotFoundException($"user {Id} - Not Found");
            }

            return user;
        }

        public async Task<User> Post(User newUser)
        {
            await context.AddAsync(newUser);

            await context.SaveChangesAsync();

            return newUser;
        }

        public async Task<string> Update(int Id, User newUser)
        {
            var user = await context.Users.FindAsync(Id);

            if (user is null)
            {
                throw new MovieNotFoundException($"user {Id} - Not Found");
            }

            user.Name = newUser.Name;
            user.Age = newUser.Age;
            user.Email = newUser.Email;
            user.Phone = newUser.Phone;
            
            await context.SaveChangesAsync();

            return $"User: {user.Name} -  updated";
        }
    }
}
