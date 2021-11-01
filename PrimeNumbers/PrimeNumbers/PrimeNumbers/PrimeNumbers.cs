
/* Projekt aplikacji rozpoznającej liczby pierwsze, przygotowany na zajęcia z Podstaw Programowania sem. I WSB (2021/2022).
 * Autor rozwiązania: Mateusz Stawowski (https://github.com/Mathias007).
 * Link do repozytorium zbiorczego: https://github.com/Mathias007/WSB-Task.
 * Zgodnie z poleceniem, program do testu pierwszości wykorzystuje rekurencje, natomiast wykluczone jest stosowanie pętli.
 */

using System;

namespace WSB_Task3
{
    class PrimeNumbers
    {
        public static int PrimeTest(int numberToCheck, int potencialDivider = 2)
        {
            if (numberToCheck > 1)
            {
                if (potencialDivider <= Math.Sqrt(numberToCheck))
                {
                    if (numberToCheck % potencialDivider == 0)
                    {
                        Console.WriteLine("Liczba nie jest pierwsza, ponieważ dzieli się m. in. przez " + potencialDivider);
                        return potencialDivider;
                    }
                    else
                    {
                        Console.WriteLine("Sprawdzam dzielnik " + potencialDivider);
                        potencialDivider++;
                        return PrimeTest(numberToCheck, potencialDivider);
                    }
                }
                else
                {
                    Console.WriteLine("Wpisana liczba jest pierwsza!");
                    return numberToCheck;
                }
            } else
            {
                Console.WriteLine("Wpisz poprawną liczbę!");
                return numberToCheck;
            }
        }

        static void Main(string[] args)
        {                           
            Console.WriteLine("Wpisz liczbę NATURALNĄ większą od 1 do sprawdzenia");
            int numberToCheck = int.Parse(Console.ReadLine());
            Console.WriteLine(PrimeTest(numberToCheck));
            Console.ReadLine();
        }
    }
}
