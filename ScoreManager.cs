using System;
using System.IO;

namespace SnakeGame
{
    public class ScoreManager
    {
        private const string FileName = "scores.txt";

        public void SaveResult(string name, int score)
        {
            using var sw = new StreamWriter(FileName, true);
            sw.WriteLine($"{name},{score}");
        }

        public void ShowResults(int top = 10)
        {
            if (!File.Exists(FileName)) return;

            var lines = File.ReadAllLines(FileName);
            Array.Sort(lines, (a, b) => int.Parse(b.Split(',')[1]).CompareTo(int.Parse(a.Split(',')[1])));

            Console.WriteLine("TOP SCORES:");
            for (int i = 0; i < Math.Min(top, lines.Length); i++)
            {
                var parts = lines[i].Split(',');
                Console.WriteLine($"{i + 1}. {parts[0]} - {parts[1]}");
            }
        }
    }
}
