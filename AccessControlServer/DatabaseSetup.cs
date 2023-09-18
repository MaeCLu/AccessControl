using AccessControlServer.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AccessControlServer;

public class DatabaseSetup
{
    private IConfiguration? m_config;

    private string ConnectionString { get; set; } = "";
    private string DatabaseName { get; set; } = "";

    public DatabaseSetup(IConfiguration config)
    {
        m_config = config;
        ConnectionString = m_config?.GetConnectionString("AccessControlConnection") ?? "";
        if (!string.IsNullOrEmpty(ConnectionString))
        {
            // Reconstruct the connectionString using the sqlserver server name
            ConnectionString = DatabaseConnection.CheckOrReplaceConnectionServerName(ConnectionString);
            if (!string.IsNullOrWhiteSpace(ConnectionString))
            {
                DatabaseName = DatabaseConnection.ExtractDatabaseName(ConnectionString);
                SetupDatabaseAndTables();
            }
        }
    }

    private void SetupDatabaseAndTables()
    {
        string connectionWithoutDb = DatabaseConnection.SetupConnectionWithoutDatabase(ConnectionString);
        if (!string.IsNullOrWhiteSpace(connectionWithoutDb))
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var files = assembly.GetManifestResourceNames()
                                         .Where(name => name != null && name.StartsWith("AccessControlServer.Scripts.Migration__")
                                                && name.EndsWith(".sql"))
                                         .OrderBy(name => name)
                                         .ToList();

            foreach (string fileName in files)
            {
                if (fileName.Contains("_CreateDatabase"))
                {
                    // Check if database exist
                    var exist = IsDatabaseExist(connectionWithoutDb);
                    if (exist) continue;
                }

                using var stream = assembly.GetManifestResourceStream(fileName);
                if (stream == null) continue;
                using StreamReader reader = new(stream);
                string sqlContent = reader.ReadToEnd();
                RunDatabaseSetupScript(sqlContent, connectionWithoutDb);
            }
        };
    }

    private bool IsDatabaseExist(string connectionString)
    {
        using var connection = new SqlConnection(connectionString);
        using var command = connection.CreateCommand();
        try
        {
            connection.Open();
            //check db if exist
            var sqlDbCheck = $@"SELECT COUNT(*) FROM sysdatabases where name = '{DatabaseName}'";
            command.CommandText = sqlDbCheck;
            var exists = command.ExecuteScalar();
            return (int)exists > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Database check failed", ex);
        }
    }

    private void RunDatabaseSetupScript(string scriptContent, string connectionString)
    {
        using var connection = new SqlConnection(connectionString);

        // split script on GO command
        IEnumerable<string> commandStrings = Regex.Split(scriptContent, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        try
        {
            connection.Open();
            foreach (string commandString in commandStrings)
            {
                if (!string.IsNullOrWhiteSpace(commandString.Trim()))
                {
                    using var command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandString;
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Database setup failed", ex);
        }
    }
}
