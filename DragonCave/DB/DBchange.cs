using Microsoft.Data.Sqlite;

namespace DragonCave.DB;

public class DBchange
{
    private const string ConnectionString = "Data Source=Characters.db";

    public static void AddCharacterTemplate(Character character)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Characters (Name, Health, Damage, Armor, Evasion, IsBot, Status, Experience, Mana, Raritie)
            VALUES ($name, $health, $damage, $armor, $evasion, $isBot, $status, $experience, $mana, $raritie);
        ";

        command.Parameters.AddWithValue("$name", character.Name);
        command.Parameters.AddWithValue("$health", character.Health);
        command.Parameters.AddWithValue("$damage", character.Damage);
        command.Parameters.AddWithValue("$armor", character.Armor);
        command.Parameters.AddWithValue("$evasion", character.Evasion);
        command.Parameters.AddWithValue("$isBot", character.IsBot ? 1 : 0);
        command.Parameters.AddWithValue("$status", character.Status.ToString());
        command.Parameters.AddWithValue("$experience", character.Experience);
        command.Parameters.AddWithValue("$mana", character.Mana);
        command.Parameters.AddWithValue("$raritie", character.Rarity);

        command.ExecuteNonQuery();
    }

    public static Character GetCharacterTemplate(string name)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT Name, Health, Damage, Armor, Evasion, IsBot, Status, Experience, Mana, Rarity
            FROM Characters
            WHERE Name = $name;
        ";

        command.Parameters.AddWithValue("$name", name);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Character(
                reader.GetString(0),
                reader.GetFloat(1),
                reader.GetFloat(2),
                reader.GetFloat(3),
                reader.GetInt32(4),
                reader.GetInt32(5) == 1,
                Enum.Parse<Statuses>(reader.GetString(6)),
                reader.GetInt32(7),
                reader.GetInt32(8),
                Enum.Parse<Rarities>(reader.GetString(9))
            );
        }

        return null;
    }
}
