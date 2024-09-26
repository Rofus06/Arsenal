using System;

class Program
{
    static void Main(string[] args)
    {
        // Skapa ett nytt vapen
        Weapon myWeapon = new Weapon("Sword", 5, 10);

        // Testa vapnet genom att göra en attack
        int damage = myWeapon.Attack();
        Console.WriteLine($"You attack with {myWeapon.Name} and deal {damage} damage.");
    }
}
