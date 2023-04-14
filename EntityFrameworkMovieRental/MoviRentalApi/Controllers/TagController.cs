using Microsoft.AspNetCore.Mvc;
using MoviRentalApi.Models;
using System.Xml.Linq;
using MovieRental.Domain;

namespace MoviRentalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ILogger<TagController> _logger;
        private readonly ITagRepository  _tagService;
        public TagController(ILogger<TagController> logger, ITagRepository tagService)
        {
            _logger = logger;
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<List<EFMovieRentalDomain.Tag>> Get()
        {
            var tags = await _tagService.Get();
            return tags;
        }

        [HttpGet("{Id}")]
        public async Task<EFMovieRentalDomain.Tag> Get(int Id)
        {
            var tag = await _tagService.Get(Id);
            return tag;
        }

        [HttpPost]
        public async Task<EFMovieRentalDomain.Tag> Post([FromBody] TagData tagData)
        {
            var tag = await _tagService.Post(tagData.Name);
            return tag;
        }

        [HttpDelete]
        public async Task<string> Delete(int Id)
        {
            var response = await _tagService.Delete(Id);
            return response;
        }

        [HttpPut]
        public async Task<string> Put(int Id, [FromBody] TagData tagData)
        {
            var response = await _tagService.Update(Id, tagData.Name);
            return response;
        }

    }
}
