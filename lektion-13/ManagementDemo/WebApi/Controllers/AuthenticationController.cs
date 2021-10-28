using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApi;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SqlContext _context;

        public AuthenticationController(SqlContext context)
        {
            _context = context;
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn(SignInModel model)
        {

            var user = await _context.Users.Where(x => x.Email == model.Email).FirstOrDefaultAsync();

            if(user != null)
            {
                if(user.Password == model.Password)
                {
                    return new OkObjectResult(JsonConvert.SerializeObject(new { userId = user.Id, sessionId = Guid.NewGuid().ToString() }));
                }

                return new BadRequestObjectResult(JsonConvert.SerializeObject(new { message = "incorrect email address or password" }));
            }

            return new BadRequestObjectResult(JsonConvert.SerializeObject(new { message = "incorrect email address or password" }));

        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp(SignUpModel model)
        {

            var _user = await _context.Users.Where(x => x.Email == model.Email).FirstOrDefaultAsync();

            if (_user == null)
            {
                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password
                };


                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return new OkResult();
            }

            return new BadRequestObjectResult(JsonConvert.SerializeObject(new { message = "a user with the same email address already exists." }));

        }


    }
}
