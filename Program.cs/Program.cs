using System;
using System.IO;
using System.Text.Json;

class Program
{
    // Klass som representerar vapnet (endast inuti Program.cs)
    public class Weapon
    {
        public string Name { get; set; }
        public int DamageMin { get; set; }
        public int DamageMax { get; set; }

        // Metod för att attackera (slumpmässig skada mellan DamageMin och DamageMax)
        public int Attack()
        {
            Random random = new Random();
            return random.Next(DamageMin, DamageMax + 1); // Slumpmässig skada
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

        // Testa vapnet genom att göra en attack
        int damage = myWeapon.Attack();
        Console.WriteLine($"You attack with {myWeapon.Name} and deal {damage} damage.");

        // Håller konsolen öppen
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();
    }
}
