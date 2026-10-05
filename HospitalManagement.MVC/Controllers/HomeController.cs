using HospitalManagement.MVC.Filters;
using HospitalManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HospitalManagement.MVC.Controllers
{
    [LoginAuthorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}










