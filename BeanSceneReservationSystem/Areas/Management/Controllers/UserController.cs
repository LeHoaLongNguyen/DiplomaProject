using BeanSceneReservationSystem.Data;
using BeanSceneReservationSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace BeanSceneReservationSystem.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Manager")]
    public class UserController : Controller
    {
        protected readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRoles = new Dictionary<string, List<string>>();

            foreach (var user in users)
            {

                var roles = await _userManager.GetRolesAsync(user);
                userRoles[user.Id] = roles.ToList();
            }
            var model = new UsersVM
            {
                Users = users,
                UserRoles = userRoles,
                Roles = _roleManager.Roles.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string role, string userEmail)
        {
            var user = _context.Users.First(u => u.Email == userEmail);
            var userrole = await _userManager.GetRolesAsync(user);

            var isInRoleTask = await _userManager.IsInRoleAsync(user, role);
            var listOfRoles = new string[] { "Manager", "Staff", "Member" };

            if (!isInRoleTask)
            {
                foreach(var roleTest in listOfRoles)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleTest);
                }

                await _userManager.AddToRoleAsync(user, role);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
