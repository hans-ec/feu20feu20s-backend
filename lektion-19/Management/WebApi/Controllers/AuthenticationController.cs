using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Services;
using WebApi.Data;

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


        #region SignUp

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if (await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email) != null)
                return new ConflictObjectResult("A user with the same email address already exists.");

            try
            {
                var _userHash = _authService.GenerateHash(model.Password);

                _context.Users.Add(new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Hash = new UserHash
                    {
                        Salt = _userHash[0],
                        Password = _userHash[1]
                    }
                });
                await _context.SaveChangesAsync();

                return Created("", null);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message.ToString());
            }
        }

        #endregion

        #region SignIn

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var user = await _context.Users.Include(x => x.Hash).FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user == null)
                return new BadRequestObjectResult("Incorrect email address or password");

            if (_authService.ValidateHash(model.Password, user.Hash.Password, user.Hash.Salt))
            {
                var session = await _context.Sessions.FirstOrDefaultAsync(x => x.UserId == user.Id);

                if(session != null)
                {
                    _context.Sessions.Remove(session);
                    await _context.SaveChangesAsync();
                }

                var sessionToken = _authService.GenerateJwtToken(user.Id.ToString());
                _context.Sessions.Add(new UserSession { UserId = user.Id, SessionToken = sessionToken });
                await _context.SaveChangesAsync();

                return new OkObjectResult(sessionToken);
            }

            return new BadRequestObjectResult("Incorrect email address or password");
                
        }

        #endregion

        #region SignOut

        [HttpPost("SignOut")]
        [Authorize]
        public async Task<IActionResult> SignOut(string userId)
        {
            var user = await _context.Users.Include(x => x.Session).FirstOrDefaultAsync(x => x.Id == Guid.Parse(userId));

            if (user == null)
                return new BadRequestObjectResult("No user was found");

            try
            {
                var session = await _context.Sessions.FirstOrDefaultAsync(x => x.UserId == user.Id);

                if(session != null)
                {
                    _context.Sessions.Remove(session);
                    await _context.SaveChangesAsync();
                }

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message.ToString());
            }
        }

        #endregion
    }
}
