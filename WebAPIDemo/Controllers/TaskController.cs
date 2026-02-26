using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Model;
using WebAPIDemo.Service;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IProductService service;

        public TaskController(IProductService service)
        {
            this.service = service;
        }

        //GET: api/Task/GetAllTasks
       [HttpGet]
       [Route("GetAllTasks")]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(service.GetAllTasks());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Task/GetTaskById/5
        [HttpGet]
        [Route("GetTaskById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.GetTaskById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
        }

        // POST: api/Task/AddTask
        [HttpPost]
        [Route("AddTask")]
        public IActionResult Post([FromBody] TaskItem task)
        {
            try
            {
                int result = service.AddTask(task);

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

        // PUT: api/Task/UpdateTask
        [HttpPut]
        [Route("UpdateTask")]
        public IActionResult Put([FromBody] TaskItem task)
        {
            try
            {
                int result = service.UpdateTask(task);

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

        // DELETE: api/Task/DeleteTask/5
        [HttpDelete]
        [Route("DeleteTask/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = service.DeleteTask(id);

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

