using System;
using System.IO;
using System.Text.Json;

class Program
{
    public class Weapon
    {
        public string Name { get; set; }
        public int DamageMin { get; set; }
        public int DamageMax { get; set; }

        public int Attack()
        {
            Random random = new Random();
            return random.Next(DamageMin, DamageMax + 1);
        }
    }

    static void Main(string[] args)
    {
        // Läs in JSON-filen och deserialisera till ett Weapon-objekt
        string jsonString = File.ReadAllText("weapon.json");
        Weapon myWeapon = JsonSerializer.Deserialize<Weapon>(jsonString);

        // Skriv ut vapnets information
        Console.WriteLine($"Weapon: {myWeapon.Name}");
        Console.WriteLine($"Damage Range: {myWeapon.DamageMin} - {myWeapon.DamageMax}");

        // Fråga användaren hur många attacker som ska utföras
        Console.WriteLine("How many attacks would you like to perform?");
        int numAttacks = int.Parse(Console.ReadLine());

        // Räkna ihop den totala skadan
        int totalDamage = 0;
        for (int i = 0; i < numAttacks; i++)
        {
            int damage = myWeapon.Attack();
            totalDamage += damage;
            Console.WriteLine($"Attack {i + 1}: {damage} damage.");
        }

        // Skriv ut den totala skadan
        Console.WriteLine($"Total damage dealt: {totalDamage}");

        // Håller konsolen öppen
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();
    }
}
