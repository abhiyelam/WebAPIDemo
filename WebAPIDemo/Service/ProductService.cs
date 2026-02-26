using WebAPIDemo.Model;
using WebAPIDemo.Repository;

namespace WebAPIDemo.Service
{
    public interface IProductService
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
    public class ProductService: IProductService
    {
        private readonly IProductRepository repo;
        public ProductService(IProductRepository repo)
        {
            this.repo = repo;
        }
        public int AddProduct(Product product)
        {
            return repo.AddProduct(product);
        }

        public int DeleteProduct(int id)
        {
            return repo.DeleteProduct(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return repo.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return repo.GetProductById(id);
        }

        public int UpdateProduct(Product product)
        {
            return repo.UpdateProduct(product);
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
