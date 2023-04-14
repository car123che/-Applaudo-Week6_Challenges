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
    public class RentRepositoryTests
    {
        private RentRepository _rentRepository;
        private Mock<IRentStorage> _rentStorageMock;

        [SetUp]
        public void SetUp()
        {
            _rentStorageMock = new Mock<IRentStorage>();
            _rentRepository = new RentRepository(_rentStorageMock.Object);
        }

        [Test]
        public async Task Rent_WhenCalled_RentAMovie()
        {
            int movieId = 1;
            int userId = 1;
            _rentStorageMock.Setup(ts => ts.Rent(movieId, userId)).ReturnsAsync("");

            var result = await _rentRepository.Rent(movieId, userId);

            _rentStorageMock.Verify(ts => ts.Rent(movieId, userId));
        }

        [Test]
        public async Task Return_WhenCalled_Return()
        {
            int movieId = 1;
            int userId = 1;
            _rentStorageMock.Setup(ts => ts.Return(movieId, userId)).ReturnsAsync("");

            var result = await _rentRepository.Return(movieId, userId);

            _rentStorageMock.Verify(ts => ts.Return(movieId, userId));
        }

        [Test]
        public async Task GetMovieRented_WhenCalled_ReturnMovieList()
        {
            int userId = 1;
            _rentStorageMock.Setup(ts => ts.GetMovieRented(userId)).ReturnsAsync(new List<EFMovieRentalDomain.Movie>());

            var result = await _rentRepository.GetMovieRented(userId);

            Assert.That(result, Is.TypeOf<List<EFMovieRentalDomain.Movie>>());
        }

        [Test]
        public async Task GetMoviesInAlphabeticOrder_WhenCalled_ReturnMovieList()
        {
            _rentStorageMock.Setup(ts => ts.GetMoviesInAlphabeticOrder()).ReturnsAsync(new List<EFMovieRentalDomain.Movie>());

            var result = await _rentRepository.GetMoviesInAlphabeticOrder();

            Assert.That(result, Is.TypeOf<List<EFMovieRentalDomain.Movie>>());
        }

        public async Task GetMoviesInAlphabeticOrder_WhenCalled_ReturnMovieListOrdered()
        {
            _rentStorageMock.Setup(ts => ts.GetMoviesInAlphabeticOrder()).ReturnsAsync(new List<EFMovieRentalDomain.Movie>()
            {
                new EFMovieRentalDomain.Movie(){Title = "ABC"},
                new EFMovieRentalDomain.Movie(){Title = "DEF"},
                new EFMovieRentalDomain.Movie(){Title = "ZTE"}
            }); ;

            var result = await _rentRepository.GetMoviesInAlphabeticOrder();

            Assert.That(result, Is.Ordered);
        }

    }
}
