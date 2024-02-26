using System.Runtime.CompilerServices;
using TaskManager.Logic.Entities;
using TaskManager.Logic.Services.Interfaces;
using TaskManager.Logic.Utils;

namespace TaskManager.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkingTask workingTask = new WorkingTask()
            {
                Name = "Test",
                Performer = "Test",
                Complexity = 5,
                Description = "Test",
                CreationDate = DateTime.UtcNow,
                ExecutionTime = 1,
                FinishDate = DateTime.UtcNow,
                Status = Logic.Entities.Enums.Status.Completed
            };

            IWorkingTaskService workingTaskService = DependencyInjector.GetService<IWorkingTaskService>();

            workingTaskService.Add(workingTask);

        }
    }
}
