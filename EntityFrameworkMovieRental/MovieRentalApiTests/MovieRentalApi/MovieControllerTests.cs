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
    public class MovieControllerTests
    {
        private MovieController _movieController;
        private Mock<IMovieRepository> _movieRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _movieController = new MovieController(_movieRepositoryMock.Object);

        }


        [Test]
        public async Task Get_WhenCalled_ReturnMovieList()
        {
            _movieRepositoryMock.Setup(tr => tr.Get()).ReturnsAsync(new List<EFMovieRentalDomain.Movie>());

            var result = await _movieController.Get();

            Assert.That(result, Is.TypeOf<List<EFMovieRentalDomain.Movie>>());

        }

        [Test]
        public async Task GetMovieById_WhenCalled_ReturnMovie()
        {
            int movieId = 1;
            _movieRepositoryMock.Setup(ts => ts.Get(movieId)).ReturnsAsync(new EFMovieRentalDomain.Movie());

            var result = await _movieController.GetMovie(movieId);

            Assert.That(result, Is.TypeOf<EFMovieRentalDomain.Movie>());
        }


        [Test]
        public async Task Post_WhenCalled_SaveMovie()
        {
            var movie = new EFMovieRentalDomain.Movie() { Title = "test", Description="test", Likes = 1
                                                        , PosterStock = 1, SalePrice=1, Availability = 1, TrailerLink = "f"};

            _movieRepositoryMock.Setup(ts => ts.Post(movie)).ReturnsAsync(movie);

            var result = await _movieController.Post(movie);

            _movieRepositoryMock.Verify(ts => ts.Post(movie));
        }

        [Test]
        public async Task Post_WhenCalled_ReturnAMovie()
        {
            var movie = new EFMovieRentalDomain.Movie()
            {
                Title = "test",
                Description = "test",
                Likes = 1
                                                        ,
                PosterStock = 1,
                SalePrice = 1,
                Availability = 1,
                TrailerLink = "f"
            };

            _movieRepositoryMock.Setup(ts => ts.Post(movie)).ReturnsAsync(movie);

            var result = await _movieController.Post(movie);

            Assert.That(result, Is.TypeOf<EFMovieRentalDomain.Movie>());
        }

        [Test]
        public async Task Delete_WhenCalled_DeleteAMovie()
        {
            int movieId = 1;
            _movieRepositoryMock.Setup(ts => ts.Delete(movieId)).ReturnsAsync("");

            var result = await _movieController.Delete(movieId);

            _movieRepositoryMock.Verify(ts => ts.Delete(movieId));
        }

        [Test]
        public async Task Update_WhenCalled_UpdateAMovie()
        {
            int movieId = 1;
            var movie = new EFMovieRentalDomain.Movie()
            {
                Title = "test",
                Description = "test",
                Likes = 1,
                PosterStock = 1,
                SalePrice = 1,
                Availability = 1,
                TrailerLink = "f"
            };

            _movieRepositoryMock.Setup(ts => ts.Update(movieId, movie))
                           .ReturnsAsync("");

            var result = await _movieController.Put(movieId, movie);

            _movieRepositoryMock.Verify(ts => ts.Update(movieId, movie));
        }

    }
}
