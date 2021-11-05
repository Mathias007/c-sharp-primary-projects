
/* Projekt aplikacji rozpoznającej kasy sklepowej wykorzystującej struktury, przygotowany na zajęcia z Podstaw Programowania sem. I WSB (2021/2022).
 * Autor rozwiązania: Mateusz Stawowski (https://github.com/Mathias007).
 * Link do repozytorium zbiorczego: https://github.com/Mathias007/WSB-Task.
 * W ramach projektu wykorzystywane są instrukcje warunkowe, pętle, struktury, tablice oraz listy. 
 * Działanie programu oparte jest w znacznej mierze na odpowiedniej sieci metod, odpowiadających za poszczególne funkcjonalności.
 *  
 * Oczekiwane działanie programu:
 * Sklep ma mieć zdefiniowaną strukturę artykułów. Należy uwzględnić cenę za sztukę i osobno cenę za kg! (✓)
 * Artykułów ma być max 5. zdefiniowanych jako elementy struktury! (✓)
 * Użytkownik (Kasjer) ma mieć możliwość wybierania artykułu (✓), podawania jego ilości (✓), lub wagi (✓).
 * 
 * Powitanie (✓) -> Wybór artykuły (✓) -> Czyszczenie ekranu i zadanie pytania o ilość danego artykułu (✓) 
 * -> Wprowadzenie danych (✓) -> Pytanie czy kasjer chce dodać następny czy ma wydrukować paragon (✓)
 * -> Jeśli następny towar, ponowne czyszczenie ekranu i wybór artykułu (✓) -> powtórzenie dodawania i pytania (✓)
 * -> Jeśli zakończenie to ma pojawić się lista zakupionych towarów wraz z ich ilością oraz ceną, oraz podsumowanie kwoty całego rachunku (✓)
 * -> Opcja zamknij program / Nowy Klient (✓)
 */

using System;
using System.Collections.Generic;

namespace WSB_Task4
{
    class CashRegister
    {
        struct Product
        {
            public int id; // identyfikator (kod) produktu
            public string name; // nazwa produktu
            public double weight; // waga jednostki (kg)
            public double price; // cena jednostkowa (PLN)
            public double price_per_kg; // cena za 1 kg (PLN)
        }

        struct BillPosition
        {
            public string name; // nazwa produktu
            public string unit; // jednostka ilości
            public double quantity; // ilość produktu
            public double price; // cena do zapłaty
        }

        private static string ChooseUnit()
        {
            Console.WriteLine("Jeśli chcesz zarejestrować zakup na wagę, wybierz W, w przeciwnym razie zarejestrujemy zakup na sztuki.");
            return Console.ReadLine().ToUpper() == "W" ? "kg" : "szt";
        }

        private static double CustomizeQuantity(string unit)
        {
            Console.WriteLine($"Ile {unit} zostało zakupionych?");
            return double.Parse(Console.ReadLine().Replace('.', ','));
        }

        private static double CalculatePrice(double productPrice, double productQuantity)
        {
            return Math.Round(productQuantity * productPrice, 2);
        }

        private static void ShowProductInfo(int productId, string productName, double productWeight, double productPrice, double productPricePerKg)
        {
            Console.WriteLine($"Nazwa produktu: {productName} (Kod {productId})");
            Console.WriteLine($"Waga jednostkowa: {productWeight} kg");
            Console.WriteLine($"Cena jednostkowa: {productPrice} zł");
            Console.WriteLine($"Cena za 1 kg: {productPricePerKg}");
        }

        private static BillPosition AddProductToBill(string productName, double productPrice, double productPricePerKg)
        {
            BillPosition addingPosition;

            addingPosition.name = productName;
            addingPosition.unit = ChooseUnit();
            addingPosition.quantity = CustomizeQuantity(addingPosition.unit);
            addingPosition.price = CalculatePrice((addingPosition.unit == "szt" ? productPrice : productPricePerKg), addingPosition.quantity);

            Console.WriteLine($"Cena za {addingPosition.quantity} {addingPosition.unit} produktu {addingPosition.name} wynosi {addingPosition.price} zł.");

            return addingPosition;
        }

