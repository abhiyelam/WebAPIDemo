using WebAPIDemo.Data;
using WebAPIDemo.Model;

namespace WebAPIDemo.Repository
{
    public interface IProjectRepository
    {
        IEnumerable<Projects> GetAllProjects();
        Projects GetProjectById(int id);
        int AddProject(Projects project);
        int UpdateProject(Projects project);
        int DeleteProject(int id);
    }
    public class ProjectRepository: IProjectRepository
    {
           private readonly ApplicationDbContext db;

            public ProjectRepository(ApplicationDbContext db)
            {
                this.db = db;
            }

            public IEnumerable<Projects> GetAllProjects()
            {
                return db.Projects.ToList();
            }

            public Projects GetProjectById(int id)
            {
                return db.Projects.Find(id);
            }

            public int AddProject(Projects project)
            {
                db.Projects.Add(project);
                return db.SaveChanges();
            }

            public int UpdateProject(Projects project)
            {
                int result = 0;

                var p = db.Projects.Where(x => x.ProjectId == project.ProjectId).FirstOrDefault();

                if (p != null)
                {
                    p.ProjectName = project.ProjectName;
                    p.Description = project.Description;
                    p.StartDate = project.StartDate;
                    p.EndDate = project.EndDate;
                    p.Status = project.Status;
                    p.CreatedBy = project.CreatedBy;

                    result = db.SaveChanges();
                }

                return result;
            }

            public int DeleteProject(int id)
            {
                int result = 0;

                var p = db.Projects.Where(x => x.ProjectId == id).FirstOrDefault();

                if (p != null)
                {
                    db.Projects.Remove(p);
                    result = db.SaveChanges();
                }

                return result;
            }
        
    }
}
