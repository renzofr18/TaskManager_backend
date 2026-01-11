using System;
using TaskManager.Domain.Common;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities
{
    public class TaskItem: BaseEntity
    {
        public string Tittle { get; private set; } = null;
        public string Description { get; private set; } = null;
        public TaskStatus Status { get; private set; } 
        public TaskPriority Priority { get; private set; } 
        public Guid UserId { get; private set; } 

        protected TaskItem() { }

        public TaskItem(string tittle, string description, TaskStatus status, TaskPriority priority, Guid userId)
        {
            Id = Guid.NewGuid();
            Tittle = tittle;
            Description = description;
            Status = status;
            Priority = priority;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsCompleted()
        {
            Status = TaskStatus.Completed;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
