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
    public interface ITagStorage
    {
        Task<Tag> DeleteTag(int Id);
        Task<List<Tag>> GetAllTags();
        Task<Tag> GetOneTag(int Id);
        Task<Tag> SaveATag(string Name);
        Task<Tag> UpdateTag(int Id, string newName);
    }

    public class TagStorage : ITagStorage
    {
        private  MovieRentalContext context = new MovieRentalContext();

        public async Task<List<EFMovieRentalDomain.Tag>> GetAllTags()
        {
            var tags = await context.Tags.ToListAsync();
            return tags;
        }

        public async Task<EFMovieRentalDomain.Tag> GetOneTag(int Id)
        {
            var tag = await context.Tags.FindAsync(Id);
            return tag;
        }

        public async Task<EFMovieRentalDomain.Tag> SaveATag(string Name)
        {
            var tag = new EFMovieRentalDomain.Tag() { Name = Name };
            await context.AddAsync(tag);
            await context.SaveChangesAsync();
            return tag;
        }


        public async Task<EFMovieRentalDomain.Tag> DeleteTag(int Id)
        {
            var tag = await context.Tags.FindAsync(Id);

            if (tag is null)
                throw new TagNotFoundException($"Tag Id: {Id} - not Found");

            context.Tags.Remove(tag);
            await context.SaveChangesAsync();

            return tag;
        }


        public async Task<EFMovieRentalDomain.Tag> UpdateTag(int Id, string newName)
        {
            var tag = await context.Tags.FindAsync(Id);

            if (tag is null)
                throw new TagNotFoundException($"Tag Id: {Id} - not Found");

            tag.Name = newName;
            await context.SaveChangesAsync();

            return tag;
        }
    }
}
