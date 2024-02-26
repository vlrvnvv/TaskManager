using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Logic.Entities;
using TaskManager.Logic.Entities.Enums;
using TaskManager.Logic.Services.Interfaces;
using TaskManager.Logic.Utils;

namespace TaskManager.WPFUI
{
    /// <summary>
    /// Логика взаимодействия для EditWorkingTaskForm.xaml
    /// </summary>
    public partial class EditWorkingTaskForm : Window
    {
        private readonly WorkingTask _workingTask;
        private readonly IWorkingTaskService _workingTaskService;
        public EditWorkingTaskForm(WorkingTask workingTask)
        {
            InitializeComponent();
            _workingTask = workingTask;
            _workingTaskService = DependencyInjector.GetService<IWorkingTaskService>();
            FillWindowProps();
        }

        private void FillWindowProps()
        {
            TaskStatusComboBox.ItemsSource = (Status[])Enum.GetValues(typeof(Status));
            TaskStatusComboBox.SelectedIndex = (int)_workingTask.Status;
            NameTextBox.Text = _workingTask.Name;
            DescriptionTextBox.Text = _workingTask.Description;
            PerformerTextBox.Text = _workingTask.Performer;
            ComplexityTextBox.Text = _workingTask.Complexity.ToString();
            ExecutionTimeTextBox.Text = _workingTask.ExecutionTime.ToString();
            FinishTimeDatePicker.Text = _workingTask.FinishDate.ToString() ?? string.Empty;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _workingTaskService.Delete(_workingTask.Id);
                MessageBox.Show("Задача успешно удалена");
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при удалении задачи");
            }

            Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
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

            try
            {
                Status currentTaskStatus = (Status)TaskStatusComboBox.SelectedIndex;
                WorkingTask workingTask = new WorkingTask()
                {
                    Id = _workingTask.Id,
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Performer = PerformerTextBox.Text,
                    Complexity = complexity,
                    ExecutionTime = executionTime,
                    CreationDate = _workingTask.CreationDate,
                    Status = currentTaskStatus
                };

                if(currentTaskStatus == Status.Completed && string.IsNullOrEmpty(FinishTimeDatePicker.Text))
                    workingTask.FinishDate = DateTime.UtcNow;

                _workingTaskService.Update(workingTask);
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при обновлении задачи");
            }

            Close();
        }
    }
}
