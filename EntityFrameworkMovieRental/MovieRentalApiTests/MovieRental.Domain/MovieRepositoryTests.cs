using Moq;
using MovieRental.Domain;
using MovieRental.Domain.Exceptions;
using MovieRental.Domain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApiTests.MovieRental.Domain
{
    [TestFixture]
    public class MovieRepositoryTests
    {
        private MovieRepository _movieRepository;
        private Mock<IMovieStorage> _movieStorageMock;

        [SetUp]
        public void SetUp()
        {
            _movieStorageMock = new Mock<IMovieStorage>();
            _movieRepository = new MovieRepository(_movieStorageMock.Object);
        }

        [Test]
        public async Task Get_WhenCalled_ReturnMovieList()
        {
            _movieStorageMock.Setup(ts => ts.Get()).ReturnsAsync(new List<EFMovieRentalDomain.Movie>());

            var result = await _movieRepository.Get();

            Assert.That(result, Is.TypeOf<List<EFMovieRentalDomain.Movie>>());
        }

        [Test]
        public void GetMovieById_WhenIdDoesNotExists_ThrowMovieNotFoundException()
        {
            int movieId = 1;

            Assert.That(async () =>
            {
                var result = await _movieRepository.Get(movieId);
                _movieStorageMock.Setup(ts => ts.Get(movieId)).Throws<MovieNotFoundException>();

            }, Throws.Exception.TypeOf<MovieNotFoundException>());

        }

        [Test]
        public async Task GetMovieById_WhenIdExits_ReturnMovie()
        {
            int movieId = 1;
            _movieStorageMock.Setup(ts => ts.Get(movieId)).ReturnsAsync(new EFMovieRentalDomain.Movie());

            var result = await _movieRepository.Get(movieId);

            Assert.That(result, Is.TypeOf<EFMovieRentalDomain.Movie>());
        }

        [Test]
        public async Task Post_WhenCalled_ReturnMovie()
        {
            var Movie = new EFMovieRentalDomain.Movie();
            _movieStorageMock.Setup(ts => ts.Post(Movie)).ReturnsAsync(new EFMovieRentalDomain.Movie());

            var result = await _movieRepository.Post(Movie);

            Assert.That(result, Is.TypeOf<EFMovieRentalDomain.Movie>());
        }

        [Test]
        public async Task Delete_WhenCalled_DeleteAMovie()
        {
            int movieId = 1;
            _movieStorageMock.Setup(ts => ts.Delete(movieId)).ReturnsAsync(new EFMovieRentalDomain.Movie());

            var result = await _movieRepository.Delete(movieId);

            _movieStorageMock.Verify(ts => ts.Delete(movieId));
        }

        [Test]
        public async Task Update_WhenCalled_UpdateAMovie()
        {
            int movieId = 1;
            var Movie = new EFMovieRentalDomain.Movie();
            _movieStorageMock.Setup(ts => ts.Update(movieId, Movie))
                           .ReturnsAsync(new EFMovieRentalDomain.Movie());

            var result = await _movieRepository.Update(movieId, Movie);

            _movieStorageMock.Verify(ts => ts.Update(movieId, Movie));
        }

    }
}
