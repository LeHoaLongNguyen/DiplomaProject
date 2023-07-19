using BeanSceneReservationSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace BeanSceneReservationSystem.Areas.Membership.Controllers
{
    [Area("Membership")]
    [Authorize(Roles = "Member,Staff,Manager")]
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _UserManager;

        public ReservationController(ApplicationDbContext context, UserManager<IdentityUser> UserManager)
        {
            _context = context;
            _UserManager = UserManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage()
        {

            //For Members to see past, future and current reservations
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u=> u.Id == userId);

            var reservations = _context.Reservations
            .Include(r => r.User)
            .Where(r => r.UserId == userId)
            .ToList();
                    
            return View(reservations);
        }
   

        public IActionResult Booking()
        {
            //When a member books a reservation it fills out of details of the current user logged in straight away
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservations = _context.Reservations
            .Include(r => r.User)
            .Where(r => r.UserId == userId)
            .ToList();

            return View(reservations);

            
        }

        public IActionResult Edit(int id)
        {
            var reservation = _context.Reservations.First(r => r.Id == id);
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Reservation r)
        {
            var reservation = _context.Reservations.First(m => r.Id == m.Id);

            reservation.FirstName = r.FirstName;
            reservation.LastName = r.LastName;
            reservation.Email = r.Email;
            reservation.StartTime = r.StartTime;
            reservation.Duration = r.Duration;
            reservation.EndTime = r.StartTime.AddMinutes(r.Duration);
            reservation.PhoneNumber = r.PhoneNumber;
            reservation.GuestNumber = r.GuestNumber;
            reservation.Note = r.Note;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Manage));
        }

    }
}
