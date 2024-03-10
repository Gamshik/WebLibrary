namespace Domain.Classes.Entities
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
