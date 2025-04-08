namespace DragonCave;

public class Characters
{
    public string Name { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }
    public float Armor { get; set; }
    public const float Evasion = 0.17f;
}

public class Player : Characters
{
    public bool isStupid { get; set; }
}
public class Dragon : Characters
{
    public bool isBot { get; } = true;
}

public class Action
{
    public string action { get; set; }
}