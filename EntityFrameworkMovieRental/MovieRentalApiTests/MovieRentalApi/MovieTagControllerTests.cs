using EFMovieRentalDomain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieRental.Domain;
using MoviRentalApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApiTests.MovieRentalApi
{
    [TestFixture]
    public class MovieTagControllerTests
    {
        private MovieTagController _movieTagController;
        private Mock<IMovieTagRepository> _movieTagRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _movieTagRepositoryMock = new Mock<IMovieTagRepository>();
            _movieTagController = new MovieTagController(_movieTagRepositoryMock.Object);

        }


        [Test]
        public async Task GetByTag_WhenCalled_ReturnMovieTagsDetailList()
        {
            var tagId = 1;
            _movieTagRepositoryMock.Setup(tr => tr.GetMovieTagsByTag(tagId)).ReturnsAsync(new List<MovieTagsDetail>());

            var result = await _movieTagController.GetByTag(tagId);

            Assert.That(result, Is.TypeOf<List<MovieTagsDetail>>());

        }


        [Test]
        public async Task GetByMovie_WhenCalled_ReturnMovieTagsDetailList()
        {
            var movieId = 1;
            _movieTagRepositoryMock.Setup(tr => tr.GetMovieTagsByMovie(movieId)).ReturnsAsync(new List<MovieTagsDetail>());

            var result = await _movieTagController.GetByMovie(movieId);

            Assert.That(result, Is.TypeOf<List<MovieTagsDetail>>());

        }

        [Test]
        public async Task Post_WhenCalled_SaveAMovieTag()
        {
            var movieTag = new EFMovieRentalDomain.MovieTag() { MovieId = 1, TagId = 1 };
            _movieTagRepositoryMock.Setup(tr => tr.Post(movieTag.MovieId, movieTag.TagId)).ReturnsAsync("");

            var result = await _movieTagController.Post(movieTag);
            _movieTagRepositoryMock.Verify(tr => tr.Post(movieTag.MovieId, movieTag.TagId));
        }

        [Test]
        public async Task Delete()
        {
            var movieTag = new EFMovieRentalDomain.MovieTag() { MovieId = 1, TagId = 1 };
            _movieTagRepositoryMock.Setup(tr => tr.Delete(movieTag.MovieId, movieTag.TagId)).ReturnsAsync("");

            var result = await _movieTagController.Delete(movieTag);
            _movieTagRepositoryMock.Verify(tr => tr.Delete(movieTag.MovieId, movieTag.TagId));
        }
        


    }
}
