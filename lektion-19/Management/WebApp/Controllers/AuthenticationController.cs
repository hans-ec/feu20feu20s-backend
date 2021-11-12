using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace WebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync("https://localhost:7193/api/authentication/signin", model);
            HttpContext.Session.SetString("SessionToken", await response.Content.ReadAsStringAsync());

            return RedirectToAction("Index", "Users");
        }
    }
}
