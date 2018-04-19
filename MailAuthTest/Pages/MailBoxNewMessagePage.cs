using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace MailAuthTest.Pages
{
	public class MailBoxNewMessagePage :BasePage
	{
		public MailBoxNewMessagePage(string name) : base(name)
		{

		}

		[FindsBy(How = How.CssSelector, Using = WebElements.MailBoxNewMessage_ButtonSend)]
		public IWebElement ButtonSend;

		[FindsBy(How = How.CssSelector, Using = WebElements.MailBoxNewMessage_ToAddressInput)]
		public IWebElement ToAddressInput;

		[FindsBy(How = How.CssSelector, Using = WebElements.MailBoxNewMessage_ThemeInput)]
		public IWebElement ThemeInput;

		[FindsBy(How = How.Id, Using = WebElements.MailBoxNewMessage_BodyEmailInput_Id)]
		public IWebElement BodyEmailInput;

		[FindsBy(How = How.ClassName, Using = WebElements.MailBoxNewMessage_SuccessSend)]
		public IWebElement SuccessSend;

		[FindsBy(How = How.CssSelector, Using = WebElements.MailBoxNewMessage_ParentIFrame)]
		public IWebElement ParentIFrame;

		public bool SendMail(string text, string inputTo, string inputTheme = "Test Message")
		{
			ToAddressInput.SendKeys(inputTo);
			ThemeInput.SendKeys(inputTheme);
			
			WebDriverHelper.Driver.SwitchTo().Frame(ParentIFrame.FindElement(By.TagName("iframe")));

			var body = WebDriverHelper.Driver.FindElement(By.Id(WebElements.MailBoxNewMessage_BodyEmailInput_Id));			
			
			var action = new Actions(WebDriverHelper.Driver);			

			action.Click(body).SendKeys(text).Perform();

			var actionKeyPress = new Actions(WebDriverHelper.Driver);

			try {


				actionKeyPress.KeyDown(Keys.Control).SendKeys(Keys.Enter).KeyUp(Keys.Control).Build().Perform();

				WebDriverHelper.Driver.SwitchTo().DefaultContent();
				var successElement =
					WebDriverHelper.Waiter.Until(
						condition: ExpectedConditions.ElementExists(By.CssSelector(WebElements.MailBoxNewMessage_SuccessSend)));
				return successElement.Displayed;
			}
			catch(Exception ex)
			{
				//WebDriverHelper.Driver.SwitchTo().DefaultContent();

				//var alert = WebDriverHelper.Driver.SwitchTo().Alert();
				//alert.SendKeys(Keys.Enter);
				
				return false;
			}			
		}
		
	}
}
