using System;
using System.Threading;

// Breathing Activity
class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity helps you relax by guiding deep breathing.") { }

    public override void PerformActivity()
    {
        StartActivity();

        if (Duration < 3)
        {
            Console.WriteLine("Duration is too short for this activity. Please choose at least 3 seconds.");
            return;
        }

        Console.WriteLine("\nGet ready to begin...\n");
        Thread.Sleep(1000);

        int remainingTime = Duration;
        while (remainingTime > 0)
        {
            Console.WriteLine("Breathe in...");
            ShowAnimation(Math.Min(3, remainingTime));
            remainingTime -= 3;

            if (remainingTime <= 0) break;

            Console.WriteLine("Breathe out...");
            ShowAnimation(Math.Min(3, remainingTime));
            remainingTime -= 3;
        }

        EndActivity();
    }
}
