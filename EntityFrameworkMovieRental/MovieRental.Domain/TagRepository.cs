using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFUnivestityRentalData;
using Microsoft.EntityFrameworkCore;
using MovieRental.Domain.Exceptions;
using MovieRental.Domain.Storage;

namespace MovieRental.Domain
{ 
    public interface ITagRepository
    {
        Task<EFMovieRentalDomain.Tag> Post(string Name);
        Task<List<EFMovieRentalDomain.Tag>> Get();
        Task<EFMovieRentalDomain.Tag> Get(int Id);
        Task<string> Delete(int Id);
        Task<string> Update(int Id, string newName);
    }

    public class TagRepository : ITagRepository
    {
        private readonly ITagStorage _tagStorage;

        public TagRepository(ITagStorage tagStorage)
        {
            _tagStorage = tagStorage;
        }

        public async Task<List<EFMovieRentalDomain.Tag>> Get()
        {
            var tags = await _tagStorage.GetAllTags();
            return tags;
        }

        public async Task<EFMovieRentalDomain.Tag> Get(int Id)
        {
            var tag = await _tagStorage.GetOneTag(Id);

            if(tag is null)
                throw new TagNotFoundException($"Tag Id: {Id} - not Found");

            return tag;
        }
        
        public async Task<EFMovieRentalDomain.Tag> Post(string Name)
        {
            var tag = await _tagStorage.SaveATag(Name);
            return tag;
        }


        public async Task<string> Delete(int Id)
        {
            var tag = await _tagStorage.DeleteTag(Id);
            return $"Tag: {tag.Name} - eliminada";
        }


        public async Task<string> Update(int Id, string newName)
        {
            var tag = await _tagStorage.UpdateTag(Id, newName);
            return $"Tag: {tag.Name} - modificada correctamente";
        }

    }
}
