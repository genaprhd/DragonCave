using Microsoft.Data.Sqlite;

namespace DragonCave.DB;

public static class DatabaseInitializer
{
    public static void InitializeDatabase()
    {
        using var connection = new SqliteConnection("Data Source=Characters.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            @"
            CREATE TABLE IF NOT EXISTS Characters (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL UNIQUE,
                Health REAL NOT NULL,
                Damage REAL NOT NULL,
                Armor REAL NOT NULL,
                Evasion INTEGER NOT NULL,
                IsBot INTEGER NOT NULL,
                Status TEXT NOT NULL,
                Experience INTEGER NOT NULL,
                Mana INTEGER NOT NULL,
                Rarity STRING NOT NULL
            );
            ";
        command.ExecuteNonQuery();
    }
}
