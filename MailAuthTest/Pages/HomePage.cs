namespace MailAuthTest.Pages
{
	public class HomePage : BasePage
	{
		public HomePage(string name) : base(name)
		{
			
		}
		
		public AuthPage GoToAuthPage()
		{			
			return new AuthPage("AuthPage");
		}
	}
}
