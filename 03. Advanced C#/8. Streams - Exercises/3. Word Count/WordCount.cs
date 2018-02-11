using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class WordCount
{
    public static void Main()
    {
        List<string> words = new List<string>();
        using (var reader = new StreamReader("../../words.txt"))
        {
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                words.Add(line);
            }
        }

        Dictionary<string, int> wordsCount = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (!wordsCount.ContainsKey(word))
            {
                wordsCount.Add(word, 0);
            }
        }

        using (var reader = new StreamReader("../../text.txt"))
        {
            string line = null;

            while ((line = reader.ReadLine()) != null)
            {
                foreach (var word in line.ToLower().Split(new []{' ', '.', ',', '-','?', '!'}, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (wordsCount.ContainsKey(word))
                    {
                        ++wordsCount[word];
                    }
                }
            }
        }

        using (var writer = new StreamWriter("../../result.txt"))
        {
            foreach (var pair in wordsCount.OrderByDescending(x=> x.Value))
            {
                writer.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
