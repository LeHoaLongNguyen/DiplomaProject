using BeanSceneReservationSystem.Areas.Employee.Controllers;
using BeanSceneReservationSystem.Areas.Staff.Models;
using BeanSceneReservationSystem.Data;
using BeanSceneReservationSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace BeanSceneReservationSystem.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = "Staff,Manager")]
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Sitting()
        {
            //view all sittings within 7 days to book
            DateTime date = DateTime.Now.AddDays(7);
            DateTime dateNow = DateTime.Now;
            var sittings = _context.Sittings
                 .Where(s => s.StartTime <= date && s.StartTime > dateNow && s.Active == true)
                 .OrderBy(s => s.StartTime)
                 .Include(s => s.SittingType)
                 .ToList();

            return View(sittings);
        }

        [HttpGet]
     
        public IActionResult Booking(int Id)
        {
            //Booking action for the staff member to enter in details for the member
            var sittingId = Id;
            ViewBag.sittingId = sittingId;
            var sittingTimes = _context.Sittings.First(s => s.Id == Id);

            return View(sittingTimes);
        }
        [HttpPost]
        //[Route("Reservation/Sitting/{SittingId}/Booking")]
        public IActionResult Booking(string firstName, string lastName, string email, string phoneNumber, int guests, string notes, int duration, int sittingId, DateTime startTime)
        {
            //The post method for the booking action
            Reservation r = new Reservation()
            {
                FirstName = firstName,
                LastName = lastName,
                StartTime = startTime,
                Email = email,
                PhoneNumber = phoneNumber,
                GuestNumber = guests,
                Note = notes,
                Duration = duration,
                EndTime = startTime.AddMinutes(duration),
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            r.ReservationStatusId = 1;
            r.ReservationSourceId = 1;
            r.SittingId = sittingId;

            DateTime.Now.AddMinutes(duration);
            //TODO: add logic if pending
            _context.Reservations.Add(r);
            _context.SaveChanges();
            return RedirectToAction("BookingConfirmationPage", new { id = r.Id });
        }

        //[Route("Reservation/BookingConfirmationPage/{ReservationId}")]
        public IActionResult BookingConfirmationPage(int id)
        {
            //booking confirmation page for when the staff member creates the booking for the member who calls online
            var reservation = _context.Reservations
                .Include(r => r.Sitting)
                .First(r => r.Id == id);
            return View(reservation);
        }

        [HttpGet]
        public IActionResult GetReservations(UpdateReservationsViewModel m)
        {
            var reservationStatus = _context.ReservationStatus.ToList();
            var reservationSource = _context.ReservationSources.ToList();
            var updateReservations = _context.Reservations
                .Include(rs => rs.ReservationStatus)
                .Include(rsource => rsource.ReservationSource)
                //.Where(r => r.StartTime > DateTime.Now)
                .ToList();
            
            var model = new UpdateReservationsViewModel
            {
                Reservations = updateReservations,
                ReservationsSource = reservationSource,
                ReservationsStatus = reservationStatus

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservations(ReservationSourceAndStatusVM m)
        {
            var item = _context.Reservations.FirstOrDefault(a => a.Id == m.ReservationId);
            if(m.ReservationSourceId == 0)
            {
                m.ReservationSourceId = item.ReservationSourceId;
            }
            if(m.ReservationStatusId == 0)
            {
                m.ReservationStatusId = item.ReservationStatusId;
            }

            item.ReservationStatusId = m.ReservationStatusId;
            item.ReservationSourceId = m.ReservationSourceId;
            
            
            await _context.SaveChangesAsync();
            return RedirectToAction("GetReservations");
        }

        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(r=> r.Id == id);


               
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
            return RedirectToAction(nameof(GetReservations));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var reservation = _context.Reservations.First(r => r.Id == id);
         
            return View(reservation);
            
        }

        [HttpPost, ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);

             _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GetReservations));
        }

    }
}
