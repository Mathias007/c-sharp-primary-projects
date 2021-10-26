
/* Podstawy Programowania sem. I WSB (2021/2022) - tablica dwuwymiarowa wypełniana znakami.
 * Autor rozwiązania: Mateusz Stawowski (https://github.com/Mathias007).
 * Link do zbiorczego repozytorium: https://github.com/Mathias007/WSB-Task.
 * W końcowej wersji zastąpiłem zagnieżdżone if/else poprzez użycie ternary operatora (mniej kodu).
 */

using System;

namespace WSB_Task2
{
    class MatrixArray
    {
        static void Main(string[] args)
        {
            string[,] matrixArray = new string[6, 6];

            int matrixWidth = matrixArray.GetLength(0);
            int matrixHeight = matrixArray.GetLength(1);

            if (matrixHeight > 0 && matrixWidth > 0)
            {
                for (int col = 0; col < matrixWidth; col++)
                {
                    for (int row = 0; row < matrixHeight; row++)
                    {
                        matrixArray[col, row] = (row < matrixHeight / 2) 
                            ? (col < matrixWidth / 2 ? "%" : "#") 
                            : (col < matrixWidth / 2 ? "*" : "+");
                        Console.Write(matrixArray[col, row]);
                    }
                    Console.Write("\n");
                }
            }
            Console.ReadLine();
        }
    }
}
