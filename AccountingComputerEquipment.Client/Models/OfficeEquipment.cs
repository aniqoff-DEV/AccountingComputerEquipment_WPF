using System.ComponentModel.DataAnnotations;

namespace AccountingComputerEquipment.Client.Models
{
    public class OfficeEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public int AccessLevelId { get; set; }
    }
}
