using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKAPITest.TestSolution.Pages
{
    public class FeedPage : Form
    {
        public FeedPage() : base(By.Id("side_bar_inner"), "Feed page") { }
    }
}