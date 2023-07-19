using BeanSceneReservationSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BeanSceneReservationSystem.Controllers.Api
{
    [Route("api/sittings")]
    [ApiController]
    public class SittingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SittingsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<List<Sitting>> GetAsync(DateTime? start, int days = 7)
        {
            start = start.HasValue ? start : DateTime.Now;
            var end = start.Value.AddDays(days); 
            DateTime dateNow = DateTime.Now;

            var sittings = await _context.Sittings
                 .Where(s =>  s.StartTime >= start && s.StartTime < end && s.Active == true)
                 .OrderBy(s => s.StartTime)
                 .Include(s => s.SittingType)
                 .ToListAsync();

            var reservations =  _context.Reservations.Where(r => r.ReservationStatus.Name != "Cancelled" && r.ReservationStatus.Name != "Altered").ToList();




            foreach(var sitting in sittings)
            {
                var matchingReservations = reservations.Where(r => r.SittingId == sitting.Id).ToList();
                sitting.Vacancies = matchingReservations.Sum(r => r.GuestNumber);
            }

            return sittings;
        }
        [HttpPost, Route("{id}")]
        public async Task<Reservation> PostBooking(int id, [FromBody] Reservation reservation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservationStatus = _context.ReservationStatus.First(rs => rs.Name == "Pending");
            var reservationSource = _context.ReservationSources.First(rs => rs.Name == "Online");
            var sitting = await _context.Sittings.Where(s => s.Id == id).FirstOrDefaultAsync();
            var hours = reservation.StartTime.TimeOfDay;
            var date = sitting.StartTime.Date;
            var sittingDateTime = date.Add(hours);

            reservation.StartTime = sittingDateTime;
            reservation.EndTime = reservation.StartTime.AddMinutes(reservation.Duration);
            reservation.ReservationSourceId = reservationSource.Id;
            reservation.ReservationStatusId =  reservationStatus.Id;
            reservation.SittingId = id;
            reservation.UserId = userId;

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
      


            return reservation;
        }
    }
}
