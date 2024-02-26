using TaskManager.Logic.Entities;
using TaskManager.Logic.Repository.Interfaces;
using TaskManager.Logic.Services.Interfaces;

namespace TaskManager.Logic.Services
{
    public class WorkingTaskService : IWorkingTaskService
    {
        private readonly IWorkingTaskRepository _repository;

        public WorkingTaskService(IWorkingTaskRepository repository)
        {
            _repository = repository;
        }

        public WorkingTask Add(WorkingTask task)
        {
            return _repository.Add(task);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<WorkingTask> GetAll()
        {
            return _repository.GetAll();
        }

        public WorkingTask GetById(long id)
        {
            return _repository.GetById(id);
        }

        public WorkingTask Update(WorkingTask task)
        {
            return _repository.Update(task);
        }
    }
}
