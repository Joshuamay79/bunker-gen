using System.Data.SQLite;

public class SQLiteService
{
    public string ConnectionString => "";

    static SQLiteConnection CreateConnection()
    {

        SQLiteConnection sqlite_conn;
        // Create a new database connection:
        sqlite_conn = new SQLiteConnection("Data Source=.\\resources\\bunkergen.db;Version=3;New=True;Compress=True;");         // Open the connection:
        try
        {
            sqlite_conn.Open();
        }
        catch (Exception ex)
        {

        }
        return sqlite_conn;
    }

    public static void Add(int lootType, string details)
    {
        var conn = CreateConnection();

        var sqlite_cmd = conn.CreateCommand();
        sqlite_cmd.CommandText = @"INSERT INTO GeneratedLoot (
                              LootType,
                              LootDetails
                          )
                          VALUES (
                              @lootType,
                              @lootDetails
                          );";

        sqlite_cmd.Parameters.AddWithValue("@lootType", lootType);
        sqlite_cmd.Parameters.AddWithValue("@lootDetails", details);
        sqlite_cmd.Prepare();

        sqlite_cmd.ExecuteNonQuery();
    }
}