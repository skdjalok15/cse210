using System;

class Entry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }
    public string Tag { get; }
    public string Mood { get; }

    public Entry(string date, string prompt, string response, string tag, string mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Tag = tag;
        Mood = mood;
    }

    public override string ToString()
    {
        return $"[{Date}] ({Tag}) - Mood: {Mood}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}
