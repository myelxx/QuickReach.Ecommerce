using System;
using Xunit;

namespace QuickReach.Ecommerce.Test
{
    public class LoginManagerTest
    {
        [Fact]
        public void Validate_WithValidUsernameAndPassword_ShouldPass()
        {
            //Arrange -- SUT - system undertest
            var sut = new LoginManager();
            var username = "meji@gmail.com";
            var password = "Bl@st123";
            var expected = true;

            //Act --invoke the method
            var actual = sut.Validate(username, password);

            //Assert --check if pass or fail
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Bl@st12", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData("Blast123", false)]
        [InlineData("Bla$txyz", false)]
        [InlineData("bl@st123", false)]
        [InlineData("BL@ST123", false)]
        public void Validate_WithInvalidPassword_ShouldFail(string password, bool expected)
        {
            //Arrange
            var sut = new LoginManager();
            var username = "meji@gmail.com";

            //Act
            var actual = sut.Validate(username, password);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
