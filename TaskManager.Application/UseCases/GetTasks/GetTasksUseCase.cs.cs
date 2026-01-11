using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Application.Abstractions.Repositories;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Application.UseCases.GetTasks
{
    public class GetTasksUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public GetTasksUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskDto>> ExecuteAsync(

            Guid userId,
            TaskStatus? status,
            TaskPriority? priority
        ){
            var tasks = await _taskRepository.GetTaskAsync(status, priority, userId);
            return tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Tittle,
                Description = t.Description,
                Priority = t.Priority,
                Status = t.Status

            });
        }
    }
}
