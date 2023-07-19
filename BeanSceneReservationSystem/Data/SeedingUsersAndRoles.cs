using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeanSceneReservationSystem.Data
{
    public class SeedingUsersAndRoles
    {
        public SeedingUsersAndRoles(ModelBuilder builder)
        {
            // Data seed roles
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    Name = "Manager",
                    NormalizedName = "MANAGER".ToUpper()
                });

            builder.Entity<IdentityRole>()
               .HasData(new IdentityRole
               {
                   Id = "60226d81-1906-41cb-8f00-44e34ee158cd",
                   Name = "Staff",
                   NormalizedName = "STAFF".ToUpper()
               });

            builder.Entity<IdentityRole>()
               .HasData(new IdentityRole
               {
                   Id = "e07d60fb-e2bd-4443-9759-8edc2c65ba17",
                   Name = "Member",
                   NormalizedName = "MEMBER".ToUpper()
               });

            //create hasher to hash password
            var hasher = new PasswordHasher<IdentityUser>();

            //data seed a Manager user
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "8e545865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "Tester",
                    NormalizedUserName = "Manager@test.com",
                    PasswordHash = hasher.HashPassword(null, "Manager@test.com"),
                    Email = "Manager@test.com",
                    NormalizedEmail = "MANAGER@TEST.COM",
                    EmailConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false
                });
            //data seed staff user
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "8e645865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "Staff@test.com",
                    NormalizedUserName = "Staff@test.com",
                    PasswordHash = hasher.HashPassword(null, "Staff@test.com"),
                    Email = "Staff@test.com",
                    NormalizedEmail = "STAFF@TEST.COM",
                    EmailConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false
                });

            //create relationship between user and role
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e545865-a24d-4543-a6c6-9443d048cdb9"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "60226d81-1906-41cb-8f00-44e34ee158cd",
                    UserId = "8e645865-a24d-4543-a6c6-9443d048cdb9"
                });

            string[] AccountEmailAndPasswords = { "a", "b", "c", "d", "e", "f", "g", "h", "i",
                "j", "k", "l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" 
            };

            string[] AccountUserNames = { "John", "Fred", "Sarah", "Lousie", "Katie", "Ben",
                "Lucas", "Liam","Emma","Kayla","Levi","Noah",
                "Oliver","Leo","Wyatt","Scarlett","Ella","Ellie"
                ,"Sofia","Sebastian","Violet","Jack","Owen","Daniel","Layla","Camila"
            };

            for (int i = 0; i < AccountEmailAndPasswords.Length; i++)
            {
                builder.Entity<IdentityUser>().HasData(
                   //seed 26 member users

                   new IdentityUser
                   {
                       Id= $"8l645865-{AccountEmailAndPasswords[i]}24d-4543-a6c6-9443d048cdb9",
                       UserName = $"{AccountUserNames[i]}",
                       NormalizedUserName = $"{AccountEmailAndPasswords[i]}@{AccountEmailAndPasswords[i]}.com".ToUpper(),
                       PasswordHash = hasher.HashPassword(null, $"{AccountEmailAndPasswords[i]}@{AccountEmailAndPasswords[i]}.com"),
                       Email = $"{AccountEmailAndPasswords[i]}@{AccountEmailAndPasswords[i]}.com",
                       NormalizedEmail = $"{AccountEmailAndPasswords[i]}@{AccountEmailAndPasswords[i]}.com".ToUpper(),
                       EmailConfirmed = true,
                       TwoFactorEnabled = false,
                       LockoutEnabled = false
                   });


                //create relationship between user and role
                builder.Entity<IdentityUserRole<string>>().HasData(
                   new IdentityUserRole<string>
                   {
                       RoleId = "e07d60fb-e2bd-4443-9759-8edc2c65ba17",
                       UserId = $"8l645865-{AccountEmailAndPasswords[i]}24d-4543-a6c6-9443d048cdb9"
                   });
            }
        }
    }
}
