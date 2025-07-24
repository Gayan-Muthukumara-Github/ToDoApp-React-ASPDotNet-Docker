using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using todo_backend.Controllers;
using todo_backend.Models;
using todo_backend.Repositories;
using Xunit;

namespace todo_backend.Tests.Controllers
{
    public class TasksControllerTest
    {
        private readonly Mock<ITaskRepository> _mockRepo;
        private readonly TasksController _controller;

        public TasksControllerTest()
        {
            _mockRepo = new Mock<ITaskRepository>();
            _controller = new TasksController(_mockRepo.Object);
        }

        [Fact]
        public async Task CreateTask_ReturnsCreatedAtAction()
        {
            var task = new TaskItem { Title = "Test" };
            _mockRepo.Setup(r => r.AddTaskAsync(It.IsAny<TaskItem>())).ReturnsAsync(task);

            var result = await _controller.CreateTask(task);

            var createdAtResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(task, createdAtResult.Value);
        }

        [Fact]
        public async Task GetTasks_ReturnsOkWithTasks()
        {
            var tasks = new List<TaskItem>
            {
                new TaskItem { Title = "Task 1" },
                new TaskItem { Title = "Task 2" }
            };
            _mockRepo.Setup(r => r.GetActiveTasksAsync(It.IsAny<int>())).ReturnsAsync(tasks);

            var result = await _controller.GetTasks();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTasks = Assert.IsAssignableFrom<IEnumerable<TaskItem>>(okResult.Value);
            Assert.Equal(2, ((List<TaskItem>)returnedTasks).Count);
        }

        [Fact]
        public async Task MarkAsCompleted_TaskExists_ReturnsNoContent()
        {
            var task = new TaskItem { Id = 1, Title = "Test" };
            _mockRepo.Setup(r => r.GetTaskByIdAsync(1)).ReturnsAsync(task);

            var result = await _controller.MarkAsCompleted(1);

            Assert.IsType<NoContentResult>(result);
            _mockRepo.Verify(r => r.MarkAsCompletedAsync(task), Times.Once);
        }

        [Fact]
        public async Task MarkAsCompleted_TaskNotFound_ReturnsNotFound()
        {
            _mockRepo.Setup(r => r.GetTaskByIdAsync(1)).ReturnsAsync((TaskItem)null);

            var result = await _controller.MarkAsCompleted(1);

            Assert.IsType<NotFoundResult>(result);
        }
    }
} 