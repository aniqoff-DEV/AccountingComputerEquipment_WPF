using AccountingComputerEquipment.Client.Models;
using Dapper;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using System.Collections.ObjectModel;

namespace AccountingComputerEquipment.Client.Services
{
    public class OfficeEquipmentService
    {
        public static ObservableCollection<OfficeEquipment> LoadOfficeEquipments()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<OfficeEquipment>("select * from OfficeEquipment", new DynamicParameters());
                ObservableCollection<OfficeEquipment> officeEquipmentCollection = new ObservableCollection<OfficeEquipment>(output as List<OfficeEquipment>);
                return officeEquipmentCollection;
            }
        }

        public static ObservableCollection<OfficeEquipment> LoadCurrentOfficeEquipments(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<OfficeEquipment>("SELECT of.Id, of.Name, of.Photo, of.Cost, of.Description, of.AccessLevelId " +
                                                        "FROM OfficeEquipment of " +
                                                        "INNER JOIN OfficeEquipmentOfUser ofu ON ofu.OfficeEquipmentId = of.Id " +
                                                        "INNER JOIN User u ON u.Id = ofu.UserId " +
                                                        "WHERE u.Id = @userId " +
                                                        "ORDER BY of.Name", new {userId});
                ObservableCollection<OfficeEquipment> officeEquipmentCollection = new ObservableCollection<OfficeEquipment>(output as List<OfficeEquipment>);
                return officeEquipmentCollection;
            }
        }

        public static void CreateOfficeEquipment(OfficeEquipment officeEquipment)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO OfficeEquipment (Name, Photo, Cost, Description, AccessLevelId)" +
                            " VALUES (@Name, @Photo, @Cost, @Description, @AccessLevelId)",
                            officeEquipment);
            }
        }

        public static OfficeEquipment? GetOfficeEquipmentById(int officeEquipmentId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<OfficeEquipment>("select * from OfficeEquipment where Id = @officeEquipmentId"
                    , new { officeEquipmentId })
                    .FirstOrDefault();

                return output;
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
