using MovieRental.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApiTests.MovieRental.Domain
{
    [TestFixture]
    public class UserNotFoundExceptionTests
    {
        [Test]
        public void UserNotFound_WhenSendMessage_ThrowUserNotFoundException()
        {
            var message = "User: 1 - not found";
            var userNotFoundException = new UserNotFoundException(message);

            Assert.That(userNotFoundException, Is.InstanceOf<Exception>());
        }

        [Test]
        public void UserNotFound_WhenThrow_ThrowUserNotFoundException()
        {

            var userNotFoundException = new UserNotFoundException();

            Assert.That(userNotFoundException, Is.InstanceOf<Exception>());
        }
    }
}
