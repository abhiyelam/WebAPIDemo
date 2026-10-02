using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Model;
using WebAPIDemo.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // GET: api/<ProjectController>
public class ProjectController : ControllerBase
    {
        private readonly IProjectService service;

        public ProjectController(IProjectService service)
        {
            this.service = service;
        }

        // GET: api/Project/GetAllProjects
        [HttpGet]
        [Route("GetAllProjects")]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(service.GetAllProjects());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Project/GetProjectById/5
        [HttpGet]
        [Route("GetProjectById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.GetProjectById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
        }

        // POST: api/Project/AddProject
        [HttpPost]
        [Route("AddProject")]
        public IActionResult Post([FromBody] Projects project)
        {
            try
            {
                int result = service.AddProject(project);

                if (result == 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Project/UpdateProject
        [HttpPut]
        [Route("UpdateProject")]
        public IActionResult Put([FromBody] Projects project)
        {
            try
            {
                int result = service.UpdateProject(project);

                if (result == 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Project/DeleteProject/5
        [HttpDelete]
        [Route("DeleteProject/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = service.DeleteProject(id);

                if (result == 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

