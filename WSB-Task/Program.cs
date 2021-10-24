using System;

namespace WSB_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber;
            double secondNumber;

            Console.WriteLine("Witaj w aplikacji Kalkulator");
            Console.WriteLine("Aby kontynuować, podaj dwie liczby");
            Console.Write("Pierwsza liczba: ");
            firstNumber = double.Parse(Console.ReadLine());

            Console.Write("Druga liczba: ");
            secondNumber = double.Parse(Console.ReadLine());

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
                    Console.WriteLine($"Wybrałeś {calcOperations[choosenOperator].ToUpper()} ");
                    operationResult = firstNumber + secondNumber;
                    Console.WriteLine($"Wynik dodawania: {operationResult}");
                    break;

                case 1:
                    Console.WriteLine($"Wybrałeś {calcOperations[choosenOperator].ToUpper()} ");
                    operationResult = firstNumber - secondNumber;
                    Console.WriteLine($"Wynik odejmowania: {operationResult}");
                    break;

                case 2:
                    Console.WriteLine($"Wybrałeś {calcOperations[choosenOperator].ToUpper()} ");
                    operationResult = firstNumber * secondNumber;
                    Console.WriteLine($"Wynik dodawania: {operationResult}");
                    break;

                case 3:
                    Console.WriteLine($"Wybrałeś {calcOperations[choosenOperator].ToUpper()} ");
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
                    Console.WriteLine($"Wybrałeś {calcOperations[choosenOperator].ToUpper()}. Którą z wpisanych wcześniej liczb chciałbyś poddać podniesieniu do kwadratu? ");
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
                    Console.WriteLine($"Wybrałeś {calcOperations[choosenOperator].ToUpper()}. Którą z wpisanych wcześniej liczb chciałbyś mu poddać w celu uzyskania pierwiastka kwadratowego?");
                    Console.WriteLine(" 1 - Pierwszą \n 2 - Drugą");
                    numberSelectedToOperation = int.Parse(Console.ReadLine());
                    if (numberSelectedToOperation == 1)
                    {
                        operationResult = Math.Sqrt(firstNumber);
                        Console.WriteLine($"Wynik pierwiastkowania: {operationResult}");

                    }
                    else if (numberSelectedToOperation == 2)
                    {
                        operationResult = Math.Sqrt(secondNumber);
                        Console.WriteLine($"Wynik pierwiastkowania: {operationResult}");
                    }
                    else
                    {
                        throw new Exception("Nieprawidłowy wybór!");
                    }
                    break;

                case 6:
                    Console.WriteLine("Wybrałeś obliczanie procentu, jaki pierwsza wpisana liczba stanowi wobec drugiej");
                    operationResult = firstNumber / secondNumber * 100;
                    Console.WriteLine($"Liczba {firstNumber} stanowi {operationResult}% liczby {secondNumber}. Czy chcesz odwrócić wartości?");
                    Console.WriteLine("Naciśnij Y, jeżeli jesteś zainteresowany wykonaniem dodatkowej operacji.");
                    string userReplacementExpectations = Console.ReadLine();

                    if (userReplacementExpectations.ToUpper() == "Y")
                    {
                        operationResult = secondNumber / firstNumber * 100;
                        Console.WriteLine($"Liczba {secondNumber} stanowi {operationResult}% liczby {firstNumber}.");
                    }

                    break;

                default:
                    throw new Exception("Nieprawidłowy operator!");
            }

            Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć pracę kalkulatora");
            Console.Read();
        }
    }
}
