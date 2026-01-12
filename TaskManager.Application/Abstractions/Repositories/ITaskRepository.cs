using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Application.Abstractions.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetTaskAsync(
            TaskStatus? status,
            TaskPriority? priority,
            Guid userId
        );

        Task<TaskItem?> GetTaskByIdAsync(Guid taskId, Guid userId);

    }
}
