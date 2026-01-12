using System;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;


namespace TaskManager.Infrastructure.Mappings
{
    internal static class TaskMapping
    {
        public static TaskItem ToDomain(dynamic row)
        {
            var task = (TaskItem)Activator.CreateInstance(typeof(TaskItem), nonPublic: true)!;

            Set(task, "Id", (Guid)row.Id);
            Set(task, "Tiitle", (string)row.Tittle);
            Set(task, "Description", (string)row.Description);
            Set(task, "Status", (TaskStatus)row.Status);
            Set(task, "Priority", (TaskPriority)row.Priority);
            Set(task, "UserId", (Guid)row.UserId);
            Set(task, "CreatedAt", (DateTime?)row.CreatedAt);
            Set(task, "UpdatedAt", (DateTime?)row.UpdatedAt);

            return task;
        }

        private static void Set<T>(TaskItem target, string prop, T value)
        {
            var p = typeof(TaskItem).GetProperty(prop);
            p!.SetValue(target, value);
        }
    }
}
