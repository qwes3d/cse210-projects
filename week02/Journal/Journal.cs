using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Journal
    {
        private List<JournalEntry> entries;
        private List<string> prompts;

        // Constructor to initialize the journal and prompt list
        public Journal()
        {
            entries = new List<JournalEntry>();
            prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };
        }

        // Method to add a new entry to the journal
        public void AddEntry(string response)
        {
            string prompt = prompts[new Random().Next(prompts.Count)];
            DateTime date = DateTime.Now;
            JournalEntry newEntry = new JournalEntry(prompt, response, date);
            entries.Add(newEntry);
        }

        // Method to display all journal entries
        public void DisplayJournal()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries in the journal.");
            }
            else
            {
                foreach (var entry in entries)
                {
                    Console.WriteLine(entry);
                    Console.WriteLine(new string('-', 40));
                }
            }
        }

        // Method to save journal entries to a file
        public void SaveToFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    sw.WriteLine($"{entry.Date}");
                    sw.WriteLine($"{entry.Prompt}");
                    sw.WriteLine($"{entry.Response}");
                    sw.WriteLine();
                }
            }
            Console.WriteLine($"Journal saved to {filename}.");
        }

        // Method to load journal entries from a file
        public void LoadFromFile(string filename)
        {
            try
            {
                entries.Clear();
                string[] lines = File.ReadAllLines(filename);
                for (int i = 0; i < lines.Length; i += 4) // 4 lines per entry
                {
                    DateTime date = DateTime.Parse(lines[i]);
                    string prompt = lines[i + 1];
                    string response = lines[i + 2];
                    entries.Add(new JournalEntry(prompt, response, date));
                }
                Console.WriteLine($"Journal loaded from {filename}.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"The file {filename} does not exist.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading the journal: {ex.Message}");
            }
        }
    }
}
