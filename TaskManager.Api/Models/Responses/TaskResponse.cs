namespace TaskManager.Api.Models.Responses
{
    public sealed class TaskResponse
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; }
        public bool IsCompleted { get; init; }
    }
}
