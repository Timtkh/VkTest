using Aquality.Selenium.Core.Logging;
using Newtonsoft.Json;

namespace VKAPITest.Framework.Utils
{
    public class JsonUtils
    {
        public static T Deserialize<T>(string json)
        {
            Logger.Instance.Info("JsonUtils deserialize");
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}