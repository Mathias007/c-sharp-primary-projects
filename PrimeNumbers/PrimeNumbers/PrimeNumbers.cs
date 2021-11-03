
/* Projekt aplikacji rozpoznającej liczby pierwsze, przygotowany na zajęcia z Podstaw Programowania sem. I WSB (2021/2022).
 * Autor rozwiązania: Mateusz Stawowski (https://github.com/Mathias007).
 * Link do repozytorium zbiorczego: https://github.com/Mathias007/WSB-Task.
 * Zgodnie z poleceniem, program do testu pierwszości wykorzystuje rekurencje, natomiast wykluczone jest stosowanie pętli.
 * 
 * Algorytm działa następująco: 
 *  (1) wpisana liczba (n) podlega wstępnemu badaniu, czy jest parzysta - w ten sposób do dalszego etapu przechodzą wyłącznie liczby nieparzyste;
 *  (2) następnie podejmowane są próby dzielenia liczby (n) przez kolejne dzielniki z przedziału od 3 do pierwiastka z n;
 *  (3) selekcja dzielników:
 *      (a) tylko dzielniki nieparzyste - pozwala to na zmniejszenie operacji o połowę,
 *      (b) tylko dzielniki będące liczbami pierwszymi - podlegają temu samemu testowi pierwszości, co wpisana liczba, jeżeli go nie przejdą - przeskakujemy do kolejnego nieparzystego dzielnika,
 *      operacje (b) zostały wprowadzone w celu odzwierciedlenia działania Sita Eratostenesa oraz przećwiczenia rekurencji, pomimo że zwiększają ogólną liczbę wykonywanych przez program operacji (choć zmniejszają liczbę operacji w głównej "gałęzi");
 *  (4) liczba jest pierwsza, jeżeli przejdzie negatywnie test wstępny (nie jest parzysta) oraz pozytywnie test zasadniczy (pierwszości);
 *  (5) metoda PrimeTest obsługuje komunikaty o wyniku operacji oraz zwraca ten wynik w postaci binarnej (obecie program z tego nie korzysta, ale w przyszłych implementacjach może się to zmienić);
 *  (6) metoda HandleProgram zarządza całością aplikacji, tutaj również wykorzystuję rekurencję, aby zapewnić możliwość dokonywania kolejnych obliczeń przez użytkownika (alternatywa dla pętli opartej o flagę typu bool).
 *  
 */

using System;

namespace WSB_Task3
{
    class PrimeNumbers
    {
        private static bool IsNumberEven(int numberToCheck)
        {
            return !Convert.ToBoolean(numberToCheck % 2);
        }

        private static bool IsNumberPrime(int numberToCheck, int potencialDivider = 3)
        {
            bool primeTestResult = Convert.ToBoolean(numberToCheck % potencialDivider);

            if (potencialDivider <= Math.Sqrt(numberToCheck))
            {
                if (!primeTestResult)
                {
                    return primeTestResult;
                }
                else
                {
                    potencialDivider += 2;
                    if (IsNumberPrime(potencialDivider)) 
                    {
                        return IsNumberPrime(numberToCheck, potencialDivider);
                    } 
                    else
                    {
                        potencialDivider += 2;
                        return IsNumberPrime(numberToCheck, potencialDivider);
                    }
                }
            }
            else
            {
                return primeTestResult;
            }
        }

        public static bool PrimeTest(int numberToCheck)
        {
            bool primeTestResult;
            string primeTestMessage = "";

            if (numberToCheck > 1)
            {
                if (numberToCheck == 2)
                {
                    primeTestMessage="Wpisana liczba jest pierwsza, ponieważ wynosi 2!";
                    primeTestResult = true;
                } else if (IsNumberEven(numberToCheck))
                {
                    primeTestMessage = "Podana liczba nie jest pierwsza, ponieważ jest parzysta!";
                    primeTestResult = false;
                }
                else if (!IsNumberEven(numberToCheck) && !IsNumberPrime(numberToCheck))
                {
                    primeTestMessage = "Chociaż wpisana liczba jest nieparzysta, to jednak nie jest pierwsza, ponieważ jest złożona!";
                    primeTestResult = false;
                }
                else if (!IsNumberEven(numberToCheck) && IsNumberPrime(numberToCheck)) 
                {
                    primeTestMessage = "Wpisana liczba jest pierwsza, ponieważ przeszła pozytywnie test pierwszości!";
                    primeTestResult = true;
                } 
                else primeTestResult = false;
            }
            else
            {
                primeTestMessage = "Wpisz poprawną liczbę!";
                primeTestResult = false;
            }

            Console.WriteLine(primeTestMessage);
            return primeTestResult;
        }

        public static void HandleProgram()
        {
            Console.WriteLine("Wpisz liczbę naturalną większą od 1 do przeprowadzenia na niej testu pierwszości");
            int numberToCheck = int.Parse(Console.ReadLine());
            PrimeTest(numberToCheck);

            Console.WriteLine("Test pierwszości został wykonany. Czy chcesz sprawdzić kolejną liczbę? (Y - Tak, inny klawisz - zakończenie programu)");

            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.Clear();
                HandleProgram();
            }
            else
            {
                Console.WriteLine("Dziękujemy za skorzystanie z programu");
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            HandleProgram();
        }
    }
}
