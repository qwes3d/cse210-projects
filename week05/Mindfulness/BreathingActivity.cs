

// Breathing Activity
class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity helps you relax by guiding deep breathing.") { }

    public override void PerformActivity()
    {
        StartActivity();
        for (int i = 0; i < Duration; i += 6)
        {
            Console.WriteLine("Breathe in...");
            ShowAnimation(3);
            Console.WriteLine("Breathe out...");
            ShowAnimation(3);
        }
        EndActivity();
    }
}
