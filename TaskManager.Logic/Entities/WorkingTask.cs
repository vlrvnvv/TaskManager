using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Logic.Entities.Enums;

namespace TaskManager.Logic.Entities
{
    public class WorkingTask
    {
        /// <summary>
        /// Уникальный идентификатор 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Исполнитель
        /// </summary>
        public string Performer { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Статус задачи
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Трудоемкость задачи
        /// </summary>
        public int Complexity { get; set; }

        /// <summary>
        /// Время выполнения, значение в часах
        /// </summary>
        public int ExecutionTime { get; set; }

        /// <summary>
        /// Дата завершения
        /// </summary>
        public DateTime? FinishDate { get; set; }
    }
}
