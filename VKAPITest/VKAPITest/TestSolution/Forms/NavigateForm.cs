using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKAPITest.TestSolution.Forms
{
    public class NavigateForm : Form
    {
        private readonly IButton myPageButton = ElementFactory.GetButton(By.XPath($"//*[@id='l_pr']//*[contains(@href,'id')]"), "My page button");

        public NavigateForm() : base(By.XPath("//*[contains(@class,'side_bar_nav')]"), "Navigate form") { }

        public void ClickMyPageButton()
        {
            Logger.Instance.Info("Click my page button");
            myPageButton.Click();
        }
    }
}