//using System;
//using System.Web;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using MVC5.ServiceLayer.Contracts;
//using MVC5.ServiceLayer.Mailers;
//using NUnit.Framework;
//using MVC5.Web.Controllers;

//namespace MVC5.Tests.Controllers
//{
//    [TestFixture]
//    public class AccountControllerTest
//    {
//        #region Fields
//        private readonly IMappingEngine _mapperEngine;
//        private readonly HttpRequestBase _httpRequestBase;
//        private readonly IAuthenticationManager _authenticationManager;
//        private readonly IApplicationSignInManager _signInManager;
//        private readonly IApplicationUserManager _userManager;
//        private readonly IUserMailer _userMailer;
//        private Mock<IUserMailer> _mailerMock;
//        private AccountController _accountController;
//        #endregion
      

//        #region Configurations
//        [SetUp]
//        public void InitBeforeEachTest()
//        {
//            _mailerMock=new Mock<IUserMailer>();
//            _accountController=new AccountController();
//        }

//        [TearDown]
//        public void RunAfterEachTest()
//        {
//        }

//        [TestFixtureSetUp]
//        public void OneTimeSetUp()
//        {
//        }

//        [TestFixtureTearDown]
//        public void OneTimeTearDown()
//        {
//        }
//        #endregion

//        [Test]
//        public void Test_Send_ConfirmEmail_When_Register()
//        {
            
//        }

//    }
//}
