using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("SessionToken"));

            return View(await client.GetFromJsonAsync<IEnumerable<UserModel>>("https://localhost:7193/api/users"));
        }
    }
}
