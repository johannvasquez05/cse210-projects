/*Added a list of scriptures to randomly display */
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        List<Scripture> library = new List<Scripture>()
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding."
            ),

            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."
            ),

            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."
            ),

            new Scripture(
                new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy."
            ),

            new Scripture(
                new Reference("Moroni", 7, 47),
                "Charity is the pure love of Christ, and it endureth forever."
            )
        };

        Random rnd = new Random();
        int index = rnd.Next(library.Count);
        Scripture scripture = library[index];

        while (!scripture.isCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press ENTER to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                return;

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("All words are now hidden.");

    }
}