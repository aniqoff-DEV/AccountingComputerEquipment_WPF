using AccountingComputerEquipment.Client.Models;
using Dapper;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace AccountingComputerEquipment.Client.Services
{
    public class RequestService
    {
        public static void CreateOfficeEquipment(Request request)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Request (UserId, OfficeEquipmentId, Description)" +
                            " VALUES (@UserId, @OfficeEquipmentId, @Description)",
                            request);
            }
        }
        public static ObservableCollection<RequestModel> LoadRequestModels()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<RequestModel>(
                    "SELECT r.Id, r.UserId, r.OfficeEquipmentId, r.Description, oe.Name[OfficeEquipmentName], oe.Photo[OfficeEquipmentPhoto]," +
                    " u.FullName[UserFullName], u.JobTitle[UserJobTitle], u.Email[UserEmail], " +
                    "u.TelephoneNumber[UserTelephoneNumber], al.Name[UserAccessLevel] " +
                    "FROM Request r " +
                    "INNER JOIN OfficeEquipment oe ON oe.Id = r.OfficeEquipmentId " +
                    "INNER JOIN User u ON u.Id = r.UserId " +
                    "INNER JOIN AccessLevel al ON al.Id = u.AccessLevelId " +
                    "ORDER BY r.Id", new DynamicParameters());

                ObservableCollection<RequestModel> requestModelCollection = new ObservableCollection<RequestModel>(output as List<RequestModel>);
                return requestModelCollection;
            }
        }

        public static void Delete(int requestId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var sqlQuery = "DELETE FROM Request WHERE Id = @requestId";
                cnn.Execute(sqlQuery, new { requestId });
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
