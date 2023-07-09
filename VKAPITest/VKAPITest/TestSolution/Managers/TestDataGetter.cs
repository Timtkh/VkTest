using VKAPITest.Framework.Utils;
using VKAPITest.TestSolution.Models;
using VKAPITest.TestSolution.Models.TestDataModels;

namespace VKAPITest.TestSolution.Managers
{
    public class TestDataGetter
    {
        private const string testDataObject = @"TestSolution\Configs\{0}.json";

        public static readonly User UserData = JsonUtils.Deserialize<User>(FileUtils.GetDataFromFile(string.Format(testDataObject, "userdata")));
        public static readonly Settings Configs = JsonUtils.Deserialize<Settings>(FileUtils.GetDataFromFile(string.Format(testDataObject, "configfile")));
    }
}