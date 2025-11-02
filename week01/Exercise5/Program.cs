using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

        DisplayWelcomeMessage();
        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();

        int squareNumber = SquareNumber(favoriteNumber);

        DisplayResult(squareNumber, userName);

    }
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string username = Console.ReadLine();

        return username;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber = int.Parse(Console.ReadLine());

        return favoriteNumber;
    }

    static int SquareNumber(int number)
    {
        int SquareNumber = number * number;

        return SquareNumber;
    }

    static void DisplayResult(int squareNumber, string userName)
    {
        Console.WriteLine($"{userName}, the square of your number is {squareNumber}");
    }
}