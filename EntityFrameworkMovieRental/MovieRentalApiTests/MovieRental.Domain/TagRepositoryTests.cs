using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EFMovieRentalDomain;
using Moq;
using MovieRental.Domain;
using MovieRental.Domain.Exceptions;
using MovieRental.Domain.Storage;

namespace MovieRentalApiTests.MovieRental.Domain
{
    [TestFixture]
    public class TagRepositoryTests
    {
        private TagRepository _tagRepository;
        private Mock<ITagStorage> _mockTagStorage;


        [SetUp]
        public void Setup()
        {
            _mockTagStorage = new Mock<ITagStorage>();
            _tagRepository = new TagRepository( _mockTagStorage.Object );
        }

        [Test]
        public async Task Get_WhenCalled_ReturnTagList()
        {
            _mockTagStorage.Setup(ts => ts.GetAllTags()).ReturnsAsync(new List<EFMovieRentalDomain.Tag>() );

            var result = await _tagRepository.Get();

            Assert.That(result, Is.TypeOf<List<EFMovieRentalDomain.Tag>>());
        }

        [Test]
        public void GetTagById_WhenIdDoesNotExists_ThrowTagNotFoundException()
        {
            int tagId = 1;

            Assert.That( async () =>
            {
                var result = await _tagRepository.Get(tagId);
                _mockTagStorage.Setup(ts => ts.GetOneTag(tagId)).Throws<TagNotFoundException>();

            }, Throws.Exception.TypeOf<TagNotFoundException>());

        }

        [Test]
        public async Task GetTagById_WhenIdExits_ReturnTag()
        {
            int tagId = 1;
            _mockTagStorage.Setup(ts => ts.GetOneTag(tagId)).ReturnsAsync(new EFMovieRentalDomain.Tag());

            var result = await _tagRepository.Get(tagId);

            Assert.That(result, Is.TypeOf<EFMovieRentalDomain.Tag>());
        }

        [Test]
        public async Task Post_WhenCalled_ReturnTag()
        {
            string Name = "Accion";
            _mockTagStorage.Setup(ts => ts.SaveATag(Name)).ReturnsAsync(new EFMovieRentalDomain.Tag());

            var result = await _tagRepository.Post(Name);

            Assert.That(result, Is.TypeOf<EFMovieRentalDomain.Tag>());
        }

        [Test]
        public async Task Delete_WhenCalled_DeleteATag()
        {
            int tagId = 1;
            _mockTagStorage.Setup(ts => ts.DeleteTag(tagId)).ReturnsAsync(new EFMovieRentalDomain.Tag());

            var result = await _tagRepository.Delete(tagId);

            _mockTagStorage.Verify(ts => ts.DeleteTag(tagId));
        }

        [Test]
        public async Task Update_WhenCalled_UpdateATag()
        {
            int tagId = 1;
            string Name = "Accion";
            _mockTagStorage.Setup(ts => ts.UpdateTag(tagId, Name))
                           .ReturnsAsync(new EFMovieRentalDomain.Tag());

            var result = await _tagRepository.Update(tagId, Name);

            _mockTagStorage.Verify(ts => ts.UpdateTag(tagId, Name));
        }
    }
}
