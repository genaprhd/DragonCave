namespace DragonCave;

public class Characters
{
    public string Name { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }
    public float Armor { get; set; }
    public const float Evasion = 0.17f;

    public Characters(string name, float health, float damage, float armor)
    {
        Name = name;
        Health = health;
        Damage = damage;
        Armor = armor;
    }

    public Characters()
    {
        
    }
}

public class Player : Characters
{
    public Player() 
    {
        
    }
    public Player(string name, float health, float damage, float armor) : base(name,
        health, damage, armor)
    {
        Name = name;
        Health = health;
        Damage = damage;
        Armor = armor;
    }

}
public class Dragon : Characters
{
    
    public Dragon()
    {
        
    }
    
    public bool isBot { get; } = true;

    public Dragon(string name, float health, float damage, float armor, bool isBot) : base(name, health, damage, armor)
    {
        
    }
}

public class Action
{
    public string action { get; set; }
}