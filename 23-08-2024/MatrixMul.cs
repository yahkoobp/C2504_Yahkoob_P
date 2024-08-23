using System;

class MatrixMultiplication
{
    static void Main()
    {
        // Define the sizes of the matrices
        int rowsA = 2, columnsA = 3;
        int rowsB = 3, columnsB = 2;

        // Initialize the two matrices
        int[,] matrixA = new int[rowsA, columnsA] 
        {
            {1, 2, 3},
            {4, 5, 6}
        };

        int[,] matrixB = new int[rowsB, columnsB] 
        {
            {7, 8},
            {9, 10},
            {11, 12}
        };

        // Initialize the result matrix
        int[,] resultMatrix = new int[rowsA, columnsB];

        // Perform matrix multiplication
        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < columnsB; j++)
            {
                resultMatrix[i, j] = 0; // Initialize the result cell to zero
                for (int k = 0; k < columnsA; k++)
                {
                    resultMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }

        // Display the result
        Console.WriteLine("Matrix A:");
        PrintMatrix(matrixA, rowsA, columnsA);

        Console.WriteLine("Matrix B:");
        PrintMatrix(matrixB, rowsB, columnsB);

        Console.WriteLine("Result of Matrix Multiplication:");
        PrintMatrix(resultMatrix, rowsA, columnsB);
    }

    // Method to print a matrix
    static void PrintMatrix(int[,] matrix, int rows, int columns)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
