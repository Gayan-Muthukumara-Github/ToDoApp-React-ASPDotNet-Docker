using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todo_backend.Data;
using todo_backend.Models;

namespace todo_backend.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> AddTaskAsync(TaskItem task)
        {
            try
            {
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();
                return task;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddTaskAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<TaskItem>> GetActiveTasksAsync(int count)
        {
            try
            {
                return await _context.Tasks
                    .Where(t => !t.IsCompleted)
                    .OrderByDescending(t => t.CreatedAt)
                    .Take(count)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetActiveTasksAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            try
            {
                return await _context.Tasks.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTaskByIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task MarkAsCompletedAsync(TaskItem task)
        {
            try
            {
                task.IsCompleted = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MarkAsCompletedAsync: {ex.Message}");
                throw;
            }
        }
    }
} 