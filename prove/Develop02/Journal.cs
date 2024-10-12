using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.Write("Tag this entry (e.g., work, personal, etc.): ");
        string tag = Console.ReadLine();

        Console.Write("Choose your mood (happy, sad, neutral, etc.): ");
        string mood = Console.ReadLine();

        Entry newEntry = new Entry(DateTime.Now.ToString("MM/dd/yyyy"), prompt, response, tag, mood);
        _entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.Tag}|{entry.Mood}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            Entry entry = new Entry(parts[0], parts[1], parts[2], parts[3], parts[4]);
            _entries.Add(entry);
        }
        Console.WriteLine("Journal loaded successfully.");
    }

    public void SearchEntries(string keyword)
    {
        foreach (Entry entry in _entries)
        {
            if (entry.Response.Contains(keyword) || entry.Tag.Contains(keyword))
            {
                Console.WriteLine(entry);
            }
        }
    }
}
