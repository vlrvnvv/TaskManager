using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Logic.Entities;
using TaskManager.Logic.Repository.Interfaces;

namespace TaskManager.Logic.Repository
{
    public class WorkingTaskRepository : IWorkingTaskRepository
    {
        public WorkingTask Add(WorkingTask task)
        {
            using TaskManagerContext context = new TaskManagerContext();

            var savedTask = context.WorkingTasks.Add(task);

             context.SaveChanges();

            return savedTask.Entity;
        }

        public void Delete(long id)
        {
            using TaskManagerContext context = new TaskManagerContext();

            WorkingTask taskToDelete = new WorkingTask()
            {
                Id = id,
            };

            context.WorkingTasks.Remove(taskToDelete);
            context.SaveChanges();
            
        }

        public List<WorkingTask> GetAll()
        {
            using TaskManagerContext context = new TaskManagerContext();

            return context.WorkingTasks.ToList();
        }

        public WorkingTask GetById(long id)
        {
            using TaskManagerContext context = new TaskManagerContext();

            return context.WorkingTasks.FirstOrDefault(wt => wt.Id == id);
        }

        public WorkingTask Update(WorkingTask task)
        {
            using TaskManagerContext context = new TaskManagerContext();

            var updatedTask = context.WorkingTasks.Update(task);

            context.SaveChanges();

            return updatedTask.Entity;

        }
    }
}
