using WebAPIDemo.Data;
using WebAPIDemo.Model;

namespace WebAPIDemo.Repository
{
    public interface ITaskRepository
    {

       
        IEnumerable<TaskItem> GetAllTasks();
        TaskItem GetTaskById(int id);
        int AddTask(TaskItem task);
        int UpdateTask(TaskItem task);
        int DeleteTask(int id);

    }
    public class TaskRepository: ITaskRepository
    {
        private readonly ApplicationDbContext db;
        public TaskRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
     
        public int AddTask(TaskItem task)
        {
            db.Tasks.Add(task);
            int result = db.SaveChanges();
            return result;
        }

        public int DeleteTask(int id)
        {
            int result = 0;

            var t = db.Tasks.Where(x => x.TaskId == id).FirstOrDefault();

            if (t != null)
            {
                db.Tasks.Remove(t);
                result = db.SaveChanges();
            }

            return result;
        }

        public IEnumerable<TaskItem> GetAllTasks()
        {
            return db.Tasks.ToList();
        }

        public TaskItem GetTaskById(int id)
        {
            return db.Tasks.Find(id);
        }

        public int UpdateTask(TaskItem task)
        {
            int result = 0;

            var t = db.Tasks.FirstOrDefault(x => x.TaskId == task.TaskId);

            if (t != null)
            {
                t.Title = task.Title;
                t.Description = task.Description;
                t.IsCompleted = task.IsCompleted;
                t.ProjectId = task.ProjectId;
                t.AssignedTo = task.AssignedTo;
                t.Priority = task.Priority;
                t.Status = task.Status;
                t.DueDate = task.DueDate;

                // Normally CreatedDate should not be updated.
                // Uncomment only if you want to change it.
                t.CreatedDate = task.CreatedDate;

                result = db.SaveChanges();
            }

            return result;
        }

    }
}

