using System.ComponentModel.DataAnnotations;

namespace AccountingComputerEquipment.Client.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string JobTitle { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string TelephoneNumber { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        public int AccessLevelId { get; set; }
        public AccessLevel? AccessLevel { get; set; }

        public List<OfficeEquipment> OfficeEquipment { get; set; } = new();
    }
}
