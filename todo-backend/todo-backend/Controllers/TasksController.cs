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
        private readonly AppDbContext _context;
        public TasksController(AppDbContext context)
        {
            _context = context;
        }
        // POST: api/tasks
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _context.Tasks
                .Where(t => !t.IsCompleted)
                .OrderByDescending(t => t.CreatedAt)
                .Take(5)
                .ToListAsync();

            return Ok(tasks);
        }

        // PUT: api/tasks/3/complete
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> MarkAsCompleted(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            task.IsCompleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
