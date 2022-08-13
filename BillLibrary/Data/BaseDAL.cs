using System.Data.SqlClient;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BillLibrary.Data
{
    public class BaseDAL
    {
        public BillData billData { get; set; } = null;
        public SqlConnection connection = null;
        //--
        public BaseDAL()
        {
            var connectionString = GetConnectionString();
            billData = new BillData(connectionString);
        }
        //--
        public string GetConnectionString()
        {
            string connectionString;
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            connectionString = config["ConnectionString:BillManagementDB"];
            return connectionString;
        }
        public void CloseConnection()=>billData.CloseConnection(connection);
    }
}
