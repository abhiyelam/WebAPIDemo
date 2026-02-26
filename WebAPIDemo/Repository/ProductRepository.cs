using WebAPIDemo.Data;
using WebAPIDemo.Model;

namespace WebAPIDemo.Repository
{
    public interface IProductRepository
    {
        
      IEnumerable<Product> GetAllProducts();
      Product GetProductById(int id);
      int AddProduct(Product product);
      int UpdateProduct(Product product);
      int DeleteProduct(int id);
      IEnumerable<TaskItem> GetAllTasks();
      TaskItem GetTaskById(int id);
      int AddTask(TaskItem task);
      int UpdateTask(TaskItem task);
      int DeleteTask(int id);

    }
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext db;
            public ProductRepository(ApplicationDbContext db)
            {
                this.db = db;
            }
            public int AddProduct(Product product)
            {
                db.Products.Add(product);
                int result = db.SaveChanges();
                return result;

            }

            public int DeleteProduct(int id)
            {
                int result = 0;
                var p = db.Products.Where(x => x.Id == id).FirstOrDefault();
                if (p != null)
                {
                    db.Products.Remove(p);
                    result = db.SaveChanges();
                }
                return result;


            }

            public IEnumerable<Product> GetAllProducts()
            {
                return db.Products.ToList();
            }

            public Product GetProductById(int id)
            {
                return db.Products.Find(id);
            }

            public int UpdateProduct(Product product)
            {
                int result = 0;
                var p = db.Products.Where(x => x.Id == product.Id).FirstOrDefault();
                if (p != null)
                {
                    p.Name = product.Name;
                    p.Price = product.Price;
                    p.Company = product.Company;
                    result = db.SaveChanges();
                }
                return result;
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
            var t = db.Tasks.Where(x => x.TaskId == task.TaskId).FirstOrDefault();
            if (t != null)
            {
                t.Title = task.Title;
                t.IsCompleted = task.IsCompleted;

                result = db.SaveChanges();
            }
            return result;
        }

    }
}
