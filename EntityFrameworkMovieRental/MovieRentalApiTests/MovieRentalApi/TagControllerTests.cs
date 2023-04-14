using Microsoft.Extensions.Logging;
using Moq;
using MovieRental.Domain;
using MoviRentalApi.Controllers;
using MoviRentalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApiTests.MovieRentalApi
{
    [TestFixture]
    public class TagControllerTests
    {
        private TagController _tagController;
        private Mock<ITagRepository> _tagRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _tagRepositoryMock = new Mock<ITagRepository>();
            _tagController = new TagController( _tagRepositoryMock.Object);

        }


        [Test]
        public async Task Get_WhenCalled_ReturnTagList()
        {
            _tagRepositoryMock.Setup(tr => tr.Get()).ReturnsAsync(new List<EFMovieRentalDomain.Tag>());

            var result = await _tagController.Get();

            Assert.That(result, Is.TypeOf<List<EFMovieRentalDomain.Tag>>());

        }

        [Test]
        public async Task GetTagById_WhenCalled_ReturnTag()
        {
            int tagId = 1;
            _tagRepositoryMock.Setup(ts => ts.Get(tagId)).ReturnsAsync(new EFMovieRentalDomain.Tag());

            var result = await _tagController.Get(tagId);

            Assert.That(result, Is.TypeOf<EFMovieRentalDomain.Tag>());
        }

        [Test]
        public async Task Post_WhenCalled_ReturnTag()
        {
            string Name = "Accion";
            _tagRepositoryMock.Setup(ts => ts.Post(Name)).ReturnsAsync(new EFMovieRentalDomain.Tag());

            var result = await _tagController.Post(new MoviRentalApi.Models.TagData() { Name = Name});

            Assert.That(result, Is.TypeOf<EFMovieRentalDomain.Tag>());
        }

        [Test]
        public async Task Delete_WhenCalled_DeleteATag()
        {
            int tagId = 1;
            _tagRepositoryMock.Setup(ts => ts.Delete(tagId)).ReturnsAsync("");

            var result = await _tagController.Delete(tagId);

            _tagRepositoryMock.Verify(ts => ts.Delete(tagId));
        }


        [Test]
        public async Task Update_WhenCalled_UpdateATag()
        {
            int tagId = 1;
            var Name = "Carlos";
            var TagData = new TagData() { Name = Name };

            _tagRepositoryMock.Setup(ts => ts.Update(tagId, Name))
                           .ReturnsAsync("");

            var result = await _tagController.Put(tagId, TagData);

            _tagRepositoryMock.Verify(ts => ts.Update(tagId, Name));
        }

    }
}
