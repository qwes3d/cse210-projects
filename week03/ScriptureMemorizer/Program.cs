using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    public string Text { get; set; }
    public bool IsHidden { get; set; }

    // Constructor to initialize word
    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    // Method to hide the word by setting underscores
    public string Hide()
    {
        if (!IsHidden)
        {
            IsHidden = true;
            return new string('_', Text.Length);
        }
        return Text; // If already hidden, just return the word as is
    }
}

public class ScriptureReference
{
    public string Reference { get; set; }
    public bool IsRange { get; set; }

    // Constructor for a single verse
    public ScriptureReference(string reference)
    {
        Reference = reference;
        IsRange = false;
    }

    // Constructor for a range of verses (e.g., "Proverbs 3:5-6")
    public ScriptureReference(string startReference, string endReference)
    {
        Reference = $"{startReference}-{endReference}";
        IsRange = true;
    }

    // Method to display the reference properly
    public override string ToString()
    {
        return Reference;
    }
}

public class Scripture
{
    public ScriptureReference Reference { get; set; }
    public List<Word> Words { get; set; }

    // Constructor for scripture with reference and text
    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = text.Split(new[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(w => new Word(w))
                    .ToList();
    }

    // Method to hide a random word
    public string HideRandomWord(List<Word> hiddenWords)
    {
        Random random = new Random();
        string hiddenText = string.Join(" ", Words.Select(w => w.IsHidden ? new string('_', w.Text.Length) : w.Text));

        // If all words are hidden, return the scripture as is
        if (Words.All(w => w.IsHidden))
        {
            return hiddenText;
        }

        // Select a random word that is not hidden
        Word wordToHide;
        do
        {
            wordToHide = Words[random.Next(Words.Count)];
        } while (wordToHide.IsHidden);

        // Hide the word and add it to the hidden words list
        wordToHide.Hide();
        hiddenWords.Add(wordToHide);

        return string.Join(" ", Words.Select(w => w.IsHidden ? new string('_', w.Text.Length) : w.Text));
    }
}

class Program
{
    static void Main()
    {
        // Create a scripture with a reference and text
        var scriptureReference = new ScriptureReference("John 3:16");
        var scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture(scriptureReference, scriptureText);

        // List to track hidden words
        List<Word> hiddenWords = new List<Word>();

        while (true)
        {
            Console.Clear();
            // Display the current scripture reference and the current state of the text
            Console.WriteLine($"Scripture: {scripture.Reference}");
            Console.WriteLine(scripture.HideRandomWord(hiddenWords)); // Show hidden words progressively
            Console.WriteLine("\nPress ENTER to hide a word or type 'quit' to end.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            else if (string.IsNullOrEmpty(input)) // If ENTER is pressed
            {
                // Hide a random word and display the updated scripture
                scripture.HideRandomWord(hiddenWords);

                // If all words are hidden, end the program
                if (hiddenWords.Count == scripture.Words.Count)
                {
                    Console.Clear();
                    Console.WriteLine($"Scripture: {scripture.Reference}");
                    Console.WriteLine(scripture.HideRandomWord(hiddenWords));
                    Console.WriteLine("\nAll words are hidden. Press any key to exit.");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
