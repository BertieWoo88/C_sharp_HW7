/* Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

m = 3, n = 4.

0,5 7 -2 -0,2

1 -3,3 8 -9,9

8 7,8 -7,1 9 */


using System;
using static System.Console;
Clear();

int rows = asknum("количество строк массива");
int column = asknum("количество столбцов массива");
double[,] mass = GetArray(rows, column, -10, 10);
PrintArray(mass);

double[,] GetArray(int m, int n, int minValue, int maxValue)
{
    double[,] result = new double[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            //result[i, j] = Convert.ToDouble(new Random().Next(-100, 101)) / 10;
            result[i, j] = Math.Round(new Random().NextDouble()+new Random().Next(minValue, maxValue + 1), 1);

        }
    }
    return result;
}

void PrintArray(double[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Write($"{inArray[i, j]} ");
        }
        WriteLine();
    }
}

int asknum(string name)
{
    Write($"Введите {name}: ");
    int n = int.Parse(ReadLine()!);
    return n;
}