        private static BillPosition HandleProductCustomization(int productId, string productName, double productWeight, double productPrice, double productPricePerKg)
        {
            ShowProductInfo(productId, productName, productWeight, productPrice, productPricePerKg);
            return AddProductToBill(productName, productPrice, productPricePerKg);
        }

        private static BillPosition SelectProduct(Product[] productsArray)
        {
            Console.WriteLine("Wybierz produkt z listy poniżej");

            for (int i = 0; i < productsArray.Length; i++)
            {
                Console.WriteLine($"       {i} - {productsArray[i].name.ToUpper()}");
            }

            Console.Write("     Twój wybór: ");
            var choosenProduct = int.Parse(Console.ReadLine());
            Console.WriteLine($"Wybrałeś {productsArray[choosenProduct].name.ToUpper()}. \n");

            Console.Clear();

            return HandleProductCustomization(
                     productsArray[choosenProduct].id,
                     productsArray[choosenProduct].name,
                     productsArray[choosenProduct].weight,
                     productsArray[choosenProduct].price,
                     productsArray[choosenProduct].price_per_kg
                   );
        }

        private static void PrintBill(List<BillPosition> billList, double bill)
        {
            Console.WriteLine("Drukuję rachunek...");
            foreach (BillPosition billSegment in billList)
            {
                int billPosition = 1;
                Console.WriteLine($"{billPosition}. {billSegment.name} - zakupiono {billSegment.quantity} {billSegment.unit}, cena: {billSegment.price} zł.");
                bill += billSegment.price;
                billPosition++;
            }
            Console.WriteLine($"Rachunek osiągnął wysokość: {bill} zł.");
        }

        private static void HandleCashRegister(Product[] productsArray, List<BillPosition> billList, double billToPay)
        {
            Console.WriteLine("Witamy w naszym warzywniaku!");

            bool isBillOpened = true;

            while (isBillOpened)
            {
                billList.Add(SelectProduct(productsArray));

                Console.WriteLine("Czy chcesz kontynuować? Jeżeli tak, naciśnij Y. Jeżeli nie - wybierz dowolny klawisz, aby wydrukować rachunek.");
                Console.Write("    Twoja decyzja: ");
                if (Console.ReadLine().ToUpper() != "Y")
                {
                    Console.Clear();

                    PrintBill(billList, billToPay);

                    Console.WriteLine("Czy chcesz zarejestrować nowego klienta? Jeżeli tak, naciśnij Y. Jeżeli nie - wybierz dowolny klawisz, aby zakończyć pracę programu.");
                    Console.Write("    Twoja decyzja: ");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        Console.Clear();
                        billToPay = 0;
                        billList.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Dziękujemy za skorzystanie z programu.");
                        isBillOpened = !isBillOpened;
                    }
                }
                else
                {
                    Console.Clear();
                }
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            double billToPay = 0;
            var billList = new List<BillPosition>();

            Product apple;
            Product banana;
            Product potato;
            Product tomato;
            Product cucumber;

            apple.id = 1; 
            apple.name = "Jabłko";
            apple.weight = 0.18;
            apple.price = 1;
            apple.price_per_kg = Math.Round(apple.price / apple.weight, 2);

            banana.id = 2;
            banana.name = "Banan";
            banana.weight = 0.22;
            banana.price = 2.5;
            banana.price_per_kg = Math.Round(banana.price / banana.weight, 2);

            potato.id = 3;
            potato.name = "Ziemniak";
            potato.weight = 0.09;
            potato.price = 0.25;
            potato.price_per_kg = Math.Round(potato.price / potato.weight, 2);

            tomato.id = 4;
            tomato.name = "Pomidor";
            tomato.weight = 0.17;
            tomato.price = 2;
            tomato.price_per_kg = Math.Round(tomato.price / tomato.weight, 2);

            cucumber.id = 5;
            cucumber.name = "Ogórek";
            cucumber.weight = 0.25;
            cucumber.price = 2.5;
            cucumber.price_per_kg = Math.Round(cucumber.price / cucumber.weight, 2);

            Product[] productsArray = new Product[5] { apple, banana, potato, tomato, cucumber };

            HandleCashRegister(productsArray, billList, billToPay);           
        }
    }
}
