using System.Collections.Generic;
using System.Threading.Tasks;
using todo_backend.Models;

namespace todo_backend.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskItem> AddTaskAsync(TaskItem task);
        Task<IEnumerable<TaskItem>> GetActiveTasksAsync(int count);
        Task<TaskItem?> GetTaskByIdAsync(int id);
        Task MarkAsCompletedAsync(TaskItem task);
    }
} 