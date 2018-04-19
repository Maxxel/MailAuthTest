using MailAuthTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailAuthTest
{
	[TestClass]
	public class BaseTests
	{		

		[TestMethod]
		public void TestMethod_ValidSend()
		{
			var testMailTo = @"bogaturev.maxim@gmail.com";
			var authPage = new AuthPage(@"AuthPage");
			authPage.GoToPage();
			var mailBoxPage = authPage.GoToMailBoxPage(@"test.selenium_proj", @"Test190288");
			Assert.IsNotNull(   mailBoxPage, 
								string.Format( ErrorHelper.ErrorNavigatePage, 
								               "\"mail box\" page"));

			var mailBoxNewMessagePage = mailBoxPage.GoToMailBoxNewMessagePagePage();
			Assert.IsNotNull(   mailBoxNewMessagePage, 
								string.Format( ErrorHelper.ErrorNavigatePage, 
											   "\"create new message\" page"));

			Assert.IsTrue(mailBoxNewMessagePage.SendMail( @"My test message!!!",
														  testMailTo),
														  ErrorHelper.ValidSend_Error);

		}

		[TestMethod]
		public void TestMethod_InvalidSend()
		{
			const string testMailTo = @"11111111";  //invalid address will generate an error			

			var authPage = new AuthPage(@"AuthPage");
			authPage.GoToPage();
			var mailBoxPage = authPage.GoToMailBoxPage(@"test.selenium_proj", @"Test190288");
			Assert.IsNotNull(mailBoxPage,
				string.Format(  ErrorHelper.ErrorNavigatePage,
								"\"mail box\" page"));

			var mailBoxNewMessagePage = mailBoxPage.GoToMailBoxNewMessagePagePage();
			Assert.IsNotNull(   mailBoxNewMessagePage,
								string.Format(  ErrorHelper.ErrorNavigatePage,
												"\"create new message\" page"));

			Assert.IsFalse(mailBoxNewMessagePage.SendMail(   @"My test message!!!",
															testMailTo),
															ErrorHelper.ValidSend_Error);

		}

		[TestMethod]
		public void TestMethod_InvalidAuthorization()
		{			
			var authPage = new AuthPage(@"AuthPage");
			authPage.GoToPage();
			var mailBoxPage = authPage.GoToMailBoxPage(@"test.selenium_proj", @"invalidPassword"); // invalid password will generate an error
			Assert.IsNull(  mailBoxPage,
							string.Format(  ErrorHelper.ErrorNavigatePage,
											"\"mail box\" page"));
		}


		
	}
}
