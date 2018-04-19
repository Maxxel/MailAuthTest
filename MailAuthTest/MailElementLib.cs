using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace MailAuthTest
{
	public static class MailElementLib
	{
		private static readonly List<Page> Pages = new List<Page>
												{													
													new Page
															{
																Name = @"AuthPage",
																Url = "https://account.mail.ru/login/?mode=simple&v=2.0.13&type=login&allow_external=1&success_redirect=https%3A%2F%2Fe.mail.ru%2Fmessages%2Finbox%3Fback%3D1&opener=mail.login&modal=1&parent_url=https%3A%2F%2Fe.mail.ru%2Flogin%3Flang%3Dru_RU%26Page%3D",
															},
													new Page
															{
																Name = @"MailBoxPage",
																Url = "https://e.mail.ru/messages/inbox?back=1&from=mail.login&back=1",
															}

												};
		
		public static string GetUrl(string name)
		{
			Contract.Ensures(!string.IsNullOrEmpty(name));
			return Pages.First(el => el.Name == name).Url;
		}

	}

	public class Page
	{
		public string Name;
		public string Url;
	}

	public class WebElements
	{
		public const string Home_AuthLink = @"PH_authLink";
		public const string Auth_EmailInput_Name = @"Username";
		public const string Auth_PasswordInput_Name = @"Password";
		public const string Auth_ButtonEnter_Class_Text = @"btn__text";	
		public const string MailBoxPage_ButtonNewMessage = @"span.b-toolbar__btn__text.b-toolbar__btn__text_pad";
		public const string MailBoxNewMessage_ToAddressInput = @"textarea.js-input.compose__labels__input";
		public const string MailBoxNewMessage_ButtonSend = @"div.b-toolbar__item.b-toolbar__item_.b-toolbar__item_false";
		public const string MailBoxNewMessage_ThemeInput = @"input.b-input";
		public const string MailBoxNewMessage_BodyEmailInput_Id = @"tinymce";
		public const string MailBoxNewMessage_SuccessSend = @"div.message-sent__title";
		public const string MailBoxNewMessage_ParentIFrame = @"td.mceIframeContainer.mceFirst.mceLast";
		public const string MailBoxNewMessage_ToolTip = @"div.b-dropdown__group.b-dropdown__group_scroll";
	}
}
