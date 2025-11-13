using System;
using System.IO;

public class Jounal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}~~{entry._promptText}~~{entry._entryText}~~{entry._mood}");
            }
        }
        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~~");

            string date = parts[0];
            string prompt = parts[1];
            string entry = parts[2];
            string mood = parts[3];

            Entry entryLoaded = new Entry(date, prompt, entry, mood);
            _entries.Add(entryLoaded);

        }

        Console.WriteLine("Journal loaded successfully!");
    }
}