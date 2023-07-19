using Microsoft.AspNetCore.Identity;

namespace BeanSceneReservationSystem.Models
{
   
    public class UsersVM
    {
       
        public List<IdentityUser> Users { get; set; }
        public Dictionary<string, List<string>> UserRoles { get; set; }
        public List<IdentityRole> Roles { get; set; }
        

    }
}
