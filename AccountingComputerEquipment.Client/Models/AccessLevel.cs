using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AccountingComputerEquipment.Client.Models
{
    public class AccessLevel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<User>? Users { get; set; }
    }
}
