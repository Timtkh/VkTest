using Aquality.Selenium.Core.Logging;
using VKAPITest.TestSolution.Managers;
using VKAPITest.TestSolution.Models;

namespace VKAPITest.Framework.Utils
{
    public class VkApiUtils
    {
        private const string version = "5.131";
        private const string createPostAPI = "https://api.vk.com/method/wall.post?v={0}&owner_id={1}&access_token={2}&message={3}";
        private const string editPostAPI = "https://api.vk.com/method/wall.edit?v={0}&owner_id={1}&access_token={2}&post_id={3}&message={4}&attachments=photo{1}_{5}";
        private const string addCommentPostAPI = "https://api.vk.com/method/wall.createComment?v={0}&owner_id={1}&access_token={2}&post_id={3}&message={4}";
        private const string isPostLikedAPI = "https://api.vk.com/method/likes.getList?v={0}&owner_id={1}&access_token={2}&type=post&item_id={3}";
        private const string deletePostAPI = "https://api.vk.com/method/wall.delete?v={0}&user_ids={1}&access_token={2}&post_id={3}";
        private const string getWallUploadServerAPI = "https://api.vk.com/method/photos.getWallUploadServer?v={0}&owner_id={1}&access_token={2}";
        private const string saveWallPhotoAPI = "https://api.vk.com/method/photos.saveWallPhoto?v={0}&user_id={1}&access_token={2}&server={3}&hash={4}&photo={5}";

        public static Post CreateTextPost(string message)
        {
            Logger.Instance.Info("Create text post VkApiUtils");
            return JsonUtils.Deserialize<Post>(APIUtils.Post(string.Format(createPostAPI, version, TestDataGetter.UserData.UserId, TestDataGetter.UserData.AccessToken, message)).Content ?? throw new ArgumentNullException("Content is null"));
        }

        public static SaveWallPhoto EditPostTextAndPhoto(Post post, string message, string fileField, string filePath)
        {
            Logger.Instance.Info("Edit post text and photo VkApiUtils");
            var uploadServer = JsonUtils.Deserialize<UploadServer>(APIUtils.Post(string.Format(getWallUploadServerAPI, version, TestDataGetter.UserData.UserId, TestDataGetter.UserData.AccessToken)).Content ?? throw new ArgumentNullException("Content is null"));
            var uploadFile = JsonUtils.Deserialize<UploadFile>(APIUtils.PostFile(uploadServer.Response.Upload_Url, fileField, filePath).Content ?? throw new ArgumentNullException("Content is null"));
            var saveWallPhoto = JsonUtils.Deserialize<SaveWallPhoto>(APIUtils.Post(string.Format(saveWallPhotoAPI, version, TestDataGetter.UserData.UserId, TestDataGetter.UserData.AccessToken, uploadFile.Server, uploadFile.Hash, uploadFile.Photo)).Content ?? throw new ArgumentNullException("Content is null"));
            APIUtils.Post(string.Format(editPostAPI, version, TestDataGetter.UserData.UserId, TestDataGetter.UserData.AccessToken, post.Response.Post_Id, message, saveWallPhoto.Response.First().Id));
            return saveWallPhoto;
        }

        public static void AddСomment(Post post, string message)
        {
            Logger.Instance.Info("Add comment VkApiUtils");
            APIUtils.Post(string.Format(addCommentPostAPI, version, TestDataGetter.UserData.UserId, TestDataGetter.UserData.AccessToken, post.Response.Post_Id, message));
        }

        public static PostLiked IsPostLiked(Post post)
        {
            Logger.Instance.Info("Check like appear on post VkApiUtils");
            return JsonUtils.Deserialize<PostLiked>(APIUtils.Get(string.Format(isPostLikedAPI, version, TestDataGetter.UserData.UserId, TestDataGetter.UserData.AccessToken, post.Response.Post_Id)).Content ?? throw new ArgumentNullException("Content is null"));
        }

        public static void DeletePost(Post post)
        {
            Logger.Instance.Info("Delete post VkApiUtils");
            APIUtils.Post(string.Format(deletePostAPI, version, TestDataGetter.UserData.UserId, TestDataGetter.UserData.AccessToken, post.Response.Post_Id));
        }
    }
}