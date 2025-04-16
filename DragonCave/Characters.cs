using Newtonsoft.Json;
namespace DragonCave;

public class Character
{
    public string Name { get; set; }
    public string CharRace { get; set; }
    public Stats Stats { get; set; }
    public CombatStats CombatStats { get; set; }
    public bool IsBot { get; set; }
    public Statuses Status { get; set; }
    public int Experience { get; set; }
    public Rarities Rarity { get; set; }
    private Character(CharacterBuilder builder)
    {
        if (string.IsNullOrWhiteSpace(builder.Name))
            throw new ArgumentException("Name cannot be null or empty");
        if (string.IsNullOrWhiteSpace(builder.CharRace))
            throw new ArgumentException("CharRace cannot be null or empty");
        if (builder.Stats == null)
            throw new ArgumentNullException(nameof(builder.Stats), "Stats cannot be null");
        if (builder.CombatStats == null)
            throw new ArgumentNullException(nameof(builder.CombatStats), "CombatStats cannot be null");
        Name = builder.Name;       
        CharRace = builder.CharRace;
        Stats = builder.Stats;
        CombatStats = builder.CombatStats;
        IsBot = builder.IsBot;
        Status = builder.Status;
        Experience = builder.Experience;
        Rarity = builder.Rarity;
    }
    public class CharacterBuilder
    {
        public string Name { get; set; }
        public string CharRace { get; set; }
        public Stats Stats { get; set; }
        public CombatStats CombatStats { get; set; }
        public bool IsBot { get; private set; }
        public Statuses Status { get; set; }
        public int Experience { get; set; }
        public Rarities Rarity { get; private set; }
        [JsonConstructor]
        public CharacterBuilder(string name, string charRace)
        {
            Name = name;
            CharRace = charRace;
            Status = Statuses.None;
            Stats = new Stats(0, 0, 0);
            CombatStats = new CombatStats(0, 0, 0, 0, 0);
            Rarity = Rarities.Common;
            Experience = 1;
            IsBot = false;
        }
        public CharacterBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public CharacterBuilder WithCharRace(string charRace)
        {
            CharRace = charRace;
            return this;
        }
        public CharacterBuilder WithStats(Stats stats)
        {
            Stats = stats;
            return this;
        }
        public CharacterBuilder WithCombatStats(CombatStats combatStats)
        {
            CombatStats = combatStats;
            return this;
        }
        public CharacterBuilder AsBot(bool isBot = true)
        {
            IsBot = isBot;
            return this;
        }
        public CharacterBuilder WithStatus(Statuses status)
        {
            Status = status;
            return this;
        }
        public CharacterBuilder WithExperience(int experience)
        {
            Experience = experience;
            return this;
        }
        public CharacterBuilder WithRarity(Rarities rarity)
        {
            Rarity = rarity;
            return this;
        }
        public Character Build()
        {
            return new Character(this);
        }
    }
}
public class Stats
{
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }
    public Stats( int strength, int agility, int intelligence)
    {
        Strength = strength;
        Agility = agility;
        Intelligence = intelligence;
    }
}
public class CombatStats
{
    public float Health { get; set; }
    public float Mana { get; set; }
    public float MinDamage { get; set; }
    public float MaxDamage { get; set; }
    public int Evasion { get; set; }
    
    public CombatStats( float health, float mana, float minDamage, float maxDamage, int evasion)
    {
        Health = health;
        Mana = mana;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        Evasion = evasion;
    }
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
    None,
    Blocked,
    Stunned,
    Poisoned,
    OnFire,
    Buffed
}

public enum Races
{
    Human,
    Goblin,
    Dragon,
    Troll,
    Cat,
    Wolf,
    Dog,
    Elf,
    Ork,
    Kitsune,
    Monkey
}
