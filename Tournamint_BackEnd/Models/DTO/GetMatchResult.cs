namespace Tournamint_BackEnd.Models.DTO
{
    public class GetMatchResult
    {
        public GetMatchResult(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
