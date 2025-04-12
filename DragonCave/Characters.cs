public class Character
{
    public string Name { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }
    public float Armor { get; set; }
    public int Evasion { get; set; }
    public bool IsBot { get; set; }
    public statuses Status { get; set; }
    public Character(string name, float health, float damage, float armor, int evasion, bool isBot, statuses status)
    {
        Name = name;
        Health = health;
        Damage = damage;
        Armor = armor;
        Evasion = evasion;
        IsBot = isBot;
        Status = status;
    }
}
public enum actions
{
    Attack,
    Block
}

public enum statuses
{
    Base,
    Blocked,
    Stunned,
    Poisoned,
    onFire
}
