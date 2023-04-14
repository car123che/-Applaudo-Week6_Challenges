using EFMovieRentalDomain.Models;
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
    public class RentControllerTests
    {
        private RentController _rentController;
        private Mock<IRentRepository> _rentRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _rentRepositoryMock = new Mock<IRentRepository>();
            _rentController = new RentController(_rentRepositoryMock.Object);

        }

        [Test]
        public async Task GetMoviesInAlphabeticOrder_WhenCalled_ReturnMovieList()
        {
            _rentRepositoryMock.Setup(ts => ts.GetMoviesInAlphabeticOrder())
                                .ReturnsAsync(new List<EFMovieRentalDomain.Movie>());

            var result = await _rentController.GetMoviesOrderderInAlphabetic();

            Assert.That(result, Is.TypeOf<List<EFMovieRentalDomain.Movie>>());
        }


        [Test]
        public async Task GetMyMoviesRented_WhenCalled_ReturnMovieList()
        {
            int userId = 1;
            _rentRepositoryMock.Setup(ts => ts.GetMovieRented(userId))
                                .ReturnsAsync(new List<EFMovieRentalDomain.Movie>());

            var result = await _rentController.GetMyMoviesRented(userId);

            Assert.That(result, Is.TypeOf<List<EFMovieRentalDomain.Movie>>());
        }


        [Test]
        public async Task Post_WhenCalled_RentAMovie()
        {
            var rentData = new RentData() { moveiId = 1, userId = 1 };

            _rentRepositoryMock.Setup(ts => ts.Rent(rentData.moveiId, rentData.userId))
                                .ReturnsAsync("");

            var result = await _rentController.Post(rentData);

            _rentRepositoryMock.Verify(ts => ts.Rent(rentData.moveiId, rentData.userId));
        }


        [Test]
        public async Task Delete_WhenCalled_DeleteAMovie()
        {
            var rentData = new RentData() { moveiId = 1, userId = 1 };

            _rentRepositoryMock.Setup(ts => ts.Return(rentData.moveiId, rentData.userId))
                                .ReturnsAsync("");

            var result = await _rentController.Delete(rentData);

            _rentRepositoryMock.Verify(ts => ts.Return(rentData.moveiId, rentData.userId));
        }

    }
}
