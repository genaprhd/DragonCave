namespace DragonCave;

public class Character
{
public string Name { get; set; }
public float Health { get; set; }
public float Damage { get; set; }
public float Armor { get; set; }
public const int Evasion = 17;

    public Character(string name, float health, float damage, float armor)
    {
        Name = name; 
        Health = health;
        Damage = damage;
        Armor = armor;
    }

    public Character()
    {
        
    }
}

class Player : Character
{
    public Player() 
    {
        
    }
    public Player(string name, float health, float damage, float armor) : base(name,
        health, damage, armor)
    {

    }

}
class Dragon : Character
{
    
    public Dragon()
    {
        
    }
    
    protected bool isBot { get; } = true;

    public Dragon(string name, float health, float damage, float armor, bool isBot) : base(name, health, damage, armor)
    {
        
    }
}

public class Action
{
    public string action { get; set; }
}