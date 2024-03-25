using AccountingComputerEquipment.Client.Models;
using Dapper;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SQLite;
using System.Data;

namespace AccountingComputerEquipment.Client.Services
{
    public class AccessLevelService
    {
        public static ObservableCollection<AccessLevel> LoadAccessLevels()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AccessLevel>("select * from AccessLevel", new DynamicParameters());
                ObservableCollection<AccessLevel> levelAccessCollection = new ObservableCollection<AccessLevel>(output as List<AccessLevel>);
                return levelAccessCollection;
            }
        }

        public static AccessLevel? GetById(int accessLevelId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<AccessLevel>("select * from AccessLevel WHERE Id = @accessLevelId", new { accessLevelId })
                    .FirstOrDefault();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
