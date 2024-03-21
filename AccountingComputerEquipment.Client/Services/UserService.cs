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

        public static ObservableCollection<User> LoadEmployees()
        {
            using(IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<User>("select * from User where AccessLevelId > 1", new DynamicParameters());
                ObservableCollection<User> userCollection = new ObservableCollection<User>(output as List<User>);
                return userCollection;
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
