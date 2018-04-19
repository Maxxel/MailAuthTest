using System.Diagnostics.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace MailAuthTest.Pages
{
	public class AuthPage : BasePage
	{
		public AuthPage(string name) : base(name)
		{
			
		}

		[FindsBy(How = How.Name, Using = WebElements.Auth_EmailInput_Name)]
		private IWebElement EmailInput;

		[FindsBy(How = How.Name, Using = WebElements.Auth_PasswordInput_Name)]
		private IWebElement PasswordInput;

		[FindsBy(How = How.ClassName, Using = WebElements.Auth_ButtonEnter_Class_Text)]
		private IWebElement ButtonEnter;

		public MailBoxPage GoToMailBoxPage( string login, string password)
		{
			Contract.Ensures(!string.IsNullOrEmpty(login));
			Contract.Ensures(!string.IsNullOrEmpty(password));
			WebDriverHelper.Waiter.Until(condition: ExpectedConditions.
				ElementExists(By.Name(WebElements.Auth_PasswordInput_Name)));
			
			EmailInput.SendKeys(login);			
			PasswordInput.SendKeys(password);
			ButtonEnter.Click();


			try
			{
				WebDriverHelper.Waiter.Until(
					condition: ExpectedConditions.ElementExists(By.CssSelector(WebElements.MailBoxPage_ButtonNewMessage)));
			}
			catch
			{
				return null;
			}
			return new MailBoxPage("MailBoxPage");
		}
	}
}
