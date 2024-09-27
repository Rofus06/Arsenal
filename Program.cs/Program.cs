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
        Weapon myWeapon = null;
        

        // Loop för att välja vapnet tills en giltig fil hittas
        while (myWeapon == null)
        {
            // Låt användaren välja vilken JSON-fil som ska laddas
            Console.WriteLine("Choose a weapon file (e.g., 'AK47.json' or 'LR300.json'):");
            string fileName = Console.ReadLine();
            

            // Kontrollera om filen finns
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not found! Please try again.");
                continue; // Låter användaren försöka igen
            }

            try
            {
                // Läs in JSON-filen och deserialisera till ett Weapon-objekt
                string jsonString = File.ReadAllText(fileName);
                myWeapon = JsonSerializer.Deserialize<Weapon>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading weapon: {ex.Message}");
                continue; // Om något går fel, försök igen
            }
        }

        // Skriv ut vapnets information
        Console.WriteLine($"Weapon: {myWeapon.Name}");
        Console.WriteLine($"Damage Range: {myWeapon.DamageMin} - {myWeapon.DamageMax}");

        // Fråga användaren hur många attacker som ska utföras
        int numAttacks = 0;
        while (numAttacks <= 0)
        {
            Console.WriteLine("How many attacks would you like to perform?");
            if (!int.TryParse(Console.ReadLine(), out numAttacks) || numAttacks <= 0)
            {
                Console.WriteLine("Please enter a valid number of attacks.");
            }
        }

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
