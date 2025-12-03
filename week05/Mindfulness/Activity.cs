using System;
using System.Threading;
using System.Collections.Generic;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    private static Dictionary<string, int> _activityLog = new Dictionary<string, int>();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;

        if (!_activityLog.ContainsKey(_name))
        {
            _activityLog[_name] = 0;
        }
    }

    protected void IncrementActivityCount()
    {
        _activityLog[_name]++;
    }

    public static void DisplayActivityLog()
    {
        Console.WriteLine("\n=== Activity Usage Log ===");
        foreach (var entry in _activityLog)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} time(s)");
        }
        Console.WriteLine("==========================\n");
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long (in seconds) would you like for this activity? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nGreat job!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public int GetDuration()
    {
        return _duration;
    }
}