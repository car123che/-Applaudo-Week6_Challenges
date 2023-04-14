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
    public class SellControllerTests
    {
        private SellController _sellController;
        private Mock<ISellRepository> _sellRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _sellRepositoryMock = new Mock<ISellRepository>();
            _sellController = new SellController(_sellRepositoryMock.Object);

        }

        [Test]
        public async Task GetMyMoviesBought_WhenCalled_ReturnMovieList()
        {
            var userId = 1;
            _sellRepositoryMock.Setup(ts => ts.GetBoughtMovies(userId))
                                .ReturnsAsync(new List<EFMovieRentalDomain.Movie>());

            var result = await _sellController.GetMyMoviesRented(userId);

            Assert.That(result, Is.TypeOf<List<EFMovieRentalDomain.Movie>>());
        }



        [Test]
        public async Task Post_WhenCalled_sELLAMovie()
        {
            var sellData = new SellData() { moveiId = 1, userId = 1 };

            _sellRepositoryMock.Setup(ts => ts.Sell(sellData.moveiId, sellData.userId))
                                .ReturnsAsync("");

            var result = await _sellController.Post(sellData);

            _sellRepositoryMock.Verify(ts => ts.Sell(sellData.moveiId, sellData.userId));
        }


    }
}
