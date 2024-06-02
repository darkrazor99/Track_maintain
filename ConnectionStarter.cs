namespace TrackMaintain;

using System;
using System.Data.SQLite;
using System.IO;
using Xceed.Words.NET;


public class ConnectionStarter
{
    private static string connectionString = "Data Source=mydatabase.db;Version=3;";
    public ConnectionStarter(){
        if (!File.Exists("mydatabase.db")){
            CreateTables();
        }
    }
    public static SQLiteConnection GetConnection(){
        return new SQLiteConnection(connectionString);
    }

    private void CreateTables()
    {
        // edit this to create all my stuff.
        string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Customers (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Address TEXT NOT NULL,
                Model TEXT,
                LastMaintenanceDate TEXT,
                MaintenanceComment TEXT
            );
        ";

        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

}
