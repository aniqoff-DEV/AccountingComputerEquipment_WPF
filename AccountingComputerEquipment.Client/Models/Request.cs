namespace AccountingComputerEquipment.Client.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public int OfficeEquipmentId { get; set; }
    }
}
