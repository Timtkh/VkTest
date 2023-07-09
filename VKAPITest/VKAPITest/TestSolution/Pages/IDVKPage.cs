using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKAPITest.TestSolution.Pages
{
    public class IDVKPage : Form
    {
        private readonly ITextBox passwordInput = ElementFactory.GetTextBox(By.XPath("//*[@name='password']"), "Password input");

        public IDVKPage() : base(By.XPath("//*[contains(@class,'vkc__Auth__pageBox')]"), "Id VK page") { }

        public void EnterPassword(string password)
        {
            Logger.Instance.Info("Enter password");
            passwordInput.ClearAndType(password);
        }
    }
}