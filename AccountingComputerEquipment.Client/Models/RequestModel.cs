namespace AccountingComputerEquipment.Client.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OfficeEquipmentId { get; set; }
        public string Description { get; set; }

        public string OfficeEquipmentName { get; set; }
        public string OfficeEquipmentPhoto { get; set; }

        public string UserFullName { get; set; }
        public string UserJobTitle { get; set; }
        public string UserEmail { get; set; }
        public string UserTelephoneNumber { get; set; }
        public string UserAccessLevel { get; set; }
    }
}
