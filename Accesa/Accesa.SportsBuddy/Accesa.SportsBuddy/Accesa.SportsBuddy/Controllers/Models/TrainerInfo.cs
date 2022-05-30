using Accesa.SportsBuddy.DTO;
using System;

namespace Accesa.SportsBuddy.Controllers.Models
{
    public class TrainerInfo
    {
        public int TrainerId { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AddressDTO AddressNavigation { get; set; }
        public DateTime CreatedAt { get; set; }
        public RoleDTO Role { get; set; }
        public bool? IsAvailable { get; set; }
        public decimal? Rating { get; set; }
    }
}
