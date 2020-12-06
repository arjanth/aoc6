using System;
using System.Collections.Generic;
using System.IO;


namespace aoc6
{
    class Program
    {
        static void Main(string[] args)
        {
            var group = new List<char>();
            char[] row;
            int totalCount=0;
            foreach (string line in File.ReadLines(@"C:\Repos\aoc6\input\example.txt"))
            {
                Console.WriteLine(line);
                if (line == string.Empty)  // group is ingelezen let op je moet twee lege enters na laatste groep in inputfile hebben
                {
                    totalCount += group.Count;
                    Console.WriteLine($"unieke antwoorden: {string.Join(",", group)} aantal: {group.Count}");
                    group.Clear();  //wis de antwoorden voor een nieuwe group
                }
                else
                {
                    row = line.ToCharArray();  //de antwoorden opslaan in een tijdelijke array
                    foreach (char question in row)
                    {
                        if (!group.Contains(question)) group.Add(question);   //sla de gelezen velden op in de password dictionary
                    }
                }
            }
            Console.WriteLine($"sum of counts: {totalCount}");
        }
    }
}
