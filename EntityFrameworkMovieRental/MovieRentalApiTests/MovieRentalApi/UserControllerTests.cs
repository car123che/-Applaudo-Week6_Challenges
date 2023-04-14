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
    public class UserControllerTests
    {
        private UserController _userController;
        private Mock<IUserRepository> _userRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userController = new UserController(_userRepositoryMock.Object);

        }


        [Test]
        public async Task Get_WhenCalled_ReturnUserList()
        {
            _userRepositoryMock.Setup(tr => tr.Get()).ReturnsAsync(new List<EFMovieRentalDomain.User>());

            var result = await _userController.Get();

            Assert.That(result, Is.TypeOf<List<EFMovieRentalDomain.User>>());

        }

        [Test]
        public async Task GetUserById_WhenCalled_ReturnUser()
        {
            int userId = 1;
            _userRepositoryMock.Setup(ts => ts.Get(userId)).ReturnsAsync(new EFMovieRentalDomain.User());

            var result = await _userController.GetUser(userId);

            Assert.That(result, Is.TypeOf<EFMovieRentalDomain.User>());
        }


        [Test]
        public async Task Post_WhenCalled_SaveUser()
        {
            var user = new EFMovieRentalDomain.User()
            {
                Name = "test",
                Age = 22,
                Email = "siu@gmail.com",
                Phone = "20007085"
            };

            _userRepositoryMock.Setup(ts => ts.Post(user)).ReturnsAsync(user);

            var result = await _userController.Post(user);

            _userRepositoryMock.Verify(ts => ts.Post(user));
        }


        [Test]
        public async Task Post_WhenCalled_ReturnUser()
        {
            var user = new EFMovieRentalDomain.User()
            {
                Name = "test",
                Age = 22,
                Email = "siu@gmail.com",
                Phone = "20007085"
            };

            _userRepositoryMock.Setup(ts => ts.Post(user)).ReturnsAsync(user);

            var result = await _userController.Post(user);

            Assert.That(result, Is.TypeOf<EFMovieRentalDomain.User>());
        }

        [Test]
        public async Task Delete_WhenCalled_DeleteAUser()
        {
            int userId = 1;
            _userRepositoryMock.Setup(ts => ts.Delete(userId)).ReturnsAsync("");

            var result = await _userController.Delete(userId);

            _userRepositoryMock.Verify(ts => ts.Delete(userId));
        }

        [Test]
        public async Task Update_WhenCalled_UpdateAUser()
        {
            int userId = 1;
            var user = new EFMovieRentalDomain.User()
            {
                Name = "test",
                Age = 22,
                Email = "siu@gmail.com",
                Phone = "20007085"
            };

            _userRepositoryMock.Setup(ts => ts.Update(userId, user))
                           .ReturnsAsync("");

            var result = await _userController.Put(userId, user);

            _userRepositoryMock.Verify(ts => ts.Update(userId, user));
        }

    }
}
