using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TaskManager.Application.Abstractions.Repositories;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskManager.Infrastructure.Mappings;
using TaskManager.Infrastructure.Persistence;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;


namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public TaskRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<TaskItem>> GetTaskAsync(
            TaskStatus? status,
            TaskPriority? priority,
            Guid userId)
        {
            const string sp = "dbo.SP_Tasks_ListByUser";

            using var connection = _connectionFactory.CreateConnection();

            var parameters = new
            {
                UserId = userId,
                Status = status.HasValue ? (int)status.Value : 0,
                Priority = priority.HasValue ? (int)priority.Value : 0
            };

            var rows = await connection.QueryAsync<TaskRow>(sp, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return rows.Select(r => TaskMapping.ToDomain(r));
        }
            private sealed class TaskRow
            {
                public Guid Id { get; set; }
                public string Title { get; set; } = null;
                public string Description { get; set; } = null;
                public int Status { get; set; }
                public int Priority { get; set; }
                public Guid UserId { get; set; }
                public DateTime CreatedAt { get; set; }
                public DateTime? UpdatedAt { get; set; }
            }      
    }   
}
