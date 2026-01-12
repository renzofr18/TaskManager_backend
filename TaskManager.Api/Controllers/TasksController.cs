using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs;
using TaskManager.Application.UseCases.GetTasks;
using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TaskController : ControllerBase
{
    private readonly GetTasksUseCase _getTaskUseCase;

    public TaskController(GetTasksUseCase getTaskUseCase)
    {
        _getTaskUseCase = getTaskUseCase;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TaskDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks(
        [FromQuery] Guid userId,
        [FromQuery] TaskStatus? status,
        [FromQuery] TaskPriority? priority
    )
    {
        if (userId == Guid.Empty) return BadRequest("userId is required.");

        var tasks = await _getTaskUseCase.ExecuteAsync(userId, status, priority);
        return Ok(tasks);
    }
}
