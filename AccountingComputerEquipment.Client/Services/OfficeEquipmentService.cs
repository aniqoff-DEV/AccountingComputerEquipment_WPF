using AccountingComputerEquipment.Client.Models;
using Dapper;
using System.Configuration;
using System.Data.SQLite;
using System.Data;

namespace AccountingComputerEquipment.Client.Services
{
    public class OfficeEquipmentService
    {
        public static List<OfficeEquipment> LoadOfficeEquipments()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<OfficeEquipment>("select * from OfficeEquipment", new DynamicParameters());
                return output.ToList();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
