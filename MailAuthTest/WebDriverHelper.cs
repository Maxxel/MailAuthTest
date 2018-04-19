using System;
using System.Diagnostics.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MailAuthTest
{
	public static class WebDriverHelper
	{
		private static IWebDriver driver;
		public static IWebDriver Driver => driver ?? (driver = new FirefoxDriver());

		private static WebDriverWait waiter;
		public static WebDriverWait Waiter => waiter ?? (waiter = WaitTimeout());


		private static WebDriverWait WaitTimeout(int timeOutSec = 10)
		{
			return new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
		}

		public static void NavigateUrl(string url)
		{
			Contract.Ensures(!string.IsNullOrEmpty(url));

			Driver.Navigate().GoToUrl(url);

		}
	}
}
