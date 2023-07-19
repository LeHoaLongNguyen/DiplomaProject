using BeanSceneReservationSystem.Data;
using BeanSceneReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeanSceneReservationSystem.Controllers
{
    public class ReservationController : Controller
    {
        

        private readonly ApplicationDbContext _context;

        public ReservationController( ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(); 
        }
    }
}
