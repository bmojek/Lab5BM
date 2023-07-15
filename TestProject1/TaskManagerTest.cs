using Lab5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Lab5.Task;

namespace TestProject1
{
    public class TaskManagerTest
    {

        private TaskManager _taskManager;
        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }
        [Test]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            // Arrange
            var task = new Task("Test task");
            // Act
            _taskManager.AddTask(task);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }
        [Test]
        public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
        {
            var task = new Task("Zadanie");
            _taskManager.AddTask(task);

            int TaskCount = _taskManager.GetTasks().Count;

            _taskManager.RemoveTask(task.Id);

            Assert.AreEqual(TaskCount - 1, _taskManager.GetTasks().Count);
        }
        [Test]
        public void RemoveTask_NonExistingTask_ShouldNotChangeTaskCount()
        {
            var task = new Task("Zadanie");
            _taskManager.AddTask(task);

            _taskManager.RemoveTask(task.Id+1);

            Assert.AreEqual(_taskManager.GetTasks().Count, 1);
        }
    }
}
