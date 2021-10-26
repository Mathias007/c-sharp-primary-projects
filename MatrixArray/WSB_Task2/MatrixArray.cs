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
                        if (row < matrixHeight / 2)
                        {
                            if (col < matrixWidth / 2)
                            {
                                matrixArray[col, row] = "%";
                            }
                            else
                            {
                                matrixArray[col, row] = "#";
                            }
                        }
                        else
                        {
                            if (col < matrixWidth / 2)
                            {
                                matrixArray[col, row] = "*";
                            }
                            else
                            {
                                matrixArray[col, row] = "+";
                            }
                        }
                        Console.Write(matrixArray[col, row]);
                    }
                    Console.Write("\n");
                }
            }
            Console.ReadLine();
        }
    }
}
