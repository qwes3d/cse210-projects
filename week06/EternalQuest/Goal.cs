// Base class for all goals
abstract class Goal
{
    protected string name;
    protected string description;
    protected int points;

    public Goal(string name, string description, int points)
    {
        this.name = name;
        this.description = description;
        this.points = points;
    }

    public abstract int RecordEvent(); // Earn points
    public abstract bool IsComplete();
    public abstract string GetStatus(); // For display
    public abstract string Serialize(); // For saving/loading
}
