using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DragonCave;

public class Character
{
    public string Name { get; set; }
    public string CharRace { get; set; }
    public Stats Stats { get; set; }
    public CombatStats CombatStats { get; set; }
    public bool IsBot { get; set; }
    public Statuses Statuses { get; set; }
    public int Experience { get; set; }
    public Rarities Rarity { get; set; }
    private Character(CharacterBuilder builder)
    {
        Name = builder.Name;       
        CharRace = builder.CharRace;
        Stats = builder.Stats;
        CombatStats = builder.CombatStats;
        IsBot = builder.IsBot;
        Statuses = builder.Statuses;
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
        public Statuses Statuses { get; set; }
        public int Experience { get; set; }
        public Rarities Rarity { get; private set; }
        public CharacterBuilder()
        {
            Name = "";
            CharRace = "";
            Statuses = Statuses.None;
            Stats = new Stats(0, 0, 0);
            CombatStats = new CombatStats(0, 0, 0, 0, 0, 0);
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
        public CharacterBuilder WithStatus(Statuses statuses)
        {
            Statuses = statuses;
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
        public override string ToString()
    {
        return $@"
Name:       {Name}
Race:       {CharRace}
Statuses:   {Statuses}
Experience: {Experience}
Rarity:     {Rarity}

Stats:      {Stats}        
Combat:     {CombatStats}   
";
    }
    [JsonConstructor]
    private Character(
        string name,
        string charRace,
        Stats stats,
        CombatStats combatStats,
        bool isBot,
        Statuses statuses,
        int experience,
        Rarities rarity)
    {
        Name        = name;
        CharRace    = charRace;
        Stats       = stats;
        CombatStats = combatStats;
        IsBot       = isBot;
        Statuses    = statuses;
        Experience  = experience;
        Rarity      = rarity;
    }
}
public class Stats
{
    public Stats(){}
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intellect { get; set; }
    public Stats( int strength, int agility, int intelligence)
    {
        Strength = strength;
        Agility = agility;
        Intellect = intelligence;
    }
    public override string ToString()
    {
        return $@"
Strength:    {Strength}
Agility:     {Agility}
Intellect:   {Intellect}
";
    }
}
public class CombatStats
{
    public CombatStats() { }
    public float Health { get; set; }
    public float Mana { get; set; }
    public float MinDamage { get; set; }
    public float MaxDamage { get; set; }
    public float Armor {get;set;}
    public int Evasion { get; set; }
    
    public CombatStats( float health, float mana, float minDamage, float maxDamage, float armor, int evasion)
    {
        Health = health;
        Mana = mana;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        Armor = armor;
        Evasion = evasion;
    }
    public override string ToString()
    {
        return $@"
Health:     {Health}
Mana:       {Mana}
MinDamage:  {MinDamage}
MaxDamage:  {MaxDamage}
Armor:      {Armor}
Evasion:    {Evasion}
";}
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
public enum PlayerRaces
{
    Human,
    Elf,
    Dwarf,
    Orc,
    Gnome,
    [Display(Name = "Half-Elf")]
    HalfElf,
    [Display(Name = "Half-Orc")]
    HalfOrc,
    Tiefling

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
