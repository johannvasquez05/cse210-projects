using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() :
        base("Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly.")
    { }

    public void Run() 
    {
        IncrementActivityCount();

        DisplayStartingMessage();

        int time = GetDuration();
        int elapsed = 0;

        while (elapsed < time)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);
            elapsed += 4;

            if (elapsed >= time) break;

            Console.Write("\nBreathe out... ");
            ShowCountDown(4);
            elapsed += 4;
        }

        DisplayEndingMessage();
    }
}