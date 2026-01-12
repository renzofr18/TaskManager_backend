namespace TaskManager.Api.Models.Requests
{
    public sealed class UpdateTaskRequest
    {
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } 
        public bool IsCompleted {  get; init; }
    }
}
