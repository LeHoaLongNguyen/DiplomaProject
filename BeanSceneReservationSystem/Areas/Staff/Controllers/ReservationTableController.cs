using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BeanSceneReservationSystem.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = "Staff,Manager")]
    public class ReservationTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
