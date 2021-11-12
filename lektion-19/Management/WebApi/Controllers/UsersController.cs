using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly SqlContext _context;

        public UsersController(SqlContext context)
        {
            _context = context;
        }

        #region Get All Users

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _context.Users.ToListAsync();
            var users = new List<UserModel>();

            foreach(var user in result)
            {
                users.Add(new UserModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                });
            }

            return new OkObjectResult(users);
        }

        #endregion

        #region Get Specific User

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

            if (result == null)
                return NotFound();

            return new OkObjectResult(new UserModel
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email
            });
        }

        #endregion
    }
}
