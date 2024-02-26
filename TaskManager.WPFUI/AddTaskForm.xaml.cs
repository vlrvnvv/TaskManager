using Microsoft.Identity.Client;
using System;
using System.Windows;
using TaskManager.Logic.Entities;
using TaskManager.Logic.Entities.Enums;
using TaskManager.Logic.Services.Interfaces;
using TaskManager.Logic.Utils;

namespace TaskManager.WPFUI
{
    public partial class AddTaskForm : Window
    {
        private readonly IWorkingTaskService _taskService;

        public AddTaskForm()
        {
            InitializeComponent();
            _taskService = DependencyInjector.GetService<IWorkingTaskService>();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(ComplexityTextBox.Text, out int complexity))
            {
                MessageBox.Show("Неверно указано значение сложности задачи");
                return;
            }

            if (!int.TryParse(ExecutionTimeTextBox.Text, out int executionTime))
            {
                MessageBox.Show("Неверно указано значение времени выполнения");
                return;
            }

            var newTask = new WorkingTask
            {
                Name = NameTextBox.Text,
                Description = DescriptionTextBox.Text,
                Performer = PerformerTextBox.Text,
                CreationDate = DateTime.UtcNow,
                Status = Status.NotAssigned,
                Complexity = complexity,
                ExecutionTime = executionTime,
            };

            if (!string.IsNullOrEmpty(newTask.Performer))
                newTask.Status = Status.Assigned;

            // Add the new task
            _taskService.Add(newTask);

            // Close the form
            Close();
        }
    }
}
