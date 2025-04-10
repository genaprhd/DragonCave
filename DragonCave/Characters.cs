public class Character
{
public string Name { get; set; }
public float Health { get; set; }
public float Damage { get; set; }
public float Armor { get; set; }
public int Evasion { get; }

    public Character(string name, float health, float damage, float armor, int evasion)
    {
        Name = name; 
        Health = health;
        Damage = damage;
        Armor = armor;
        Evasion = evasion;
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
        health, damage, armor, 17)
    {

    }

}
class Dragon : Character
{
    
    public Dragon()
    {
        
    }
    
    protected bool isBot { get; } = true;

    public Dragon(string name, float health, float damage, float armor, bool isBot) : base(name, health, damage, armor, evasion: 17)
    {
        
    }
}

public enum actions
{
    Attack,
    Block,
    Missed
}
