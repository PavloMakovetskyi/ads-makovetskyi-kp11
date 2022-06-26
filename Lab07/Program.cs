using System;
using System.Collections.Generic;

namespace HashTable
{
    internal class Program
    {
        static List<string> addedKeysList = new List<string>();
        static void Main(string[] args)
        {
            
            const int gateCount = 4;
            HashTable table = new HashTable(gateCount);
            
            // Контрольний приклад
            table.InsertEntry(new Key("MH1027"),
                              new Value("Aer1", "gate1", new TimeDate(1, "may", 2022, new Time(12, 0))));
            addedKeysList.Add("MH1027");
            table.InsertEntry(new Key("Boing 505-f"),
                              new Value("Aer2", "gate2", new TimeDate(1, "May", 2022, new Time(14, 0))));
            addedKeysList.Add("Boing 505-f");
            table.InsertEntry(new Key("Malasy 654"),
                              new Value("Aer4", "gate3", new TimeDate(2, "May", 2022, new Time(12, 0))));
            addedKeysList.Add("Malasy 654");
            table.InsertEntry(new Key("Boing 801-r"),
                              new Value("Aer7", "gate4", new TimeDate(3, "May", 2022, new Time(9, 0))));
            addedKeysList.Add("Boing 801-r");
            table.InsertEntry(new Key("MH1902"),
                              new Value("Aer9", "gate1", new TimeDate(3, "May", 2022, new Time(13, 0))));
            addedKeysList.Add("MH1902");
            table.InsertEntry(new Key("Test Boing"),
                              new Value("Aer9", "gate1", new TimeDate(3, "May", 2022, new Time(13, 5))));
            addedKeysList.Add("Test Boing");

            var res1 = table.FindEntry(new Key("Malasy 654"));
            var res2 = table.FindEntry(new Key("Test Boing"));


           Console.WriteLine(res1.ToString());
           Console.WriteLine(res2.ToString());



            var fls = table.SameGateFlights("gate4");
            foreach (var fl in fls)
            {
                Console.WriteLine(fl);
            }

            // Основний
            while (true) 
            {
                AddingSearchingAndRemovingEntries(table, Console.ReadLine());
            }
        }


        static void PrintEntries(HashTable hash, List<string> keysList) 
        {
            foreach (var addedKey in keysList) 
            {
                var res = hash.FindEntry(new Key(addedKey));
                Console.WriteLine(res.ToString());
            }
        }

        static void AddingSearchingAndRemovingEntries(HashTable table, string answer)
        {
            switch (answer.ToLower().Trim()) 
            {
                case "add":
                    Console.Write("key: ");  string str_key = Console.ReadLine();
                    Console.Write("aeroport: ");  string aer = Console.ReadLine();
                    Console.Write("gate: ");  string gate = Console.ReadLine();
                    Console.Write("day: ");  int day = int.Parse(Console.ReadLine());
                    Console.Write("month: ");  string month = Console.ReadLine();
                    Console.Write("year: ");  int year = int.Parse(Console.ReadLine());
                    Console.Write("hour: "); int hour = int.Parse(Console.ReadLine());
                    Console.Write("minutes: "); int minutes = int.Parse(Console.ReadLine());
                    table.InsertEntry(new Key(str_key), new Value(aer, gate,
                        new TimeDate(day, month, year, new Time(hour, minutes))));
                    addedKeysList.Add(str_key);
                    break;
                case "find":
                    Console.Write("key: "); string search_key = Console.ReadLine();
                    var res = table.FindEntry(new Key(search_key));
                    Console.WriteLine(res.ToString());
                    break;
                case "remove":
                    Console.Write("key: "); string remove_key = Console.ReadLine();
                    table.RemoveEntry(new Key(remove_key));
                    addedKeysList.Remove(remove_key);
                    break;
                case "show":
                    Console.Clear();
                    PrintEntries(table, addedKeysList);
                    break;
                case "same gates":
                    Console.Write("gate: "); string samefl_gate = Console.ReadLine();
                    var fls = table.SameGateFlights(samefl_gate);
                    foreach (var fl in fls)
                    {
                        Console.WriteLine(fl);
                    }
                    break;
                case "exit":
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("default action: exiting");
                    System.Environment.Exit(0);
                    break;
                    


            }
        }
    }

}

