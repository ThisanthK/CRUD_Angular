using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthenticationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Authentication user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Authentication loginUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(f => f.Email == loginUser.Email && f.Password == loginUser.Password);
            if (user == null) 
                return Unauthorized();
            return Ok(user);

        }
    }
}
