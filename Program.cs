using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.IO;

using System.Text.Json;

using System.Text.Json.Serialization;

using System.Xml.Schema;
using System;
using System.Text.RegularExpressions;

abstract class Task
{
    protected string _text;
    protected char[] _pattern = { ' ', ',', '.', '!', ';', ':', '?', '-', '(', ')' };
    public Task(string text)
    {
       _text = text;
    }
}
class Task1 : Task
{
    private string[] _sentences;
    private string _lasttext;
    [JsonConstructor]
    public Task1(string text) : base (text)
    {
        _sentences = SplitIntoSentences();      
    }
    private string[] SplitIntoSentences()
    {
        char[] sentenceEndings = { '.', '!', '?' };
        string[] rawSentences = _text.Split(sentenceEndings, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < rawSentences.Length; i++)
        {
            rawSentences[i] = rawSentences[i].Trim();
        }
        return rawSentences;
    }
    public override string ToString()
    {
        string shortestSentence = _sentences[0];
        for (int i = 1; i < _sentences.Length; i++)
        {
            if (_sentences[i].Length <= shortestSentence.Length)
            {
                shortestSentence = _sentences[i];
            }
        }
        return shortestSentence;
    }
}
class Task2 : Task
{
    private string[] _words;
    [JsonConstructor]
    public Task2(string text):base(text)
    {
        _words = SplitIntoWords();
    }
    private string[] SplitIntoWords()
    {

        return _text.Split(_pattern);
    }

    public override string ToString()
    {
        string result = string.Empty;

        for (int i = 0; i < _words.Length; i++)
        {
            string word = _words[i];

            if (IsFreeWord(word, i))
            {
                result += word + " ";
            }
        }

        
        return result.TrimEnd();
    }

    public bool IsFreeWord(string word, int index)
    {

        if (index == 0 ||
            (_text.IndexOf(word) > 0 &&
             _text[_text.IndexOf(word) - 1] == ' ' &&
             _text.IndexOf(word) + word.Length < _text.Length &&
             _text[_text.IndexOf(word) + word.Length] == ' '))
        {
            return true;
        }

        return false;
    }

}

class JsonIO

{

    public static void Write<T>(T obj, string FilePath)

    {

        using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))

        {

            JsonSerializer.Serialize(fs, obj);

        }

    }

    public static T Read<T>(string FilePath)

    {

        using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))

        {

            JsonSerializer.Deserialize<T>(fs);

        }

        return default(T);

    }

}

internal class Program
{
    static void Main(string[] args)
    {
        Task1 task1 = new Task1("Привет это Илон Маск. Как твои дела? Что делаешь?");
        Console.WriteLine(task1.ToString());
        Task2 task2 = new Task2("Привет это Илон Маск. Как твои дела? Что делаешь?");        
        Console.WriteLine(task2.ToString());

        string path = @"C:\Users\m2308500\Desktop";

        string name = "Fourth Task";

        path = Path.Combine(path, name);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string Name1 = "string_1.json";

        string Name2 = "string_2.json";

        Name1 = Path.Combine(path, Name1);

        Name2 = Path.Combine(path, Name2);

        if (!File.Exists(Name1))
        {
            JsonIO.Write<Task1>((Task1)task1, Name1);

            JsonIO.Write<Task2>((Task2)task2, Name2);
        }
        else
        {
            Console.WriteLine(JsonIO.Read<Task1>(Name1));

            Console.WriteLine(JsonIO.Read<Task2>(Name2));
        }
    }
}