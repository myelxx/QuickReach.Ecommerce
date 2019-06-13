using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
namespace QuickReach.Ecommerce.Test
{
    public class UserServiceTest
    {
        [Fact]
        public void Register_WithValidUser_CallsRepositorySave()
        {
            //Arrange
            var mockLoginManager = new Mock<ILoginManager>();
            mockLoginManager.Setup( (lm) => lm.Validate(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            var mockUserRepository = new Mock<IUserRepository>();

            var user = new User()
            {
                Username =  "myel@gmail.com",
                Password = "Bl@st123"
            };

            var sut = new UserService(mockLoginManager.Object, mockUserRepository.Object);

            //Act
            sut.RegisterUser(user);

            //Assert
            mockUserRepository.Verify( (r) => r.Save(user), Times.Once);
        }

        [Fact]
        public void RegisterUser_WithInvalidPassword_ThrowInvalidUser()
        {
            //Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var mockLoginManager = new Mock<ILoginManager>();
            var user = new User()
            {
                Username = "myel@gmail.com",
                Password = "Blast123"
            };

            mockLoginManager.Setup( (lm) => lm.Validate(It.IsAny<string>(), It.IsAny<string>())).Throws<InvalidFormatPasswordException>();

            var sut = new UserService(mockLoginManager.Object, mockUserRepository.Object);

            //Act
            Assert.Throws<InvalidFormatPasswordException>( () => sut.RegisterUser(user));

            mockUserRepository.Verify((r) => r.Save(user), Times.Never);
            //Assert

        }

        }
}
