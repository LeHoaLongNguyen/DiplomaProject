using BeanSceneReservationSystem.Areas.Staff.Models;
using BeanSceneReservationSystem.Data;
using BeanSceneReservationSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace BeanSceneReservationSystem.Areas.Staff.Controllers.Api
{
    [Route("api/[controller]")]
    [Area("Staff")]
    [Authorize(Roles = "Staff,Manager")]
    [ApiController]
    public class ReservationTablesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReservationTablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Reservation>> GetReservationsAsync()
        {
            DateTime date = DateTime.Now;

            var reservations = await _context.Reservations
                    .Include(a => a.ReservationTables)
                    .ThenInclude(b => b.RestaurantTable)
                    .Include(c=> c.Sitting)
                    .Where(r => r.StartTime.Date == date.AddDays(1).Date && r.ReservationStatusId != 6 && r.ReservationStatusId != 5) // Filter reservations for the specified date
                    .ToListAsync();

            return reservations;
        }

        [HttpGet]
        [Route("tables")]
        public async Task<object> AreaTables()
        {
            return await _context.Areas.Include(a => a.RestaurantTables).Select(a => new
            {
                Area = a.Name,
                AreaId = a.Id,
                Tables = a.RestaurantTables.Select(t => new
                {
                    t.Id,
                    t.Name,
                    t.PosX,
                    t.PosY

                })
            }).ToArrayAsync();
        }

        [HttpPost]
        public async Task<IActionResult> saveTable(ReservationTableAndAreaVM reservationTableAndAreaVM)
        {
            var area = new Area { Name = reservationTableAndAreaVM.AreaName };
            for (var i = 0; i < reservationTableAndAreaVM.TableAmount; i++)
            {
                area.RestaurantTables.Add(new RestaurantTable { Name = reservationTableAndAreaVM.AreaName + i });
            }
            await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
            return Ok(area);
        }

        [HttpPost]
        [Route("UpdateTablePosition")]
        public async Task<IActionResult> UpdateTablePosition(ReservationTablePositionVM rVM)
        {
            var table = _context.RestaurantTables.First(t => rVM.Id == t.Id);
            table.PosX = rVM.posX;
            table.PosY = rVM.posY;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("UpdateReservationTable")]
        public async Task<IActionResult> UpdateReservationTable(ReservationTableVM rt)
        {
            var reservation = _context.Reservations.Include(r=>r.ReservationTables).First(r => rt.ReservationId == r.Id);
            var table = _context.RestaurantTables.First(t=> rt.TableId == t.Id);
            var reservationStatus = _context.ReservationStatus.First(r => r.Name == "Confirmed");
            reservation.ReservationStatusId = reservationStatus.Id;
            ReservationTable reservationTable = new()
            {
                Reservation = reservation,
                RestaurantTable = table
            };

            reservation.ReservationTables.Add(reservationTable);

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("{id}")]
        public Reservation GetReservationDetails(int id)
        {
            var reservation = _context.Reservations
                .Include(a => a.ReservationTables)
                .ThenInclude(b => b.RestaurantTable)
                .Where(r => r.Id == id).First();

            return reservation;
        }
    }
}
