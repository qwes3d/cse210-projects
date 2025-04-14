class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Add Goal\n2. Record Goal\n3. Show Goals\n4. Save\n5. Load\n6. Exit");
            Console.Write("Choose: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Choose goal type: 1) Simple 2) Eternal 3) Checklist");
                    string type = Console.ReadLine();

                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Description: ");
                    string desc = Console.ReadLine();
                    Console.Write("Points: ");
                    int pts = int.Parse(Console.ReadLine());

                    if (type == "1")
                        manager.AddGoal(new SimpleGoal(name, desc, pts));
                    else if (type == "2")
                        manager.AddGoal(new EternalGoal(name, desc, pts));
                    else if (type == "3")
                    {
                        Console.Write("Target Count: ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("Bonus: ");
                        int bonus = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, desc, pts, target, bonus));
                    }
                    break;

                case "2":
                    manager.ShowGoals();
                    Console.Write("Which goal to record? ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordGoal(index);
                    break;

                case "3":
                    manager.ShowGoals();
                    break;

                case "4":
                    Console.Write("Filename to save: ");
                    manager.SaveToFile(Console.ReadLine());
                    break;

                case "5":
                    Console.Write("Filename to load: ");
                    manager.LoadFromFile(Console.ReadLine());
                    break;

                case "6":
                    running = false;
                    break;
            }
        }
    }
}
