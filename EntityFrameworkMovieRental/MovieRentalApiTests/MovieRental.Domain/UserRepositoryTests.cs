using Moq;
using MovieRental.Domain.Storage;
using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRental.Domain.Exceptions;

namespace MovieRentalApiTests.MovieRental.Domain
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private UserRepository _userRepository;
        private Mock<IUserStorage> _userStorageMock;

        [SetUp]
        public void SetUp()
        {
            _userStorageMock = new Mock<IUserStorage>();
            _userRepository = new UserRepository(_userStorageMock.Object);
        }

        [Test]
        public async Task Get_WhenCalled_ReturnUserList()
        {
            _userStorageMock.Setup(ts => ts.Get()).ReturnsAsync(new List<EFMovieRentalDomain.User>());

            var result = await _userRepository.Get();

            Assert.That(result, Is.TypeOf<List<EFMovieRentalDomain.User>>());
        }

        [Test]
        public void GetUserById_WhenIdDoesNotExists_ThrowUserNotFoundException()
        {
            int userId = 1;

            Assert.That(async () =>
            {
                var result = await _userRepository.Get(userId);
                _userStorageMock.Setup(ts => ts.Get(userId)).Throws<UserNotFoundException>();

            }, Throws.Exception.TypeOf<UserNotFoundException>());

        }

        [Test]
        public async Task GetMovieById_WhenIdExits_ReturnUser()
        {
            int userId = 1;
            _userStorageMock.Setup(ts => ts.Get(userId)).ReturnsAsync(new EFMovieRentalDomain.User());

            var result = await _userRepository.Get(userId);

            Assert.That(result, Is.TypeOf<EFMovieRentalDomain.User>());
        }

        [Test]
        public async Task Post_WhenCalled_ReturnUser()
        {
            var user = new EFMovieRentalDomain.User();
            _userStorageMock.Setup(ts => ts.Post(user)).ReturnsAsync(new EFMovieRentalDomain.User());

            var result = await _userRepository.Post(user);

            Assert.That(result, Is.TypeOf<EFMovieRentalDomain.User>());
        }

        [Test]
        public async Task Delete_WhenCalled_DeleteUser()
        {
            int userId = 1;
            _userStorageMock.Setup(ts => ts.Delete(userId)).ReturnsAsync(new EFMovieRentalDomain.User());

            var result = await _userRepository.Delete(userId);

            _userStorageMock.Verify(ts => ts.Delete(userId));
        }

        [Test]
        public async Task Update_WhenCalled_UpdateAUser()
        {
            int userId = 1;
            var user = new EFMovieRentalDomain.User();
            _userStorageMock.Setup(ts => ts.Update(userId, user))
                           .ReturnsAsync(new EFMovieRentalDomain.User());

            var result = await _userRepository.Update(userId, user);

            _userStorageMock.Verify(ts => ts.Update(userId, user));
        }



    }
}
