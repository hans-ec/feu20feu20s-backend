using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SqlContext _context;
        private readonly IAuthService _authService;

        public AuthenticationController(SqlContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp(SignUpModel model)
        {
            if (await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email) != null) 
                return Conflict();

            try
            {
                byte[] hash;
                byte[] salt;
                _authService.GenerateHash(model.Password, out hash, out salt);

                _context.Users.Add(new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserHash = new UserHash { PasswordHash = hash, Salt = salt }
                });
                await _context.SaveChangesAsync();

                return new OkResult();
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn(SignInModel model)
        {
            var user = await _context.Users.Include(x => x.UserHash).Include(x => x.UserSessions).FirstOrDefaultAsync(x => x.Email == model.Email);
            
            if (user == null)
                return new BadRequestResult();

            
            if (_authService.CompareHash(model.Password, user.UserHash.PasswordHash, user.UserHash.Salt))
            {
                var sessionToken = _authService.GenerateJwtToken(user.Id.ToString());
                _context.UserSessions.Add(new UserSession { UserId = user.Id, SessionToken = sessionToken });
                await _context.SaveChangesAsync();

                return new OkObjectResult(sessionToken);
            }          

            return new BadRequestResult();

        }


        [HttpPost("SignOut")]
        public async Task<ActionResult> SignOut(string sessionToken)
        {
            try
            {
                _context.UserSessions.Remove(await _context.UserSessions.FirstOrDefaultAsync(x => x.SessionToken == sessionToken));
                await _context.SaveChangesAsync();

                return new OkResult();
            }
            catch
            {
                return new BadRequestResult();
            }
        }

    }
}
