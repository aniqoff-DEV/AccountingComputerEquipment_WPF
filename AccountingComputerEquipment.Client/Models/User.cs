using System.ComponentModel.DataAnnotations;

namespace AccountingComputerEquipment.Client.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string Password { get; set; }

        public int AccessLevelId { get; set; }
    }
}
