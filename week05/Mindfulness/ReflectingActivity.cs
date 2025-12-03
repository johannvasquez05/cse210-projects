using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity() :
        base("Reflection",
            "This activity will help you reflect on times when you've shown strength and resilience.")
    { }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        return _questions[random.Next(_questions.Count)];
    }

    public void Run()
    {
        IncrementActivityCount();

        DisplayStartingMessage();

        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine("\nPress ENTER when ready...");
        Console.ReadLine();

        Console.WriteLine("\nNow reflect on the following questions:\n");

        int time = GetDuration();
        int elapsed = 0;

        while (elapsed < time)
        {
            Console.WriteLine($"> {GetRandomQuestion()}");
            ShowSpinner(4);
            elapsed += 4;
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}