using System.ComponentModel.DataAnnotations;

namespace AccountingComputerEquipment.Client.Models
{
    public class OfficeEquipment
    {
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Photo { get; set; } = string.Empty;
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int AccessLevelNumber { get; set; }

        public List<User> Users { get; set; } = new();
    }
}
