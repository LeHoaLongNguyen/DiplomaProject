using BeanSceneReservationSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BeanSceneReservationSystem.Areas.Membership.Controllers
{
    [Area("Membership")]
    [Authorize(Roles = "Member,Staff,Manager")]
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
