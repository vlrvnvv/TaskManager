using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManager.Logic.Entities;
using TaskManager.Logic.Entities.Enums;
using TaskManager.Logic.Services.Interfaces;
using TaskManager.Logic.Utils;

namespace TaskManager.WPFUI
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<Status, ObservableCollection<WorkingTask>> _tasksByStatus;
        public Dictionary<Status, ObservableCollection<WorkingTask>> TasksByStatus
        {
            get { return _tasksByStatus; }
            set
            {
                _tasksByStatus = value;
                OnPropertyChanged(nameof(TasksByStatus));
            }
        }

        private readonly IWorkingTaskService _taskService;

        public MainWindow()
        {
            InitializeComponent();
            _taskService = DependencyInjector.GetService<IWorkingTaskService>();
            LoadTasks();
            DataContext = this;
        }

        private void LoadTasks()
        {
            var allTasks = _taskService.GetAll();
            var newTasksByStatus = new Dictionary<Status, ObservableCollection<WorkingTask>>();

            foreach (var status in (Status[])Enum.GetValues(typeof(Status)))
            {
                newTasksByStatus[status] = new ObservableCollection<WorkingTask>(allTasks.FindAll(task => task.Status == status));
            }

            TasksByStatus = newTasksByStatus;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addTaskForm = new AddTaskForm();
            addTaskForm.ShowDialog();

            LoadTasks();
        }

        private void Task_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) // Проверяем двойной клик
            {
                var selectedTask = ((Border)sender).DataContext as WorkingTask;
                var editTaskForm = new EditWorkingTaskForm(selectedTask);
                editTaskForm.ShowDialog();

                LoadTasks();
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}