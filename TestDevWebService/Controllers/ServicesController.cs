using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDevWebService.Models;

namespace TestDevWebService.Controllers
{
    [Route("TestDevWebService/[controller]/[action]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly TestWebAppContext _context;

        public ServicesController(TestWebAppContext context)
        {
            _context = context;
        }

        // GET: TestDevWebService/Services/username
        [HttpGet("{username}")]
        public new async Task<ActionResult<User>> User(string username)
        {
            var userWithItems = await _context.User.Where(u => u.UserName == username).Include(user => user.Items).FirstOrDefaultAsync();

            if (userWithItems == null)
            {
                return NotFound();
            }

            return Ok(userWithItems);
        }

        [HttpGet]
        public  async Task<ActionResult<IEnumerable<string>>> GetUsers()
        {
            var userWithItems = await _context.User.Select(u => u.UserName).ToListAsync();

            if (userWithItems == null)
            {
                return NotFound();
            }

            return Ok(userWithItems);
        }
    }
}
