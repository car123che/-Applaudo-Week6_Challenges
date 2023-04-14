using Moq;
using MovieRental.Domain;
using MovieRental.Domain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApiTests.MovieRental.Domain
{
    [TestFixture]
    public class SellRepositoryTests
    {

        private SellRepository _sellRepository;
        private Mock<ISellStorage> _sellStorageMock;

        [SetUp]
        public void SetUp()
        {
            _sellStorageMock = new Mock<ISellStorage>();
            _sellRepository = new SellRepository(_sellStorageMock.Object);
        }

        [Test]
        public async Task Sell_WhenCalled_SellAMovie()
        {
            int movieId = 1;
            int userId = 1;
            _sellStorageMock.Setup(ts => ts.Sell(movieId, userId)).ReturnsAsync("");

            var result = await _sellRepository.Sell(movieId, userId);

            _sellStorageMock.Verify(ts => ts.Sell(movieId, userId));
        }

        [Test]
        public async Task GetMovieRented_WhenCalled_ReturnMovieList()
        {
            int userId = 1;
            _sellStorageMock.Setup(ts => ts.GetBoughtMovies(userId)).ReturnsAsync(new List<EFMovieRentalDomain.Movie>());

            var result = await _sellRepository.GetBoughtMovies(userId);

            Assert.That(result, Is.TypeOf<List<EFMovieRentalDomain.Movie>>());
        }

    }
}
