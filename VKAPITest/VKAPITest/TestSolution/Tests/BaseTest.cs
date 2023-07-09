using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using NUnit.Framework;
using VKAPITest.TestSolution.Managers;

namespace VKAPITest.TestSolution.Tests
{
    public class BaseTest
    {
        private readonly Browser browser = AqualityServices.Browser;

        [SetUp]
        public void Setup()
        {
            Logger.Instance.Info("Set up");
            browser.Maximize();
            browser.GoTo(TestDataGetter.Configs.BaseUrl);
            browser.WaitForPageToLoad();
        }

        [TearDown]
        public void TearDown()
        {
            Logger.Instance.Info("Tear down");
            browser.Quit();
        }
    }
}