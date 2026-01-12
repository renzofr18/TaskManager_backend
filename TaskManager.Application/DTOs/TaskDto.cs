using System;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.DTOs
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null;
        public string Description { get; set; } = null;
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }

    }
}
