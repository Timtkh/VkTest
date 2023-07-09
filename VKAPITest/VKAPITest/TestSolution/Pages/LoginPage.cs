using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKAPITest.TestSolution.Pages
{
    public class LoginPage : Form
    {
        private readonly ITextBox loginInput = ElementFactory.GetTextBox(By.Id("index_email"), "Login input");
        private readonly IButton enterButton = ElementFactory.GetButton(By.XPath("//*[contains(@type,'submit')]"), "Enter button");

        public LoginPage() : base(By.Id("index_login"), "Login page") { }

        public void EnterLogin(string login)
        {
            Logger.Instance.Info("Enter login");
            loginInput.ClearAndType(login);
        }

        public void ClickEnter()
        {
            Logger.Instance.Info("Click enter");
            enterButton.Click();
        }
    }
}