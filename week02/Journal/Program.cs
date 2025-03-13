using System;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();

            while (true)
            {
                // Menu
                Console.WriteLine("\n--- Journal Menu ---");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display journal");
                Console.WriteLine("3. Save journal to file");
                Console.WriteLine("4. Load journal from file");
                Console.WriteLine("5. Exit");
                Console.Write("Please select an option (1-5): ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("What is your response? ");
                    string response = Console.ReadLine();
                    journal.AddEntry(response);
                    Console.WriteLine("Entry added successfully.");
                }
                else if (choice == "2")
                {
                    journal.DisplayJournal();
                }
                else if (choice == "3")
                {
                    Console.Write("Enter the filename to save the journal: ");
                    string filename = Console.ReadLine();
                    journal.SaveToFile(filename);
                }
                else if (choice == "4")
                {
                    Console.Write("Enter the filename to load the journal from: ");
                    string filename = Console.ReadLine();
                    journal.LoadFromFile(filename);
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
    }
}
