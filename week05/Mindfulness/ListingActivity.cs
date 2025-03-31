using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


// Listing Activity
class ListingActivity : Activity
{
    private readonly List<string> prompts = new() { "List things you appreciate.", "List people who inspire you." };

    public ListingActivity() : base("Listing", "This activity helps you recognize the good in your life.") { }

    public override void PerformActivity()
    {
        StartActivity();
        Random rand = new();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        ShowAnimation(5);
        List<string> responses = new();
        Console.WriteLine("Start listing:");
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            string? response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response)) responses.Add(response);
        }
        Console.WriteLine($"You listed {responses.Count} items.");
        EndActivity();
    }
}