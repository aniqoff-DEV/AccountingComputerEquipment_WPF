namespace AccountingComputerEquipment.Client.Models
{
    public class RequestModel
    {
        public int Id { get; set; }

        public string OfficeEquipmentName { get; set; }
        public string OfficeEquipmentPhoto { get; set; }

        public string UserFullName { get; set; }
        public string UserJobTitle { get; set; }
        public string UserEmail { get; set; }
        public string UserTelephoneNumber { get; set; }
        public int UserAccessLevelId { get; set; }
    }
}
