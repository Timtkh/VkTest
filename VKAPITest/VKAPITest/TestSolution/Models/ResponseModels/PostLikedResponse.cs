namespace VKAPITest.TestSolution.Models.ResponseModels
{
    public record PostLikedResponse
    {
        public int Count { get; set; }
        public int[] Items { get; set; }
    }
}