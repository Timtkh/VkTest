using Aquality.Selenium.Core.Logging;
using RestSharp;

namespace VKAPITest.Framework.Utils
{
    public static class APIUtils
    {
        private static readonly RestClient client = new();

        public static RestResponse Get(string urlParam)
        {
            Logger.Instance.Info("Get method");
            return client.Execute(new RestRequest(urlParam, Method.Get));
        }

        public static RestResponse Post(string urlParam)
        {
            Logger.Instance.Info("Post method");
            return client.Execute(new RestRequest(urlParam, Method.Post));
        }

        public static RestResponse PostFile(string urlParam, string fileName, string filePath)
        {
            Logger.Instance.Info("Post file method");
            var request = new RestRequest(urlParam, Method.Post);
            request.AddFile(fileName, filePath);
            return client.Execute(request);
        }
    }
}