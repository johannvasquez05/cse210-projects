using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who have you helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your heroes?"
    };

    public ListingActivity() :
        base("Listing",
            "This activity helps you focus on the good things in your life.")
    { }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    public void Run()
    {
        IncrementActivityCount();

        DisplayStartingMessage();

        Console.WriteLine("\nList as many responses as you can to the prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> entries = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            entries.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {entries.Count} items.");

        DisplayEndingMessage();
    }
}