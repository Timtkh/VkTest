using NUnit.Framework;
using VKAPITest.Framework.Utils;
using VKAPITest.TestSolution.Managers;
using VKAPITest.TestSolution.Models;
using VKAPITest.TestSolution.Steps;

namespace VKAPITest.TestSolution.Tests
{
    public class VKTest : BaseTest
    {
        private static readonly string textForPost = RandomUtils.GetRandomLatinString();
        private static readonly string textForEditPost = RandomUtils.GetRandomLatinString();
        private static readonly string textForComment = RandomUtils.GetRandomLatinString();
        private static Post post;
        private static int photoId;

        [Test]
        public void Run_VKTest()
        {
            VkUiSteps.OpenVKWebsite();
            VkUiSteps.Authorization(TestDataGetter.UserData);
            VkUiSteps.GoToMyPage();
            VkApiSteps.CreateTextPost(out post, textForPost);
            VkUiSteps.CheckPostAppear(post, textForPost);
            VkApiSteps.EditPost(post, textForEditPost, out photoId);
            VkUiSteps.CheckPostEdit(post, textForEditPost, photoId);
            VkApiSteps.AddСomment(post, textForComment);
            VkUiSteps.CheckCommentAdd(post, textForComment);
            VkUiSteps.AddLikeToPost(post);
            VkApiSteps.CheckLikeAppearOnPost(post);
            VkApiSteps.DeletePost(post);
            VkUiSteps.CheckPostDelete(textForEditPost);
        }
    }
}