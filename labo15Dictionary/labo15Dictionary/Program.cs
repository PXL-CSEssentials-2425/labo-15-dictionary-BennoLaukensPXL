using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace labo15Dictionary
{
    internal class Program
    {
        private static Dictionary<string, int> _ranking = new Dictionary<string, int>();
        private static bool _keepRunning = true;
        static void Main(string[] args)
        {

            do
            {
                Console.Clear();
                Console.WriteLine($"Welkom bij het Klassement Beheer Systeem!");
                Console.WriteLine($"Kies een optie uit het menu:");
                Console.WriteLine($"1.Toon het klassement");
                Console.WriteLine($"2.Zoek de score van een deelnemer");
                Console.WriteLine($"3.Pas de score van een deelnemer aan of voeg een nieuwe deelnemer toe");
                Console.WriteLine($"4.Toon de gemiddelde score");
                Console.WriteLine($"5.Toon de deelnemer met de hoogste score");
                Console.WriteLine($"6.Stop het programma");
                Console.WriteLine();
                Console.Write($"Maak uw keuze: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                case "1":
                        ShowRanking();
                    break;
                case "2":
                        ShowScore();
                    break;
                case "3":
                        AddOrUpdatePerson();
                    break;
                case "4":
                        ShowAverageScore();
                    break;
                case "5":
                        ShowHighestScore();
                    break;
                case "6":
                        Close();
                    break;
                default:
                    break;
                }
            }
            while (_keepRunning);
        }
        private static void ShowRanking ()
        {
            Console.WriteLine($"Klassement:");
            foreach (var person in  _ranking.Keys)
            {
                Console.WriteLine($"{person}: {_ranking[person]} punten");
            }
            Console.ReadKey(true);
        }
        private static void ShowScore()
        {
            Console.Write($"Geef een naam van een deelnemer: ");
            string person = Console.ReadLine();
            if (!_ranking.ContainsKey(person))
            {
                Console.WriteLine($"{person} staat niet in het klassement");
            }
            else
            {
                Console.WriteLine($"{person} heeft {_ranking[person]} punten");
            }
            Console.ReadKey(true);
        }
        private static void AddOrUpdatePerson ()
        {
            Console.Write($"Geef een naam van een deelnemer: ");
            string key = Console.ReadLine();
            Console.Write($"Geef een nieuwe score: ");
            int.TryParse(Console.ReadLine(), out int value);
            if (!_ranking.Keys.Contains(key))
            {
                _ranking.Add(key, 0);
                Console.WriteLine($"{key} is toegevoegd aan het klassement met {value} punten");

            }
            else
            {
                Console.WriteLine($"De score van {key} is bijgewerkt naar {value}");
            }
            _ranking[key] = value;
            Console.ReadKey(true);
        }
        private static void ShowAverageScore ()
        {
            float average = 0;
            float devide = 0;
            foreach (string person in  _ranking.Keys)
            {
                average += _ranking[person];
                devide++;
            }
            Console.WriteLine($"De gemiddelde score van alle deelnemers is: {average / devide} punten.");
            Console.ReadKey(true);
        }
        private static void ShowHighestScore ()
        {
            //KeyValuePair<string, int> highest = _ranking.MaxBy(s => s.Value); --> .NET 8
            string highestPerson = string.Empty;
            foreach (string person in _ranking.Keys)
            {
                if (_ranking[person] > _ranking[highestPerson])
                {
                    highestPerson = person;
                }
            }
            Console.WriteLine($"De deelnemer met de hoogste score is {highestPerson} met {_ranking[highestPerson]} punten.");
            Console.ReadKey(true);
        }
        private static void Close()
        {
            _keepRunning = false;
            Console.WriteLine($"Bedankt voor het gebruiken van het Klassement Beheer Systeem. Tot ziens!");
            Console.ReadKey(true);
        }
    }
}
