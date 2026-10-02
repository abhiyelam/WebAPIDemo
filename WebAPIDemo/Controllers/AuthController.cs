using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Data;
using WebAPIDemo.Model;
using Microsoft.EntityFrameworkCore;
namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] Users user)
        {
            try
            {
                var emailExists = await _context.Users
                    .AnyAsync(x => x.Email == user.Email);

                if (emailExists)
                {
                    return BadRequest("Email already exists.");
                }

                user.CreatedDate = DateTime.Now;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok("Registration Successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x =>
                    x.Email == model.Email &&
                    x.Password == model.Password);

                if (user == null)
                {
                    return Unauthorized("Invalid Email or Password");
                }

                return Ok(new
                {
                    user.UserId,
                    user.Name,
                    user.Email,
                    user.Role
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
