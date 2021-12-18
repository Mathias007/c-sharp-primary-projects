/* Podstawy Programowania sem. I WSB (2021/2022) - wyświetlanie wyniku dla drzewa z wyrażenia lambda.
 * Autor rozwiązania: Mateusz Stawowski (https://github.com/Mathias007).
 * Link do zbiorczego repozytorium: https://github.com/Mathias007/WSB-Task.
 */

using System;
using System.Linq.Expressions;

namespace Lambda
{
    class Lambda
    {
        static void Main(string[] args)
        {
            // input
            var a = 10;
            Expression<Func<int>> sum = () => 1 + a + 3 + 4;

            // solution
            var func = sum.Compile();
            var result = func();

            // output
            Console.WriteLine($"Wynik dla drzewa z wyrażenia lambda: {result}");
        }
    }
}
