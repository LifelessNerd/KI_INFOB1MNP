using System;

class Hallo2
{
    static void Main()
    {
        string naam;
        Console.WriteLine("Wat is je naam?");
        naam = Console.ReadLine();
        Console.WriteLine("Hallo, " + naam + "!");
        Console.WriteLine("Je naam heeft " + naam.Length + " letters." );
        Console.ReadLine();
    }
}