class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int totalPoints = 0;

    public void AddGoal(Goal goal) => goals.Add(goal);

    public void RecordGoal(int index)
    {
        if (index >= 0 && index < goals.Count)
        {
            totalPoints += goals[index].RecordEvent();
        }
    }

    public void ShowGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].GetType().Name}: {goals[i].ToString()}");
        }
        Console.WriteLine($"Total Score: {totalPoints}");
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalPoints);
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            totalPoints = int.Parse(lines[0]);

            foreach (var line in lines.Skip(1))
            {
                string[] parts = line.Split('|');
                switch (parts[0])
                {
                    case "Simple":
                        var sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (bool.Parse(parts[4])) sg.RecordEvent();
                        goals.Add(sg);
                        break;
                    case "Eternal":
                        goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "Checklist":
                        var cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                                   int.Parse(parts[4]), int.Parse(parts[6]));
                        while (cg.IsComplete() == false && int.Parse(parts[5]) > 0)
                        {
                            cg.RecordEvent();
                            parts[5] = (int.Parse(parts[5]) - 1).ToString();
                        }
                        goals.Add(cg);
                        break;
                }
            }
        }
    }
}
