using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_backend.Data;
using todo_backend.Models;

namespace todo_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly Repositories.ITaskRepository _repository;
        public TasksController(Repositories.ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Models.TaskItem task)
        {
            task.CreatedAt = DateTime.UtcNow;
            var createdTask = await _repository.AddTaskAsync(task);
            return CreatedAtAction(nameof(GetTasks), new { id = createdTask.Id }, createdTask);
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _repository.GetActiveTasksAsync(5);
            return Ok(tasks);
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> MarkAsCompleted(int id)
        {
            var task = await _repository.GetTaskByIdAsync(id);
            if (task == null) return NotFound();

            await _repository.MarkAsCompletedAsync(task);
            return NoContent();
        }
    }
}
