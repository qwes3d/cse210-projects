using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

// Program Entry
class Program
{
    static void Main()
    {
        {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
    }
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing\n2. Reflection\n3. Listing\n4. Exit");
            string choice = Console.ReadLine() ?? "4";
            Activity? activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                _ => null
            };
            
            if (activity == null) break;
            activity.PerformActivity();
        }
    }
}
