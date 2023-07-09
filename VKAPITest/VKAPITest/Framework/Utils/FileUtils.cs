using Aquality.Selenium.Core.Logging;

namespace VKAPITest.Framework.Utils
{
    public class FileUtils
    {
        public static string GetDataFromFile(string path)
        {
            Logger.Instance.Info($"Get data from file {path}");
            return File.ReadAllText(path);
        }
    }
}