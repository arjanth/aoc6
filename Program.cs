using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace aoc6
{
    class Program
    {
        static void Main(string[] args)
        {
            var group = new List<char>();
            char[] row;
            int totalCount=0;
            bool newgroup=true;
            var removequestions = new List<char>();
            foreach (string line in File.ReadLines(@"C:\Repos\aoc6\input\answers.txt"))
            {
                Console.WriteLine(line);
                if (line == string.Empty)  // group is ingelezen let op je moet twee lege enters na laatste groep in inputfile hebben
                {
                    totalCount += group.Count;
                    Console.WriteLine($" antwoorden die iedere persoon uit de groep heeft gegeven: {string.Join(",", group)} aantal: {group.Count}");
                    group.Clear();  //wis de antwoorden voor een nieuwe group
                    newgroup = true;
                }
                else
                {
                    row = line.ToCharArray();  //de antwoorden opslaan in een tijdelijke array     
                    if(newgroup)  //eerste persoon uit de group
                    {
                        foreach (char question in row)
                        {
                           group.Add(question);   // alle antwoorden van het eerste groupslid opnemen in de lijst
                        }
                        newgroup = false;
                    }
                    else // tweede of volgende persoon in de group
                    {
                        
                        //antwoorden uit de grouplijst verwijderen die niet op de lijst van de huidige persoon staan
                        foreach (char question in group)
                        {
                            if (!row.Contains(question)) removequestions.Add(question);      //maak een lijst van te verwijderen vragen
                        }
                        
                        foreach(char question in removequestions)
                        {
                            group.Remove(question);  //verwijder de vraag van de grouplijst
                        }
                        removequestions.Clear();   //maak het tijdelijke lijstje weer leeg.
                        
                    }
                    
                }
            }
            Console.WriteLine($"sum of counts: {totalCount}");
            // goede antwoord: 6457 (deel 1, anyone yes)
            // deel twee: 3260
        }
    }
}
