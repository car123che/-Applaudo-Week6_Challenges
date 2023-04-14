using MovieRental.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApiTests.MovieRental.Domain
{
    [TestFixture]
    public class TagNotFoundExceptionTests
    {

        [Test]
        public void TagNotFound_WhenSendMessage_ThrowTagNotFoundException()
        {
            var message = "Tag: 1 - not found";
            var tagNotFoundException = new TagNotFoundException(message);

            Assert.That(tagNotFoundException, Is.InstanceOf<Exception>());
        }

        [Test]
        public void TagNotFound_WhenThrow_ThrowTagNotFoundException()
        {
            
            var tagNotFoundException = new TagNotFoundException();

            Assert.That(tagNotFoundException, Is.InstanceOf<Exception>());
        }
    }
}
