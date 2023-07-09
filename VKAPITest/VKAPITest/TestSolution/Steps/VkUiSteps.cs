using Aquality.Selenium.Core.Logging;
using NUnit.Framework;
using VKAPITest.TestSolution.Forms;
using VKAPITest.TestSolution.Managers;
using VKAPITest.TestSolution.Models;
using VKAPITest.TestSolution.Pages;

namespace VKAPITest.TestSolution.Steps
{
    public static class VkUiSteps
    {
        private static readonly LoginPage loginPage = new();
        private static readonly IDVKPage iDVKPage = new();
        private static readonly FeedPage feedPage = new();
        private static readonly NavigateForm navigateForm = new();
        private static readonly MyPage myPage = new();

        public static void OpenVKWebsite()
        {
            Logger.Instance.Info("Open VK website");
            Assert.That(loginPage.State.WaitForDisplayed(), Is.True, "Login page is not opened");
        }

        public static void Authorization(User user)
        {
            Logger.Instance.Info("Authorization");
            loginPage.EnterLogin(user.Login);
            loginPage.ClickEnter();

            Assert.That(iDVKPage.State.WaitForDisplayed(), Is.True, "ID VK page is not opened");

            iDVKPage.EnterPassword(user.Password);
            loginPage.ClickEnter();

            Assert.That(feedPage.State.WaitForDisplayed(), Is.True, "Feed page is not opened");
        }

        public static void GoToMyPage()
        {
            Logger.Instance.Info("Go to my page");
            navigateForm.ClickMyPageButton();

            Assert.That(myPage.State.WaitForDisplayed(), Is.True, "My page is not opened");
        }

        public static void CheckPostAppear(Post post, string postText)
        {
            Logger.Instance.Info("Check post appear");
            Assert.Multiple(() =>
            {
                Assert.That(myPage.GetPostText(TestDataGetter.UserData.UserId, post.Response.Post_Id), Is.EqualTo(postText), "Text from post is not equal text for post");
                Assert.That(myPage.IsRightPostAuthor(TestDataGetter.UserData.UserId, post.Response.Post_Id), Is.True, "Post author is not right");
            });
        }

        public static void CheckPostEdit(Post post, string postEditText, int photoId)
        {
            Logger.Instance.Info("Check post edit");
            Assert.That(myPage.IsPostEdit(TestDataGetter.UserData.UserId, post.Response.Post_Id, photoId.ToString(), postEditText), Is.True, "Post was not edit");
        }

        public static void CheckCommentAdd(Post post, string commentText)
        {
            Logger.Instance.Info("Check comment add");
            myPage.ClickShowNextComments(TestDataGetter.UserData.UserId, post.Response.Post_Id);

            Assert.Multiple(() =>
            {
                Assert.That(myPage.IsTextBoxExist(commentText), Is.True, "Comment is not add");
                Assert.That(myPage.IsRightReplyAuthor(TestDataGetter.UserData.UserId, post.Response.Post_Id), Is.True, "Reply author is not right");
            });
        }

        public static void AddLikeToPost(Post post)
        {
            Logger.Instance.Info("Add like to post");
            myPage.LikePost(TestDataGetter.UserData.UserId, post.Response.Post_Id);
        }

        public static void CheckPostDelete(string postText)
        {
            Logger.Instance.Info("Check post delete");
            Assert.That(myPage.IsTextBoxNotExist(postText), Is.True, "Post was not deleted");
        }
    }
}