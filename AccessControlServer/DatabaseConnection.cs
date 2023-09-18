namespace AccessControlServer;

public static class DatabaseConnection
{
    public static string SetupConnectionWithoutDatabase(string connectionString)
    {
        var connectionWithoutDb = "";
        if (!string.IsNullOrEmpty(connectionString))
        {
            var consWithoutDb = connectionString.Split(';').Where(c => !c.Contains("Database="))?.ToArray();
            if (consWithoutDb != null && consWithoutDb.Any())
            {
                connectionWithoutDb = string.Join(";", consWithoutDb);
            }
        }
        return connectionWithoutDb;
    }

    public static string ExtractDatabaseName(string connectionString)
    {
        var dbName = "";
        if (!string.IsNullOrEmpty(connectionString))
        {
            var database = connectionString.Split(';').Where(c => c.Contains("Database="))?.FirstOrDefault();
            var databaseName = database?.Split('=');
            if (databaseName != null && databaseName.Any())
            {
                dbName = databaseName[1];
            }
        }
        return dbName;
    }

    public static string CheckOrReplaceConnectionServerName(string connectionString)
    {
        var newConnectionStr = "";
        var serverName = Environment.MachineName;
        if (string.IsNullOrEmpty(connectionString)) return newConnectionStr;

        foreach (var conn in connectionString.Split(';'))
        {
            if (conn.Contains("Server=") && conn != serverName)
            {
                newConnectionStr = $"Server={serverName};";
                continue;
            }
            newConnectionStr += $"{conn};";
        }
        return newConnectionStr;
    }
}
