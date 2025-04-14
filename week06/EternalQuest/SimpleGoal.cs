class SimpleGoal : Goal
{
    private bool completed;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        completed = false;
    }

    public override int RecordEvent()
    {
        if (!completed)
        {
            completed = true;
            return points;
        }
        return 0;
    }

    public override bool IsComplete() => completed;

    public override string GetStatus() => completed ? "[X]" : "[ ]";

    public override string Serialize() => $"Simple|{name}|{description}|{points}|{completed}";
}
