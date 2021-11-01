using System;

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
            // public double energy; // wartość energetyczna 1 sztuki (kcal)
        }

        private static double CalculatePrice(double productPrice, double productQuantity)
        {
            return productQuantity * productPrice;
        }

        private static void ShowProductInfo(int productId, string productName, double productWeight, double productPrice, double productPricePerKg)
        {
            Console.WriteLine($"Nazwa produktu: {productName} (Kod {productId})");
            Console.WriteLine($"Waga jednostkowa: {productWeight} kg");
            Console.WriteLine($"Cena jednostkowa: {productPrice} zł");
            Console.WriteLine($"Cena za 1 kg: {productPricePerKg}");
        }

        private static double CustomizeProductQuantity(double productPrice, double productPricePerKg)
        {
            Console.WriteLine("Jeśli chcesz zarejestrować zakup na kilogramy, wybierz K, w przeciwnym razie zarejestrujemy zakup na sztuki.");
            string choosenValue = Console.ReadLine().ToUpper() == "K" ? "kg" : "szt";
            Console.WriteLine($"Ile {choosenValue} zostało zakupionych?");
            double productQuantity = double.Parse(Console.ReadLine().Replace('.', ','));

            double finalProductPrice = CalculatePrice((choosenValue == "szt" ? productPrice : productPricePerKg), productQuantity);

            Console.WriteLine($"Cena za {productQuantity} {choosenValue} wybranego produktu to {finalProductPrice} zł.");

            return finalProductPrice;
        }

        public static double HandleProductCustomization(int productId, string productName, double productWeight, double productPrice, double productPricePerKg)
        {
            ShowProductInfo(productId, productName, productWeight, productPrice, productPricePerKg);
            return CustomizeProductQuantity(productPrice, productPricePerKg);
        }


        static void Main(string[] args)
        {
            double bill = 0;

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

            Console.WriteLine("Witamy w naszym warzywniaku! Wybierz produkt z listy poniżej");

            bool isBillOpened = true;

            while (isBillOpened)
            {

                for (int i = 0; i < productsArray.Length; i++)
                {
                    Console.WriteLine($"       {i} - {productsArray[i].name.ToUpper()}");
                }

                Console.Write("     Twój wybór: ");
                var choosenProduct = int.Parse(Console.ReadLine());
                Console.WriteLine($"Wybrałeś {productsArray[choosenProduct].name.ToUpper()}. \n");

                bill += HandleProductCustomization(
                    productsArray[choosenProduct].id,
                    productsArray[choosenProduct].name,
                    productsArray[choosenProduct].weight,
                    productsArray[choosenProduct].price,
                    productsArray[choosenProduct].price_per_kg
                );

                Console.WriteLine("Czy chcesz kontynuować? Jeżeli tak, naciśnij Y. Jeżeli nie - wybierz dowolny klawisz, aby wydrukować rachunek.");
                Console.Write("    Twoja decyzja: ");
                if (Console.ReadLine().ToUpper() != "Y")
                {
                    Console.WriteLine($"Rachunek osiągnął wysokość: {bill} zł.");
                    Console.WriteLine("Dziękujemy za skorzystanie z programu.");
                    isBillOpened = !isBillOpened;
                }
            }
                Console.ReadKey();
        }
    }
}
