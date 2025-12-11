using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void Start()
    {
        int choice = -1;

        while (choice != 7)
        {
            DisplayPlayerInfo();

            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Choose: ");

            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalNames(); break;
                case 3: ListGoalDetails(); break;
                case 4: RecordEvent(); break;
                case 5: SaveGoals(); break;
                case 6: LoadGoals(); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYour Score: {_score} | Level: {_level}\n");
    }

    public void ListGoalNames()
    {
        int i = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetName()}");
            i++;
        }
    }

    public void ListGoalDetails()
    {
        int i = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            i++;
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose: ");

        int type = int.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
            _goals.Add(new SimpleGoal(name, desc, points));

        else if (type == 2)
            _goals.Add(new EternalGoal(name, desc, points));

        else if (type == 3)
        {
            Console.Write("Target: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 100) + 1;

        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"YOU LEVELED UP! You are now Level {_level}!");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.WriteLine();

        Console.Write("Select goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        Goal goal = _goals[index];
        bool wasComplete = goal.IsComplete();

        goal.RecordEvent();

        int earned = goal.GetPoints();
        _score += earned;

        if (goal is ChecklistGoal cl && cl.IsComplete() && !wasComplete)
        {
            string[] fields = cl.GetStringRepresentation().Split('|');
            int bonus = int.Parse(fields[4]);

            _score += bonus;

            Console.WriteLine(
                $"Congratulations! You earned {earned} points + BONUS {bonus} points! (Total: {earned + bonus})"
            );
        }
        else
        {
            Console.WriteLine($"Congratulations! You earned {earned} points!");
        }

        CheckLevelUp();
    }

    public void SaveGoals()
    {
        Console.Write("Name for the File: ");
        string file = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(file))
        {
            sw.WriteLine(_score);
            foreach (Goal goal in _goals)
                sw.WriteLine(goal.GetStringRepresentation());
        }

        Console.Write("File saved!!!");
    }

    public void LoadGoals()
    {
        _goals.Clear();

        Console.Write("Name of the File: ");
        string file = Console.ReadLine();

        string[] lines = File.ReadAllLines(file);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] p = lines[i].Split('|');

            if (p[0] == "SimpleGoal")
            {
                var goal = new SimpleGoal(p[1], p[2], int.Parse(p[3]));
                if (bool.Parse(p[4])) goal.RecordEvent();
                _goals.Add(goal);
            }
            else if (p[0] == "EternalGoal")
            {
                _goals.Add(new EternalGoal(p[1], p[2], int.Parse(p[3])));
            }
            else if (p[0] == "ChecklistGoal")
            {
                var goal = new ChecklistGoal(p[1], p[2], int.Parse(p[3]),
                                          int.Parse(p[5]), int.Parse(p[4]));

                for (int c = 0; c < int.Parse(p[6]); c++)
                    goal.RecordEvent();

                _goals.Add(goal);
            }
        }

        Console.Write("File and goals loaded!!!\n");
    }
}