using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Logic.Entities;

namespace TaskManager.Logic.Repository.Interfaces
{
    public interface IWorkingTaskRepository
    {
        /// <summary>
        /// Добавить задачу
        /// </summary>
        WorkingTask Add(WorkingTask task);

        /// <summary>
        /// Обновить задачу
        /// </summary>
        WorkingTask Update(WorkingTask task);

        /// <summary>
        /// Удалить задачу
        /// </summary>
        void Delete(long id);

        /// <summary>
        /// Найти задачу по id
        /// </summary>
        WorkingTask GetById(long id);

        /// <summary>
        /// Получить все задачи
        /// </summary>
        List<WorkingTask> GetAll();
    }
}
