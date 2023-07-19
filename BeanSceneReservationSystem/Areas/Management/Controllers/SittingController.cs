using BeanSceneReservationSystem.Data;
using BeanSceneReservationSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BeanSceneReservationSystem.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Manager")]
    public class SittingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SittingController(ApplicationDbContext context) 
        {
            _context = context; 
        }


        [HttpGet]
        public IActionResult Create()
        {
            var m = new SittingCreateVM
            {
                Capacity = 50
            }; 
            return View(m);
        }
        [HttpPost]
        public IActionResult Create(SittingCreateVM m)
        {
            SittingType sittingType;

            if (!_context.SittingTypes.Any(s => s.Name == m.Name))
            {
                sittingType = new SittingType() { Name = m.Name };
                _context.SittingTypes.Add(sittingType);
                _context.SaveChanges();
            }
            else
            {
                sittingType = _context.SittingTypes.First(s => s.Name == m.Name);
            }

            if (m.RepeatNumber == 0)
            {
                var sitting = new Sitting()
                {
                    Name = m.Name,
                    StartTime = m.StartTime,
                    EndTime = m.EndTime,
                    Capacity = m.Capacity,
                    SittingTypeId = sittingType.Id,
                    RestaurantId = 1
                };
                _context.Add(sitting);
            }
            else
            {
                for (int i = 0; i < m.RepeatNumber; i++)
                {
                    var sitting = new Sitting()
                    {
                        Name = m.Name,
                        StartTime = m.StartTime.AddDays(i),
                        EndTime = m.EndTime.AddDays(i),
                        Capacity = m.Capacity,
                        SittingTypeId = sittingType.Id,
                        RestaurantId = 1
                    };
                    _context.Add(sitting);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Index()
        {
           
            var sitting = _context.Sittings
                 .Where(s => s.StartTime > DateTime.Now)
                 .OrderBy(s => s.StartTime)
                 .Include(s => s.SittingType)
                 .Include(r => r.Reservations)
                 .ToList();
            foreach(var s in sitting)
            {
                s.Vacancies = s.Capacity - _context.Reservations
                    .Where(r => s.Id == r.SittingId 
                    && r.ReservationStatus.Name != "Cancelled" 
                    && r.ReservationStatus.Name != "Altered")
                    .Sum(r => r.GuestNumber);
                var rsid = _context.Reservations.FirstOrDefault();

            }
            return View(sitting);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var getReservations = _context.Reservations
                           .Any(r => r.SittingId == id
                           && r.ReservationStatus.Name != "Cancelled"
                           && r.ReservationStatus.Name != "Altered");

            if (getReservations == true) 
            {
                return RedirectToAction("Warning",new {id = id});
            }

            else
            {
                var sitting = _context.Sittings
               .Include(st => st.SittingType)
               .First(s => s.Id == id);
                ViewBag.SittingId = id;

                var sitting2 = new SittingCreateVM()
                {
                    Name = sitting.SittingType.Name,
                    Capacity = sitting.Capacity,
                    StartTime = sitting.StartTime,
                    EndTime = sitting.EndTime,
                };
                return View(sitting2);
            }
        }

        [HttpPost]
        public IActionResult Edit(SittingCreateVM m, int id)
        {
            var sitting = _context.Sittings
           .Where(s => s.Id == id)
           .First();

            sitting.Name = m.Name;
            sitting.Capacity = m.Capacity;
            sitting.StartTime = m.StartTime;
            sitting.EndTime = m.EndTime;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]      
        public async Task<IActionResult> Delete(int id)
        {
            var getReservations = _context.Reservations
                                 .Any(r => r.SittingId == id
                                 && r.ReservationStatus.Name != "Cancelled"
                                 && r.ReservationStatus.Name != "Altered");

            if (getReservations == true)
            {
                return RedirectToAction("Warning",new { id = id });
            }
            else
            {
                var deleteSitting = await _context.Sittings.FirstOrDefaultAsync(s => s.Id == id);
                if (deleteSitting == null)
                {
                    return NotFound();
                }
                return View(deleteSitting);
            }
        }

        [HttpPost, ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteSittingConfirmed = await _context.Sittings.FirstOrDefaultAsync(s => s.Id == id);
            if (deleteSittingConfirmed == null)
            {
                return NotFound();
            }
            _context.Sittings.Remove(deleteSittingConfirmed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Warning(int Id)
        {

            var reservationcount = _context.Reservations
                .Where(r => r.SittingId == Id
                && r.ReservationStatus.Name != "Cancelled"
                && r.ReservationStatus.Name != "Altered")
                .Count();

            ViewBag.ReservationCount = reservationcount;
            ViewBag.SittingId = Id;

            return View();
        }

        [HttpPost, ActionName(nameof(Warning))]
        public async Task<IActionResult> UpdateReservationStatus(int id)
        {
            var reservations = _context.Reservations.Where(r => r.SittingId == id).ToList();

            foreach (var r in reservations)
            {
                r.ReservationStatusId = 6;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Sitting");
        }

        [HttpPost]
        public async Task<IActionResult> SetStatus(int sittingId,Boolean status)
        {
            var sitting = _context.Sittings.First(s => s.Id == sittingId);
            sitting.Active = status;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
