
/* Projekt Kalkulatora przygotowany na zajęcia z Podstaw Programowania sem. I WSB (2021/2022).
 * Autor rozwiązania: Mateusz Stawowski (https://github.com/Mathias007).
 * Link do repozytorium: https://github.com/Mathias007/WSB-Task.
 * Kalkulator wykonuje wszystkie operacje wymienione w poleceniu.
 * Wykorzystuje różne typy zmiennych, instrukcji warunkowych, pętli. Zapewniona obsługa podstawowych wyjątków oraz możliwość powtarzania obliczeń.
 * Ponieważ program nie korzysta z metod/klas, dyrektywa DRY nie została w pełni zrealizowana, a poszczególne funkcjonalności nie zostały od siebie oddzielone, aczkolwiek starałem się w miarę możliwości unikać powtórzeń i racjonalizować kod.
 */

using System;

namespace WSB_Task
{
    class Calculator
    {
        static void Main(string[] args)
        {
            bool isProgramActive = true;

            Console.WriteLine("Witaj w aplikacji Kalkulator!");

            while (isProgramActive)
            {
                double firstNumber;
                double secondNumber;

                Console.WriteLine("\n Podaj dwie liczby, które chciałbyś poddać działaniu.");
                Console.Write("     Pierwsza liczba: ");
                firstNumber = double.Parse(Console.ReadLine().Replace('.', ','));

                Console.Write("     Druga liczba: ");
                secondNumber = double.Parse(Console.ReadLine().Replace('.', ','));

                Console.WriteLine($"Wybrałeś liczby: {firstNumber} oraz {secondNumber}. \n");

                string[] calcOperations = new string[] { "Dodawanie", "Odejmowanie", "Mnożenie", "Dzielenie", "Potęgowanie", "Pierwiastkowanie", "Procenty" };
                Console.WriteLine("Jakie działanie chcesz wykonać? Wybierz odpowiednie działanie z listy poniżej:");
                for (int i = 0; i < calcOperations.Length; i++)
                    {
                        Console.WriteLine($"       {i} - {calcOperations[i].ToUpper()}");
                    }

                Console.Write("     Twój wybór: ");
                var choosenOperator = int.Parse(Console.ReadLine());
                Console.WriteLine($"Wybrałeś {calcOperations[choosenOperator].ToUpper()}. \n");

                string finalMessage;
                double operationResult;

                switch (choosenOperator)
                {
                    case 0:
                        operationResult = firstNumber + secondNumber;
                        finalMessage = $"Wynik dodawania: {operationResult}";
                        break;

                    case 1:
                        operationResult = firstNumber - secondNumber;
                        finalMessage = $"Wynik odejmowania: {operationResult}";
                        break;

                    case 2:
                        operationResult = firstNumber * secondNumber;
                        finalMessage = $"Wynik mnożenia: {operationResult}";
                        break;

                    case 3:
                        if (secondNumber != 0)
                            {
                                operationResult = firstNumber / secondNumber;
                                finalMessage = $"Wynik dzielenia: {operationResult}";
                            }
                        else
                            {
                                throw new DivideByZeroException("Nie można dzielić przez zero!");
                            }

                        break;

                    case 4:
                        Console.WriteLine($"Którą z wpisanych wcześniej liczb chciałbyś poddać podniesieniu do kwadratu? ");
                        Console.WriteLine("     1 - Pierwszą \n     2 - Drugą");
                        Console.Write("     Twój wybór: ");
                        int numberSelectedToPow = int.Parse(Console.ReadLine());

                        if (numberSelectedToPow == 1)
                            {
                                operationResult = Math.Pow(firstNumber, 2);
                                finalMessage = $"Wynik potęgowania: {operationResult}";

                            }
                        else if (numberSelectedToPow == 2)
                            {
                                operationResult = Math.Pow(secondNumber, 2);
                                finalMessage = $"Wynik potęgowania: {operationResult}";
                            }
                        else
                            {
                                throw new NotSupportedException("Nieprawidłowy wybór!");
                            }

                        break;

                    case 5:
                        Console.WriteLine($"Którą z wpisanych wcześniej liczb chciałbyś mu poddać w celu uzyskania pierwiastka kwadratowego?");
                        Console.WriteLine("     1 - Pierwszą \n     2 - Drugą");
                        Console.Write("     Twój wybór: ");
                        int numberSelectedToSqrt = int.Parse(Console.ReadLine());

                        if (numberSelectedToSqrt == 1)
                          {
                                operationResult = Math.Sqrt(firstNumber);
                                finalMessage = $"Wynik pierwiastkowania: {operationResult}";
                           }
                        else if (numberSelectedToSqrt == 2)
                           {
                                operationResult = Math.Sqrt(secondNumber);
                                finalMessage = $"Wynik pierwiastkowania: {operationResult}";
                           }
                        else
                            {
                                throw new NotSupportedException("Nieprawidłowy wybór!");
                            }
                        
                        break;

                    case 6:
                        operationResult = firstNumber / secondNumber * 100;
                        finalMessage = $"Liczba {firstNumber} stanowi {operationResult}% liczby {secondNumber}. Czy chcesz odwrócić wartości?";
                        Console.WriteLine(finalMessage);
                        Console.WriteLine("Naciśnij Y, jeżeli jesteś zainteresowany wykonaniem dodatkowej operacji.");
                        string userReplacementExpectations = Console.ReadLine();

                        if (userReplacementExpectations.ToUpper() == "Y")
                            {
                                operationResult = secondNumber / firstNumber * 100;
                                finalMessage = $"Liczba {secondNumber} stanowi {operationResult}% liczby {firstNumber}.";
                            }

                        break;

                    default:
                        throw new NotSupportedException("Nieprawidłowy operator!");
                }

                Console.WriteLine(finalMessage);

                Console.WriteLine("Czy chcesz kontynuować? Jeżeli tak, naciśnij Y. Jeżeli nie - wybierz dowolny klawisz, aby zakończyć pracę kalkulatora.");
                Console.Write("    Twoja decyzja: ");
                if (Console.ReadLine().ToUpper() != "Y")
                {
                    Console.WriteLine("Dziękujemy za skorzystanie z programu.");
                    isProgramActive = !isProgramActive;
                }                
            }
        }
    }
}
