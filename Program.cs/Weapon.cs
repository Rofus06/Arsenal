using System;

public class Weapon
{
    // Vapnets egenskaper
    public string Name { get; set; }
    public int DamageMin { get; set; }
    public int DamageMax { get; set; }

    // Konstruktor för att skapa ett nytt vapen
    public Weapon(string name, int damageMin, int damageMax)
    {
        Name = name;
        DamageMin = damageMin;
        DamageMax = damageMax;
    }

    // Metod för att attackera (slumpmässig skada mellan DamageMin och DamageMax)
    public int Attack()
    {
        Random random = new Random();
        return random.Next(DamageMin, DamageMax + 1); // Slumpmässig skada
    }
}
