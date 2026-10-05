using HospitalManagement.MVC.Models;
using HospitalManagement.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApiService _apiService;

        public LoginController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]

        public IActionResult LoginPro()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> LoginPro(string username, string password)
        {
            LoginResponse? loginResponse = await _apiService.LoginAsync(username, password);

            if (loginResponse != null)
            {
                HttpContext.Session.SetString("IsloggedIn", "true");

                HttpContext.Session.SetString("Username", loginResponse.Username);

                HttpContext.Session.SetString("FullName", loginResponse.FullName);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid Username or Password";

            return View();
        }

        [HttpGet]

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("LoginPro", "Login");
        }

    }
}
