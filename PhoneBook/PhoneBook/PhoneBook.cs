/* Projekt prostej książki telefonicznej, przygotowany na zajęcia z Podstaw Programowania sem. I WSB (2021/2022).
 * Autor rozwiązania: Mateusz Stawowski (https://github.com/Mathias007).
 * Link do repozytorium zbiorczego: https://github.com/Mathias007/WSB-Task.
 * Program wykorzystuje w szczególności:
 *  - słowniki oraz słowniki uporządkowane (strukturyzacja danych) wraz z metodami na nich operującymi, 
 *  - pętle do...while (sterowanie programu) i switch (wybór opcji programu) wraz z instrukcjami warunkowymi,
 *  - kolorowanie tekstu w konsoli (estetyka)
**/

using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class PhoneBook
    {
        static void Main(string[] args)
        {
            bool isProgramOpen = true;

            Dictionary<string, string> options = new Dictionary<string, string>
            {
                {"[w]", "wyświetl książkę" },
                {"[s]", "szukaj po nazwisku i imieniu" },
                {"[a]", "szukaj po numerze telefonu" },
                {"[d]", "dodaj nowy wpis"}
            };

            SortedDictionary<string, string> phoneBook = new SortedDictionary<string, string>
            {
                {"Nowak Jan", "000-000-000" },
                {"Kot Piotr", "111-111-111" },
                {"Kowalska Jadwiga", "222-222-222" },
                {"Wiśniewski Krzysztof", "333-333-333" },
                {"Nowakowski Jerzy", "444-444-444" },
                {"Pawłowska Joanna", "555-555-555" },
                {"Kołodziej Henryk", "666-666-666" },
                {"Karłowicz Witold", "777-777-777" },
                {"Nowak Paweł", "888-888-888" },
                {"Kowal Marcin", "999-999-999" },
            };

            do
            {
                Console.WriteLine("Witamy w książce telefonicznej. Wybierz opcję z listy poniżej:");

                foreach(KeyValuePair<string, string> option in options)
                {
                    Console.WriteLine($" {option.Key} - {option.Value}");
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                Console.Clear();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        Console.WriteLine("Lista wszystkich wpisów w książce telefonicznej:");
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        foreach (KeyValuePair<string, string> record in phoneBook)
                        {
                            Console.WriteLine($" + {record.Key}: {record.Value}");
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\n");

                        break;

                    case ConsoleKey.S:
                        Console.WriteLine("Wpisz nazwisko i imię poszukiwanej osoby: ");
                        string selectedName = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (phoneBook.TryGetValue(selectedName, out string foundNumber))
                        {
                            Console.WriteLine($" -> {selectedName} dysponuje numerem telefonu: {foundNumber}");
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono osoby o podanych personaliach");
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\n");

                        break;

                    case ConsoleKey.A:
                        Console.WriteLine("Podaj poszukiwany numer telefonu: ");
                        string selectedNumber = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (phoneBook.ContainsValue(selectedNumber))
                        {
                            foreach (KeyValuePair<string, string> record in phoneBook)
                            {

                                if (record.Value == selectedNumber)
                                {
                                    Console.WriteLine($" -> Numer {selectedNumber} jest przypisany do: {record.Key}");
                                }
                            }
                        } else
                        {
                            Console.WriteLine("Nie znaleziono takiego numeru telefonu");
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\n");

                        break;

                    case ConsoleKey.D:

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Wprowadź nazwisko i imię: ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Wprowadź numer telefonu: ");
                        string number = Console.ReadLine();

                        phoneBook[name] = number;
                        Console.ForegroundColor = ConsoleColor.Gray;

                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Czy chcesz wyjść z programu? \n Naciśnij [t] - tak, [n] - nie");

                        if (Console.ReadKey().Key == ConsoleKey.T)
                        {
                            Console.WriteLine("\n Dziękujemy za skorzystanie z książki telefonicznej");
                            isProgramOpen = !isProgramOpen;
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;

                        break;
                }

            } while (isProgramOpen);

            Console.ReadKey();
        }
    }
}
