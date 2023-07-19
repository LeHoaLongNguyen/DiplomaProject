using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneReservationSystem.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int GuestNumber { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public DateTime EndTime { get; set; }
        public string? Note { get; set; }
        public int ReservationSourceId { get; set; }
        public ReservationSource? ReservationSource { get; set; }
        public int ReservationStatusId { get; set; }
        public ReservationStatus? ReservationStatus { get; set; }
        public int SittingId { get; set; }
        public Sitting? Sitting { get; set; }
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
        public List<ReservationTable>? ReservationTables { get; set; }
    }
}
