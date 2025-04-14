class ChecklistGoal : Goal
{
    private int requiredCount;
    private int completedCount;
    private int bonus;

    public ChecklistGoal(string name, string description, int points, int requiredCount, int bonus)
        : base(name, description, points)
    {
        this.requiredCount = requiredCount;
        this.completedCount = 0;
        this.bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (completedCount < requiredCount)
        {
            completedCount++;
            int earned = points;
            if (completedCount == requiredCount)
                earned += bonus;
            return earned;
        }
        return 0;
    }

    public override bool IsComplete() => completedCount >= requiredCount;

    public override string GetStatus() => IsComplete() ? "[X]" : "[ ]" + $" Completed {completedCount}/{requiredCount}";

    public override string Serialize() => $"Checklist|{name}|{description}|{points}|{requiredCount}|{completedCount}|{bonus}";
}
