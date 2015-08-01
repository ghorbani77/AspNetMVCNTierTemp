
using System.Linq;
using Moq;
using Mvc.Mailer;
using MVC5.ServiceLayer.Mailers;
using MVC5.ViewModel.Account;
using NUnit.Framework;



namespace MVC5.Tests.Mailers
{
    [TestFixture]
    public class UserMailerTest
    {

        #region Fields
        private Mock<UserMailer> _usermailerMock;
        #endregion

        #region Configurations
        [SetUp]
        public void InitBeforeEachTest()
        {
            _usermailerMock = new Mock<UserMailer> { CallBase = true };
        }

        [TearDown]
        public void RunAfterEachTest()
        {
        }

        [TestFixtureSetUp]
        public void OneTimeSetUp()
        {
        }

        [TestFixtureTearDown]
        public void OneTimeTearDown()
        {
        }
        #endregion

        #region Test_ConfirmEmail_Population


        [Test]
        public void Test_ConfirmEmail_Population()
        {

            //Arrange
            _usermailerMock.Setup(
                mailer => mailer.PopulateBody(It.IsAny<MvcMailMessage>(), "ConfirmAccount", It.IsAny<string>(), null));
            var email = new EmailViewModel
            {
                From = "me",
                Url = "http://wwww.google.com",
                UrlText = "کلیک کنید",
                To = "gholamrezarabbal@gmail.com",
                Message = "سلام"

            };


            //Act
            var mailMessage = _usermailerMock.Object.ConfirmAccount(email);

            //Assert
            _usermailerMock.VerifyAll();
            var confirmAccountEmail = _usermailerMock.Object.ViewData.Model as EmailViewModel;
            if (confirmAccountEmail != null)
                Assert.AreEqual("me", confirmAccountEmail.From);
            Assert.AreEqual("gholamrezarabbal@gmail.com", mailMessage.To.First().ToString());


        }
        #endregion


    }
}
