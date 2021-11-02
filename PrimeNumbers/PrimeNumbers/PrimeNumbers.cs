
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
        private static bool IsNumberEven(int numberToCheck)
        {
            if (numberToCheck % 2 == 0)
            {
                Console.WriteLine("Podana liczba nie jest pierwsza, ponieważ jest parzysta");
                return true;
            }
            else
            {
                Console.WriteLine("Podana liczba jest nieparzysta, zatem podlega dalszym sprawdzeniom (dzielniki nieparzyste)");
                return false;
            }
        }

        private static bool IsNumberPrime(int numberToCheck, int potencialDivider = 3)
        {
            if (potencialDivider <= Math.Sqrt(numberToCheck))
            {
                if (numberToCheck % potencialDivider == 0)
                {
                    Console.WriteLine("Liczba nie jest pierwsza. Najmniejszy wykryty dzielnik:" + potencialDivider);
                    return false;
                }
                else
                {
                    Console.WriteLine("Sprawdzam dzielnik " + potencialDivider);
                    potencialDivider += 2;
                    return IsNumberPrime(numberToCheck, potencialDivider);
                }
            }
            else
            {
                Console.WriteLine("Wpisana liczba jest pierwsza!");
                return true;
            }
        }

        public static bool PrimeTest(int numberToCheck)
        {
            if (numberToCheck > 1)
            {
                if (!IsNumberEven(numberToCheck) && IsNumberPrime(numberToCheck)) return true;
                else return false;
            }
            else
            {
                Console.WriteLine("Wpisz poprawną liczbę!");
                return false;
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
