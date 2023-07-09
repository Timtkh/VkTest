using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKAPITest.TestSolution.Pages
{
    public class MyPage : Form
    {
        private static readonly string postXPath = "//*[@id='post{0}_{1}']";

        private ILabel postLabel(string userId, string postId) => ElementFactory.GetLabel(By.XPath(string.Format($"{postXPath}//*[contains(@class,'wall_post_text')]", userId, postId)), "Post label");
        private ILabel postAuthorLabel(string userId, string postId) => ElementFactory.GetLabel(By.XPath(string.Format($"{postXPath}//*[contains(@class,'post_author')]//*[contains(@href,'{userId}')]", userId, postId)), "Post author label");
        private ILabel postEditPhotoLabel(string userId, string photoId, string postId) => ElementFactory.GetLabel(By.XPath(string.Format($"{postXPath}//*[contains(@href,'{userId}_{photoId}')]", userId, postId)), "Post edit photo");
        private ILabel textLabel(string text) => ElementFactory.GetLabel(By.XPath($"//*[contains(text(),'{text}')]"), "Text label");
        private IButton showNextCommentsButton(string userId, string postId) => ElementFactory.GetButton(By.XPath(string.Format($"{postXPath}//*[contains(@class,'js-replies_next_label')]", userId, postId)), "Show next comments");
        private ILabel replyAuthorLabel(string userId, string postId) => ElementFactory.GetLabel(By.XPath(string.Format($"{postXPath}//*[contains(@class,'reply_author')]//*[contains(@data-from-id,'{userId}')]", userId, postId)), "Reply author");
        private IButton addLikeButton(string userId, string postId) => ElementFactory.GetButton(By.XPath(string.Format($"{postXPath}//*[contains(@data-section-ref,'reactions-button-container')]", userId, postId)), "Add like button");

        public MyPage() : base(By.Id("profile_redesigned"), "My page") { }

        public string GetPostText(string userId, string postId)
        {
            Logger.Instance.Info("Get post text");
            return postLabel(userId, postId).Text;
        }

        public bool IsRightPostAuthor(string userId, string postId)
        {
            Logger.Instance.Info("Is right post author");
            return postAuthorLabel(userId, postId).State.WaitForExist();
        }

        public bool IsPostEdit(string userId, string postId, string photoId, string textForEditPost)
        {
            Logger.Instance.Info("Is post edit");
            return postEditPhotoLabel(userId, photoId, postId).State.WaitForDisplayed()
                & textLabel(textForEditPost).State.WaitForDisplayed();
        }

        public bool IsTextBoxExist(string text)
        {
            Logger.Instance.Info("Is textbox exist");
            return textLabel(text).State.WaitForDisplayed();
        }

        public bool IsTextBoxNotExist(string text)
        {
            Logger.Instance.Info("Is textbox not exist");
            return textLabel(text).State.WaitForNotDisplayed();
        }

        public void ClickShowNextComments(string userId, string postId)
        {
            Logger.Instance.Info("Click show next comments");
            showNextCommentsButton(userId, postId).Click();
        }

        public bool IsRightReplyAuthor(string userId, string postId)
        {
            Logger.Instance.Info("Is right reply author");
            return replyAuthorLabel(userId, postId).State.WaitForExist();
        }

        public void LikePost(string userId, string postId)
        {
            Logger.Instance.Info("Like post");
            addLikeButton(userId, postId).Click();
        }
    }
}