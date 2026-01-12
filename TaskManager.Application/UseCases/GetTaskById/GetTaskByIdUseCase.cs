using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Abstractions.Repositories;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.UseCases.GetTaskById
{
    public class GetTaskByIdUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskByIdUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskDto?> ExecuteAsync(Guid userId, Guid taskId)
        {
            if(userId == Guid.Empty) throw new ArgumentException("userId is required.", nameof(userId));
            if(taskId == Guid.Empty) throw new ArgumentException("taskId is required.", nameof(taskId));

            TaskItem? task = await _taskRepository.GetTaskByIdAsync(taskId, userId);

            if (task is null) return null;

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Tittle,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority
            };

        } 
    }


}
