using Moq;
using MovieRental.Domain.Storage;
using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFMovieRentalDomain.Models;

namespace MovieRentalApiTests.MovieRental.Domain
{
    [TestFixture]
    public class MovieTagRepositoryTests
    {
        private MovieTagRepository _movieTagRepository;
        private Mock<IMovieTagStorage> _movieTagStorageMock;

        [SetUp]
        public void SetUp()
        {
            _movieTagStorageMock = new Mock<IMovieTagStorage>();
            _movieTagRepository = new MovieTagRepository(_movieTagStorageMock.Object);
        }

        [Test]
        public async Task Post_WhenCalled_SaveAMovieTag()
        {
            int movieId = 1;
            int tagId = 1;
            _movieTagStorageMock.Setup(ts => ts.Post(movieId, tagId)).ReturnsAsync("");

            var result = await _movieTagRepository.Post(movieId, tagId);

            _movieTagStorageMock.Verify(ts => ts.Post(movieId, tagId));
        }

        [Test]
        public async Task Delete_WhenCalled_DeleteAMovieTag()
        {
            int movieId = 1;
            int tagId = 1;
            _movieTagStorageMock.Setup(ts => ts.Delete(movieId, tagId)).ReturnsAsync("");

            var result = await _movieTagRepository.Delete(movieId, tagId);

            _movieTagStorageMock.Verify(ts => ts.Delete(movieId, tagId));
        }

        [Test]
        public async Task GetMovieTagsByMovie_WhenCalled_ReturnMovieTagList()
        {
            int movieId = 1;
            _movieTagStorageMock.Setup(ts => ts.GetMovieTagsByMovie(movieId)).ReturnsAsync(new List<MovieTagsDetail>());

            var result = await _movieTagRepository.GetMovieTagsByMovie(movieId);

            Assert.That(result, Is.TypeOf<List<MovieTagsDetail>>());
        }

        [Test]
        public async Task GetMovieTagsByTag_WhenCalled_ReturnMovieTagList()
        {
            int movieId = 1;
            _movieTagStorageMock.Setup(ts => ts.GetMovieTagsByTag(movieId)).ReturnsAsync(new List<MovieTagsDetail>());

            var result = await _movieTagRepository.GetMovieTagsByTag(movieId);

            Assert.That(result, Is.TypeOf<List<MovieTagsDetail>>());
        }


    }
}
