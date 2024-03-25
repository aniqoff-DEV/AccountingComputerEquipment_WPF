using AccountingComputerEquipment.Client.Models;
using Dapper;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace AccountingComputerEquipment.Client.Services
{
    public class UserService
    {
        public static User? GetUserByEmailAndPassword(string email, string password)
        {
            using (IDbConnection db = new SQLiteConnection(LoadConnectionString()))
            {
                return db.Query<User>("SELECT * FROM User WHERE Email = @email and Password = @password", new { email, password }).FirstOrDefault();
            }
        }

        public static User? GetUserById(int userId)
        {
            using (IDbConnection db = new SQLiteConnection(LoadConnectionString()))
            {
                return db.Query<User>("SELECT * FROM User WHERE Id = @userId", new { userId }).FirstOrDefault();
            }
        }

        public static ObservableCollection<User> LoadEmployees()
        {
            using(IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<User>("select * from User where AccessLevelId > 1", new DynamicParameters());
                ObservableCollection<User> userCollection = new ObservableCollection<User>(output as List<User>);
                return userCollection;
            }
        }

        public static void AddOfficeEquipment(int officeEquipmentId, int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO OfficeEquipmentOfUser (OfficeEquipmentId, UserId)" +
                            " VALUES (@officeEquipmentId, @userId)",
                            new { officeEquipmentId, userId });
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
