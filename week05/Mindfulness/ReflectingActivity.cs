using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


// Reflection Activity
class ReflectionActivity : Activity
{
    private readonly List<string> prompts = new() { "Think of a time when you showed strength.", "Recall a moment of resilience." };
    private readonly List<string> questions = new() { "Why was this meaningful?", "How did it change you?" };

    public ReflectionActivity() : base("Reflection", "This activity helps you reflect on personal experiences.") { }

    public override void PerformActivity()
    {
        StartActivity();
        Random rand = new();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        ShowAnimation(5);
        foreach (var question in questions)
        {
            Console.WriteLine(question);
            ShowAnimation(5);
        }
        EndActivity();
    }
}
