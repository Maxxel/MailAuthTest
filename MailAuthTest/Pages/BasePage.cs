using System.Diagnostics.Contracts;
using static OpenQA.Selenium.Support.PageObjects.PageFactory;

namespace MailAuthTest.Pages
{
	public abstract class BasePage
	{
		protected BasePage(string name)
		{
			Contract.Ensures(!string.IsNullOrEmpty(name));
			Name = name;
			WebElements = new WebElements();
			RefreshInitElements();
		}

		protected void RefreshInitElements()
		{
			InitElements(WebDriverHelper.Driver, this);
		}

		protected string Name { get; set; }		

		public void GoToPage()
		{
			WebDriverHelper.NavigateUrl(MailElementLib.GetUrl(Name));
		}

		protected WebElements WebElements { get; set; }
	}
}
