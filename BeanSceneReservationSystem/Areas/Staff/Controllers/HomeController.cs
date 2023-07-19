using BeanSceneReservationSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeanSceneReservationSystem.Areas.Employee.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = "Staff,Manager")]
    public class HomeController : Controller
    {
        protected readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {


            return View();
        }
    }
}
