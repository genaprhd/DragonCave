namespace DragonCave;
public class Character(
    string name,
    float health,
    float damage,
    float armor,
    int evasion,
    bool isBot,
    Statuses status,
    int experience,
    int mana,
    Rarities rarity)
{
    public string Name { get; set; } = name;
    public float Health { get; set; } = health;
    public float Damage { get; set; } = damage;
    public float Armor { get; set; } = armor;
    public int Evasion { get; set; } = evasion;
    public bool IsBot { get; set; } = isBot;
    public Statuses Status { get; set; } = status;
    public int Experience { get; set; } = experience;
    public int Mana { get; set; } = mana;
    public Rarities Rarity { get; } = rarity;
}

public enum Rarities
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}
public enum Actions
{
    Attack,
    Block
}
public enum Statuses
{
    Base,
    Blocked,
    Stunned,
    Poisoned,
    OnFire
}
