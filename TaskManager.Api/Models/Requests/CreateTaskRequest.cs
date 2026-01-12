namespace TaskManager.Api.Models.Requests
{
    public sealed class CreateTaskRequest
    {
        public string Titlle { get; init; } = string.Empty;
        public string? Description {  get; init; } 
    }
}
