namespace VKAPITest.TestSolution.Models
{
    public record UploadFile
    {
        public int Server { get; set; }
        public string Photo { get; set; }
        public string Hash { get; set; }
    }
}