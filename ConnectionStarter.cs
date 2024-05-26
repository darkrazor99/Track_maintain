namespace TrackMaintain;

using System.Data.SQLite;
using System.IO;


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
            CREATE TABLE IF NOT EXISTS Books (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT NOT NULL,
                Author TEXT NOT NULL,
                PublicationYear INTEGER
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
