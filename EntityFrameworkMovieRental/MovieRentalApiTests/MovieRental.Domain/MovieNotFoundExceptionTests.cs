using MovieRental.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApiTests.MovieRental.Domain
{
    [TestFixture]
    public class MovieNotFoundExceptionTests
    {

        [Test]
        public void MovieNotFound_WhenSendMessage_ThrowMovieNotFoundException()
        {
            var message = "Movie: 1 - not found";
            var movieNotFoundException = new MovieNotFoundException(message);

            Assert.That(movieNotFoundException, Is.InstanceOf<Exception>());
        }

        [Test]
        public void MovieNotFound_WhenThrow_ThrowMovieNotFoundException()
        {

            var movieNotFoundException = new MovieNotFoundException();

            Assert.That(movieNotFoundException, Is.InstanceOf<Exception>());
        }
    }
}
