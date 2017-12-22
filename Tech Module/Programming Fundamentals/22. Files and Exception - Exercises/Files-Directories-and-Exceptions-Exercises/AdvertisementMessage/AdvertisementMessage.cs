using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdvertisementMessage
{
    class AdvertisementMessage
    {
        private static readonly string inputFileName = "input.txt";

        private static readonly string outputFileName = "output.txt";
        
        private static readonly string[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
        private static readonly string[] events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
        private static readonly string[] authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
        private static readonly string[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

        private static int numberOFMessages;
        private static Random rnd;

        public AdvertisementMessage(int numberOFMessages = 1)
        {
            AdvertisementMessage.numberOFMessages = numberOFMessages;
            rnd = new Random();

            CleanOutputFile();

            for (int i = 0; i < numberOFMessages; i++)
            {
                GenerateMessages();
            }
            WriteToFile(String.Empty);
        }

        private static void GenerateMessages()
        {
            int index = rnd.Next(0, phrases.Length);
            string phrase = phrases[index];

            index = rnd.Next(0, events.Length);
            string eventText = phrases[index];

            index = rnd.Next(0, authors.Length);
            string author = authors[index];


            index = rnd.Next(0, cities.Length);
            string city = cities[index];

            WriteToFile($"{phrase} {eventText} {author} - {city}");

        }

        private static void WriteToFile(string text)
        {
            using (StreamWriter writer = new StreamWriter(outputFileName, true))
            {
                writer.WriteLine(text);
            }
        }

        private static void CleanOutputFile()
        {
            using (StreamWriter writer = new StreamWriter(outputFileName, false))
            {
                writer.Write(String.Empty);
            }
        }

        static void Main(string[] args)
        {
            string text = File.ReadAllText(inputFileName);

            new AdvertisementMessage(int.Parse(text));
        }
    }
}
