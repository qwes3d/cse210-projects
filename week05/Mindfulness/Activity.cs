using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

// Base class for all activities
abstract class Activity
{
    protected string Name;
    protected string Description;
    protected int Duration;

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"{Name} Activity");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine() ?? "30");
        Console.WriteLine("Get ready...");
        ShowAnimation(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        ShowAnimation(3);
    }

    protected void ShowAnimation(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void PerformActivity();
}
