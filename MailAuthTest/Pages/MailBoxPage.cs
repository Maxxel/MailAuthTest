using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace MailAuthTest.Pages
{
	public class MailBoxPage : BasePage
	{
		public MailBoxPage(string name) : base(name)
		{
		}


		[FindsBy(How = How.CssSelector, Using = WebElements.MailBoxPage_ButtonNewMessage)]
		private IWebElement ButtonNewMessage;

		public MailBoxNewMessagePage GoToMailBoxNewMessagePagePage()
		{
			ButtonNewMessage.Click();
			try
			{
				WebDriverHelper.Waiter.Until(
					condition: ExpectedConditions.ElementExists(By.CssSelector(WebElements.MailBoxNewMessage_ButtonSend)));
			}
			catch
			{
				return null;
			}
			return new MailBoxNewMessagePage("MailBoxPage");
		}
	}
}
