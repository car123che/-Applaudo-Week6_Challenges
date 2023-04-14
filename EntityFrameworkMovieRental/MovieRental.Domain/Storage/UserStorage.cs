using EFMovieRentalDomain;
using EFUnivestityRentalData;
using Microsoft.EntityFrameworkCore;
using MovieRental.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Domain.Storage
{
    public interface IUserStorage
    {
        Task<User> Delete(int Id);
        Task<List<User>> Get();
        Task<User> Get(int Id);
        Task<User> Post(User newUser);
        Task<User> Update(int Id, User newUser);
    }

    public class UserStorage : IUserStorage
    {
        private MovieRentalContext context = new MovieRentalContext();

        public async Task<User> Delete(int Id)
        {
            var user = await context.Users.FindAsync(Id);

            if (user is null)
            {
                throw new UserNotFoundException($"User {Id} - Not Found");
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> Get()
        {
            var users = await context.Users.ToListAsync();
            return users;
        }

        public async Task<User> Get(int Id)
        {
            var user = await context.Users.FindAsync(Id);
            return user;
        }

        public async Task<User> Post(User newUser)
        {
            await context.AddAsync(newUser);

            await context.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> Update(int Id, User newUser)
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

            return user;
        }
    }
}
