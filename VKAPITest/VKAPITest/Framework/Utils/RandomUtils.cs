using Aquality.Selenium.Core.Logging;

namespace VKAPITest.Framework.Utils
{
    public static class RandomUtils
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const int minStringValue = 5;
        private const int maxStringValue = 10;

        private static readonly Random random = new();

        public static string GetRandomLatinString()
        {
            Logger.Instance.Info("Get random latin string");
            return new string(Enumerable.Repeat(chars, random.Next(minStringValue, maxStringValue)).Select(str => str[random.Next(str.Length)]).ToArray());
        }
    }
}