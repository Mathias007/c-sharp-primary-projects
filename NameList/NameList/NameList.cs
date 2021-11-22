using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

/* Program przygotowany na zajęcia z Podstaw Programowania sem. I WSB (2021/2022).
 * Autor rozwiązania: Mateusz Stawowski (https://github.com/Mathias007).
 * Link do repozytorium zbiorczego: https://github.com/Mathias007/WSB-Task.
 * Program wczytuje listę z pliku tekstowego, tworzy z pobranych danych listę, a następnie wyświetla:
     1. Element 246 z listy (przyjąłem, że chodzi o element pod indeksem 246, a nie 246. element listy)
     2. Tylko osoby o imieniu Anna.
 * Praktyczne operacje z plikiem i ścieżką, a także zastosowanie list, foreach, metod i lambdy na prostym przykładzie. 
 */

namespace NameList
{
    class NameList
    {
        static void Main(string[] args)
        {
            int selectedIndex = 246;
            string nameToFind = "Anna";
            string fileName = "names.txt";
            var filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, $"..\\..\\..\\{fileName}"));

            List<string> namesMainList = File.ReadLines(filePath).ToList();

            Console.WriteLine($"1. Na pozycji {selectedIndex} listy znajduje się: {namesMainList[selectedIndex]}.");

            Console.WriteLine($"2. Poniżej wyświetlam wszystkie osoby o imieniu {nameToFind}: ");
            List<string> selectedNamesList = namesMainList.FindAll(line => line.Contains(nameToFind));

            foreach (var name in selectedNamesList)
            {
              Console.WriteLine(name);
            }

            Console.ReadKey();
        }

    }
}
