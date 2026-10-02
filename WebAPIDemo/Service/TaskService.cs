using WebAPIDemo.Model;
using WebAPIDemo.Repository;

namespace WebAPIDemo.Service
{
    public interface ITaskService
    {
        IEnumerable<TaskItem> GetAllTasks();
        TaskItem GetTaskById(int id);
        int AddTask(TaskItem task);
        int UpdateTask(TaskItem task);
        int DeleteTask(int id);

    }
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository repo;
        public TaskService(ITaskRepository repo)
        {
            this.repo = repo;
        }
      
        public int AddTask(TaskItem task)
        {
            return repo.AddTask(task);
        }
        public int DeleteTask(int id)
        {
            return repo.DeleteTask(id);
        }

        public IEnumerable<TaskItem> GetAllTasks()
        {
            return repo.GetAllTasks();
        }

        public TaskItem GetTaskById(int id)
        {
            return repo.GetTaskById(id);
        }

        public int UpdateTask(TaskItem task)
        {
            return repo.UpdateTask(task);
        }
    }
}
