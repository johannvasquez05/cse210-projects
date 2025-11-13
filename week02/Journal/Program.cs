/*I added a constructor using the Week 3 activity and included a question to ask about the person’s mood.*/
using System;

class Program
{
    static void Main(string[] args)
    {
        Jounal journal = new Jounal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine("\n");

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Console.Write("How do you feel today? ");
                string mood = Console.ReadLine();

                DateTime theCurrentTime = DateTime.Now;
                string date = theCurrentTime.ToShortDateString();

                Entry entry = new Entry(date, prompt, response, mood);
                journal.AddEntry(entry);
                Console.WriteLine("\n");
            }

            else if (choice == "2")
            {
                Console.WriteLine("Displaying the Journal...");
                journal.DisplayAll();
            }

            else if (choice == "3")
            {
                Console.Write("Enter filename to save: ");
                string saveFile = Console.ReadLine();
                journal.SaveToFile(saveFile);
                Console.WriteLine("\n");
            }

            else if (choice == "4")
            {
                Console.Write("Enter filename to load: ");
                string loadFile = Console.ReadLine();
                journal.LoadFromFile(loadFile);
                Console.WriteLine("\n");
            }

            else if (choice == "5")
            {
                running = false;
                break;
            }

            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }
}