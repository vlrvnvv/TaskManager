using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using TaskManager.Logic.Repository;
using TaskManager.Logic.Repository.Interfaces;
using TaskManager.Logic.Services;
using TaskManager.Logic.Services.Interfaces;

namespace TaskManager.Logic.Utils
{
    public static class DependencyInjector
    {
        private static readonly ServiceProvider _serviceProvider = null!;
        private const string _configFilePath = "Config\\DBConfig.json";
        private const string _defaultConnectionString = "Data Source=TaskManagerDatabase.db";

        static DependencyInjector()
        {
            var services = new ServiceCollection();

            if (File.Exists(_configFilePath))
            {
                string configFileData = File.ReadAllText(_configFilePath);
                JObject jsonConfig = JObject.Parse(configFileData);
                jsonConfig.TryGetValue(nameof(TaskManagerContext.ConnectionString), out var connectionSection);
                TaskManagerContext.ConnectionString = connectionSection.Value<string>();
            }
            else
            {
                TaskManagerContext.ConnectionString = _defaultConnectionString;
            }

            services.AddSingleton<IWorkingTaskRepository, WorkingTaskRepository>();

            services.AddSingleton<IWorkingTaskService, WorkingTaskService>(); 

            _serviceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() 
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
