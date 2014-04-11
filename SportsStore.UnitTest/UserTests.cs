using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTest
{
	//закомментировано, потому что (пока) так и не смогли с помощью Mock'a имитировать Сессию
/*
	/// <summary>
	/// A Class to allow simulation of SessionObject
	/// </summary>
	public class MockHttpSession : HttpSessionStateBase
	{
		Dictionary<string, object> m_SessionStorage = new Dictionary<string, object>();

		public override object this[string name]
		{
			get { return m_SessionStorage[name]; }
			set { m_SessionStorage[name] = value; }
		}
	}
*/
/*
	//In the MVCMockHelpers I modified the FakeHttpContext() method as shown below
	public static HttpContextBase FakeHttpContext()
	{
		var context = new Mock<HttpContextBase>();
		var request = new Mock<HttpRequestBase>();
		var response = new Mock<HttpResponseBase>();
		var session = new MockHttpSession();
		var server = new Mock<HttpServerUtilityBase>();

		context.Setup(ctx => ctx.Request).Returns(request.Object);
		context.Setup(ctx => ctx.Response).Returns(response.Object);
		context.Setup(ctx => ctx.Session).Returns(session);
		context.Setup(ctx => ctx.Server).Returns(server.Object);

		return context.Object;
	}

	//Now in the unit test i can do
	AccountController acct = new AccountController();
	acct.SetFakeControllerContext();
	acct.SetBusinessObject(mockBO.Object);

	RedirectResult results = (RedirectResult)acct.LogOn(userName, password, rememberMe, returnUrl);
	Assert.AreEqual(returnUrl, results.Url);
	Assert.AreEqual(userName, acct.Session["txtUserName"]);
	Assert.IsNotNull(acct.Session["SessionGUID"]);
*/



/*
	[TestClass]
	public class UserTests
	{
		[TestMethod]
		public void CheckMethod_CheckAndResult_LogonSuccess()
		{
			//Arrange
			//create the mock repository
			Mock<IUserRepository> mock = new Mock<IUserRepository>();
			mock.Setup(a => a.Users).Returns(new User[] {
				new User { Login="user1", Password="pass1", FIO="man1"},
				new User { Login="user2", Password="pass2", FIO="man2"},
				new User { Login="user3", Password="pass3", FIO="man3"}
			}.AsQueryable());
			//create Controller
			UserController controller = new UserController(mock.Object);

			//Action
			UserViewModel userVM = (UserViewModel)controller.CheckAndResult("user3", "pass3", "").Model;
			
			//Assert
			Assert.IsTrue(userVM.LogonResult == UserController.LogonSuccess);
		}

		[TestMethod]
		public void CheckMethod_CheckAndResult_PassIncorrect()
		{
			//Arrange
			//create the mock repository
			Mock<IUserRepository> mock = new Mock<IUserRepository>();
			mock.Setup(a => a.Users).Returns(new User[] {
				new User { Login="user1", Password="pass1", FIO="man1"},
				new User { Login="user2", Password="pass2", FIO="man2"},
				new User { Login="user3", Password="pass3", FIO="man3"}
			}.AsQueryable());
			//create Controller
			UserController controller = new UserController(mock.Object);

			//Action
			UserViewModel userVM = (UserViewModel)controller.CheckAndResult("user3", "pass1", "").Model;
			
			//Assert
			Assert.IsTrue(userVM.LogonResult == UserController.PasswordIncorrect);
		}

		[TestMethod]
		public void CheckMethod_CheckAndResult_LoginNotFound()
		{
			//Arrange
			//create the mock repository
			Mock<IUserRepository> mock = new Mock<IUserRepository>();
			mock.Setup(a => a.Users).Returns(new User[] {
				new User { Login="user1", Password="pass1", FIO="man1"},
				new User { Login="user2", Password="pass2", FIO="man2"},
				new User { Login="user3", Password="pass3", FIO="man3"}
			}.AsQueryable());
			//create Controller
			UserController controller = new UserController(mock.Object);

			//Action
			UserViewModel userVM = (UserViewModel)controller.CheckAndResult("user5", "pass1", "").Model;

			//Assert
			Assert.IsTrue(userVM.LogonResult == UserController.LoginAndPassIncorrect);
		}
 
	}
 */
}
