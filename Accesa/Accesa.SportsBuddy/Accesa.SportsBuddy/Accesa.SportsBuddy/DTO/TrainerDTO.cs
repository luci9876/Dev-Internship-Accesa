using System;

namespace Accesa.SportsBuddy.DTO
{
    public class TrainerDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime UserBirthDate { get; set; }
        public string UserGender { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public AddressDTO UserAddressNavigation { get; set; }
        public DateTime UserCreatedAt { get; set; }
        public RoleDTO UserRole { get; set; }
        public bool? IsAvailable { get; set; }
        public decimal? Rating { get; set; }
    }
}
