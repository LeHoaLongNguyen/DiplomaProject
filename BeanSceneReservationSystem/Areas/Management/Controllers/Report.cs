using BeanSceneReservationSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BeanSceneReservationSystem.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Manager")]
    public class Report : Controller
    {
        protected readonly ApplicationDbContext _context;
        public Report(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var reservations = _context.Reservations
                .Include(r=> r.ReservationStatus)
                .Include(r=> r.ReservationSource)
                .ToList();

            return View(reservations);
        }
    }
}
