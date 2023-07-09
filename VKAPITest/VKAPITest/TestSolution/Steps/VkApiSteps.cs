using Aquality.Selenium.Core.Logging;
using NUnit.Framework;
using VKAPITest.Framework.Utils;
using VKAPITest.TestSolution.Managers;
using VKAPITest.TestSolution.Models;

namespace VKAPITest.TestSolution.Steps
{
    public static class VkApiSteps
    {
        private const string fileField = "photo";
        private const string filePath = @"Resources\Images\avatar.png";

        public static void CreateTextPost(out Post post, string message)
        {
            Logger.Instance.Info("Create text post");
            post = VkApiUtils.CreateTextPost(message);
            Assert.That(post.Response.Post_Id, Is.Not.Null, "Post id is null");
        }

        public static void EditPost(Post post, string textForEditPost, out int photoId)
        {
            Logger.Instance.Info("Edit post");
            photoId = VkApiUtils.EditPostTextAndPhoto(post, textForEditPost, fileField, filePath).Response.First().Id;
        }

        public static void AddСomment(Post post, string textForComment)
        {
            Logger.Instance.Info("Add comment");
            VkApiUtils.AddСomment(post, textForComment);
        }

        public static void CheckLikeAppearOnPost(Post post)
        {
            Logger.Instance.Info("Check like appear on post");
            var postLiked = VkApiUtils.IsPostLiked(post);

            Assert.Multiple(() =>
            {
                Assert.That(postLiked.Response.Count, Is.Not.Zero, "Like was not added");
                Assert.That(TestDataGetter.UserData.UserId, Is.EqualTo(postLiked.Response.Items.FirstOrDefault().ToString()), "User id is not equal liked post user id");
            });
        }

        public static void DeletePost(Post post)
        {
            Logger.Instance.Info("Delete post");
            VkApiUtils.DeletePost(post);
        }
    }
}