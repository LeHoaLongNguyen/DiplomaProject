using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeanSceneReservationSystem.Data
{
    public class SeedingRestaurantData
    {
        public SeedingRestaurantData(ModelBuilder builder)
        {
            //data seeding sittings/areas/sittingtypes/reservationsources/reservationstatus and Restaurant
            builder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    Id = 1,
                    Name = "Bean Scene"
                });

            builder.Entity<SittingType>().HasData(
            new SittingType
            {
                Id = 1,
                Name = "Breakfast"
            },
            new SittingType
            {
                Id = 2,
                Name = "Lunch"
            },
            new SittingType
            {
                Id = 3,
                Name = "Dinner"
            });

            builder.Entity<Area>().HasData(
            new Area
            {
                Id = 1,
                Name = "Main",


            },
            new Area
            {
                Id = 2,
                Name = "Outside"
            },
            new Area
            {
                Id = 3,
                Name = "Balcony"
            });

            for (int i = 1; i <= 10; i++)
            {

                builder.Entity<RestaurantTable>().HasData(
                    new RestaurantTable
                    {
                        Id = i,
                        Name = "M" + i,
                        AreaID = 1
                    });
            }



            for (int i = 1; i <= 10; i++)
            {
                builder.Entity<RestaurantTable>().HasData(
                    new RestaurantTable
                    {
                        Id = 10 + i,
                        Name = "O" + i,
                        AreaID = 2
                    });
            }
            for (int i = 1; i <= 10; i++)
            {
                builder.Entity<RestaurantTable>().HasData(
                    new RestaurantTable
                    {
                        Id = 20 + i,
                        Name = "B" + i,
                        AreaID = 3
                    });
            }





            builder.Entity<ReservationStatus>().HasData(
            new ReservationStatus
            {
                Id = 1,
                Name = "Pending"
            },
            new ReservationStatus
            {
                Id = 2,
                Name = "Confirmed"
            },
            new ReservationStatus
            {
                Id = 3,
                Name = "Seated"
            },
            new ReservationStatus
            {
                Id = 4,
                Name = "Completed"
            },
            new ReservationStatus
            {
                Id = 5,
                Name = "Cancelled"
            },
            new ReservationStatus
            {
                Id = 6,
                Name = "Altered"
            });

            builder.Entity<ReservationSource>().HasData(
            new ReservationSource
            {
                Id = 1,
                Name = "Online"
            },
            new ReservationSource
            {
                Id = 2,
                Name = "Email"
            },
            new ReservationSource
            {
                Id = 3,
                Name = "In Person"
            },
            new ReservationSource
            {
                Id = 4,
                Name = "Phone"
            });

            var idCount = 1;
            for (int i = 1; i <= 30; i++)
            {
                builder.Entity<Sitting>().HasData(
                new Sitting
                {
                    Id = idCount++,
                    StartTime = DateTime.Now.Date.AddDays(i).AddHours(7),
                    EndTime = DateTime.Now.Date.AddDays(i).AddHours(11),
                    Name = "Breakfast",
                    SittingTypeId = 1,
                    RestaurantId = 1,
                    Capacity = 30
                });
                builder.Entity<Sitting>().HasData(
                new Sitting
                {
                    Id = idCount++,
                    StartTime = DateTime.Now.Date.AddDays(i).AddHours(12),
                    EndTime = DateTime.Now.Date.AddDays(i).AddHours(16),
                    Name = "Lunch",
                    SittingTypeId = 2,
                    RestaurantId = 1,
                    Capacity = 40
                });
                builder.Entity<Sitting>().HasData(
                new Sitting
                {
                    Id = idCount++,
                    StartTime = DateTime.Now.Date.AddDays(i).AddHours(17),
                    EndTime = DateTime.Now.Date.AddDays(i).AddHours(21),
                    Name = "Dinner",
                    SittingTypeId = 3,
                    RestaurantId = 1,
                    Capacity = 50
                });
            }
            var random = new Random();
            var reservationCount = 100;

            var sittingIds = Enumerable.Range(1, 90).ToList(); // Assuming you have 90 sittings

            for (int i = 1; i <= reservationCount; i++)
            {
                var randomSittingId = sittingIds[random.Next(sittingIds.Count)];

                builder.Entity<Reservation>().HasData(
                    new Reservation
                    {
                        Id = i,
                        SittingId = randomSittingId,
                        FirstName  = "Joshua",
                        LastName = "Davis",
                        Email = "joshua.davis1@studytafensw.edu.au",
                        PhoneNumber = "0400213214",
                        StartTime = DateTime.Now.AddMinutes(i * 10),
                        Duration = 60,
                        EndTime = DateTime.Now.AddMinutes(i * 10).AddMinutes(60),
                        GuestNumber = random.Next(1, 6),
                        ReservationStatusId = random.Next(1, 7), // Assuming you have 6 reservation statuses
                        ReservationSourceId = random.Next(1, 5) // Assuming you have 4 reservation sources
                    });
            }
        }
    }
}
