using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    // Private member variables for encapsulation
    private string _text;
    private bool _isHidden;

    // Constructor to initialize word with encapsulated properties
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Public method to access the text
    public string GetText()
    {
        return _text;
    }

    // Public method to access whether the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Public method to hide the word by setting underscores
    public string Hide()
    {
        if (!_isHidden)
        {
            _isHidden = true;
            return new string('_', _text.Length);
        }
        return _text; // If already hidden, just return the word as is
    }

    // Optionally, you can provide a public method to set the word if needed, 
    // but here we have encapsulated the field so it's not directly modified.
}

public class ScriptureReference
{
    // Private member variables for encapsulation
    private string _reference;
    private bool _isRange;

    // Constructor for a single verse
    public ScriptureReference(string reference)
    {
        _reference = reference;
        _isRange = false;
    }

    // Constructor for a range of verses (e.g., "Proverbs 3:5-6")
    public ScriptureReference(string startReference, string endReference)
    {
        _reference = $"{startReference}-{endReference}";
        _isRange = true;
    }

    // Public method to access the reference
    public string GetReference()
    {
        return _reference;
    }

    // Public method to check if the reference is a range
    public bool IsRange()
    {
        return _isRange;
    }

    // Method to display the reference properly
    public override string ToString()
    {
        return _reference;
    }
}

public class Scripture
{
    // Private member variables for encapsulation
    private ScriptureReference _reference;
    private List<Word> _words;

    // Constructor for scripture with reference and text
    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = text.Split(new[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(w => new Word(w))
                    .ToList();
    }

    // Public method to get the reference of the scripture
    public ScriptureReference GetReference()
    {
        return _reference;
    }

    // Public method to get the list of words in the scripture
    public List<Word> GetWords()
    {
        return _words;
    }

    // Method to hide a random word
    public string HideRandomWord(List<Word> hiddenWords)
    {
        Random random = new Random();
        string hiddenText = string.Join(" ", _words.Select(w => w.IsHidden() ? new string('_', w.GetText().Length) : w.GetText()));

        // If all words are hidden, return the scripture as is
        if (_words.All(w => w.IsHidden()))
        {
            return hiddenText;
        }

        // Select a random word that is not hidden
        Word wordToHide;
        do
        {
            wordToHide = _words[random.Next(_words.Count)];
        } while (wordToHide.IsHidden());

        // Hide the word and add it to the hidden words list
        wordToHide.Hide();
        hiddenWords.Add(wordToHide);

        return string.Join(" ", _words.Select(w => w.IsHidden() ? new string('_', w.GetText().Length) : w.GetText()));
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
            Console.WriteLine($"Scripture: {scripture.GetReference()}");
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
                if (hiddenWords.Count == scripture.GetWords().Count)
                {
                    Console.Clear();
                    Console.WriteLine($"Scripture: {scripture.GetReference()}");
                    Console.WriteLine(scripture.HideRandomWord(hiddenWords));
                    Console.WriteLine("\nAll words are hidden. Press any key to exit.");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
