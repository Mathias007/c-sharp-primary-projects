using System;

namespace WSB_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w aplikacji Kalkulator");
            Console.WriteLine("Aby kontynuować, podaj dwie liczby");

            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine($"Wybrałeś liczby: {firstNumber} oraz {secondNumber}");

            string[] calcOperations = new string[] { "Dodawanie", "Odejmowanie", "Mnożenie", "Dzielenie", "Potęgowanie", "Pierwiastkowanie", "Procent" };
            Console.WriteLine("Jakie działanie chcesz wykonać? Wybierz odpowiednie działanie z listy poniżej:");
            for (int i = 0; i < calcOperations.Length; i++)
                 {
                    Console.WriteLine($" {i} - {calcOperations[i].ToUpper()}");
                 }

            var choosenOperator = int.Parse(Console.ReadLine());

            double operationResult = 0;

            switch (choosenOperator)
            {
                case 0:
                    Console.WriteLine("Wybrałeś dodawanie");
                    operationResult = firstNumber + secondNumber;
                    Console.WriteLine($"Wynik dodawania: {operationResult}");
                    break;

                case 1:
                    Console.WriteLine("Wybrałeś odejmowanie");
                    operationResult = firstNumber - secondNumber;
                    Console.WriteLine($"Wynik odejmowania: {operationResult}");
                    break;

                case 2:
                    Console.WriteLine("Wybrałeś mnożenie");
                    operationResult = firstNumber * secondNumber;
                    Console.WriteLine($"Wynik dodawania: {operationResult}");
                    break;

                case 3:
                    Console.WriteLine("Wybrałeś dzielenie");
                    if (secondNumber != 0)
                    {
                        operationResult = firstNumber / secondNumber;
                        Console.WriteLine($"Wynik dzielenia: {operationResult}");
                    } else
                    {
                        throw new Exception("Nie można dzielić przez zero!");
                    }
                    break;

                case 4:
                    Console.WriteLine("Wybrałeś potęgowanie. Którą z wpisanych wcześniej liczb chciałbyś mu poddać?");
                    Console.WriteLine(" 1 - Pierwszą \n 2 - Drugą");
                    int numberSelectedToOperation = int.Parse(Console.ReadLine());
                    if (numberSelectedToOperation == 1)
                    {
                        operationResult = Math.Pow(firstNumber, 2);
                        Console.WriteLine($"Wynik potęgowania: {operationResult}");

                    }
                    else if (numberSelectedToOperation == 2)
                    {
                        operationResult = Math.Pow(secondNumber, 2);
                        Console.WriteLine($"Wynik potęgowania: {operationResult}");
                    } else
                    {
                        throw new Exception("Nieprawidłowy wybór!");
                    }
                    break;

                case 5:
                    Console.WriteLine("Wybrałeś pierwiastkowanie");
                    operationResult = firstNumber + secondNumber;
                    Console.WriteLine($"Wynik dodawania: {operationResult}");
                    break;

                case 6:
                    Console.WriteLine("Wybrałeś dodawanie");
                    operationResult = firstNumber + secondNumber;
                    Console.WriteLine($"Wynik dodawania: {operationResult}");
                    break;

                default:
                    throw new Exception("Nieprawidłowy operator!");
            }


            Console.Read();
        }
    }
}
