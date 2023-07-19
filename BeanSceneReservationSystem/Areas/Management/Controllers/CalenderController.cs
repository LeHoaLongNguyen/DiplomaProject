using BeanSceneReservationSystem.Data;
using BeanSceneReservationSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Data;

namespace BeanSceneReservationSystem.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Manager")]
    public class CalenderController : Controller
    {
        protected readonly ApplicationDbContext _context;
        public CalenderController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var sittings = _context.Sittings.ToList();
            var sittingEvents = sittings.Select(sitting => new SittingEventVM
            {
                Title = sitting.Name,
                Start = sitting.StartTime,
                End = sitting.EndTime
            }).ToList();

            return View(sittingEvents);
        }
        

        public async Task<JsonResult> Get(/*DateTime? start,int days = 7*/)
        {
            //start = start.HasValue ? start.Value : DateTime.Now;
            //var end = start.Value.AddDays(days);
            var sittings = _context.Sittings.ToList();
            var sittingEvents = sittings.Select(sitting => new SittingEventVM
            {
                Title = sitting.Name,
                Start = sitting.StartTime,
                End = sitting.EndTime
            }).ToList();

            return new JsonResult(sittingEvents);
        }

        //public JsonResult GetSittings()
        //{
          
        //    return new JsonResult(sittingEvents);
        //}


    }
}
