/* Задача 50. Напишите программу, которая на вход принимает позиции элемента
 в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

Например, задан массив:

1 4 7 2

5 9 2 3

8 4 2 4

17 -> такого числа в массиве нет */

using System;
using static System.Console;
Clear();

int rows = asknum("количество строк массива");
int column = asknum("количество столбцов массива");
int[,] mass = GetArray(rows, column, 0, 50);
PrintArray(mass);
WriteLine();
int frows = asknum("строку нужного элемента массива");
int fcolumn = asknum("столбец нужного элемента массива");
checkElement(mass, frows, fcolumn);
int b = checkElement(mass, 1,1);
WriteLine(b);
int checkElement(int[,] array, int row, int column) // Считаем что пользователь считает индекс массива с 1
{   
    int element = 0;
    /*if (row >= array.GetLength(0) || column >= array.GetLength(0))  условие если первый индекс для пользователя 0 */
    if (row > array.GetLength(0) || column > array.GetLength(0))
    {
        WriteLine($"Элемента ({row},{column} нет в массиве )");
    }    
    else 
    {
        WriteLine($"Элемент [{row},{column}] в массиве ->{array[row-1, column-1]} ");
        element = array[row-1, column-1];
    }
    return element;
}

int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintArray(int[,] inArray)
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
