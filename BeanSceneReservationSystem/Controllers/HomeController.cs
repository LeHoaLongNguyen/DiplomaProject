using BeanSceneReservationSystem.Data;
using BeanSceneReservationSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BeanSceneReservationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _UserManager;




        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> UserManager)
        {
            _logger = logger;
            _context = context;
            _roleManager = roleManager;
            _UserManager = UserManager;


            //Manager user is Manager@test.com
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RedirectUser()
        {
            if (User.IsInRole("Manager"))
            {
                return RedirectToAction("Index", "Home", new { area = "Management" });
            }
            else if (User.IsInRole("Member"))
            {
                return RedirectToAction("Index","Reservation");
            }
            else if (User.IsInRole("Staff"))
            {
                return RedirectToAction("Index", "Home", new { area = "Staff" });
            }
            return RedirectToAction("Index","Home");
        }
    }
}