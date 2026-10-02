
using WebAPIDemo.Model;
using WebAPIDemo.Repository;

namespace WebAPIDemo.Service
{
    public interface IProjectService
    {
        IEnumerable<Projects> GetAllProjects();
        Projects GetProjectById(int id);
        int AddProject(Projects project);
        int UpdateProject(Projects project);
        int DeleteProject(int id);
    }
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository repo;

        public ProjectService(IProjectRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Projects> GetAllProjects()
        {
            return repo.GetAllProjects();
        }

        public Projects GetProjectById(int id)
        {
            return repo.GetProjectById(id);
        }

        public int AddProject(Projects project)
        {
            return repo.AddProject(project);
        }

        public int UpdateProject(Projects project)
        {
            return repo.UpdateProject(project);
        }

        public int DeleteProject(int id)
        {
            return repo.DeleteProject(id);
        }
    }
}

