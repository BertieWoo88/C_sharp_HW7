﻿/* Доп **
Игра «Жизнь» была придумана английским математиком Джоном Конвейем в 1970 году.
Впервые описание этой игры опубликовано в октябрьском выпуске (1970) журнала Scientic American,
в рубрике «Математические игры» Мартина Гарднера.

Место действия этой игры – «вселенная» – это размеченная на клетки поверхность.
Каждая клетка на этой поверхности может находиться в двух состояниях: быть живой или быть мертвой.
Клетка имеет восемь соседей. Распределение живых клеток в начале игры называется первым поколением.
Каждое следующее поколение рассчитывается на основе предыдущего по таким правилам:

1)пустая(мертвая) клетка с ровно тремя живыми клетками-соседями оживает;
2)если у живой клетки есть две или три живые соседки, то эта клетка продолжает жить;
в противном случае (если соседок меньше двух или больше трех)
клетка умирает(от «одиночества» или от «перенаселенности»).
В этой задаче рассматривается игра «Жизнь» на торе.
Представим себе прямоугольник размером n строк на m столбцов.
Для того, чтобы превратить его в тор мысленно «склеим» его верхнюю сторону с нижней, а левую с правой.

Таким образом, у каждой клетки, даже если она раньше находилась на границе прямоугольника,
теперь есть ровно восемь соседей.

Ваша задача состоит в том, чтобы найти конфигурацию клеток, которая будет через k поколений от заданного.

n m k(4 ≤ n, m ≤ 100; 0 ≤ k ≤ 100).
5 5 1
++...
..++.
.+...
..+..
...+.

.+.++
+.+..
.+.+.
..+..
.++..

5 5 5
++...
..++.
.+...
..+..
...+.

.+++.
.+...
.+...
..++.
.....

4 7 5
.+.+.+.
+.+.+.+
.+.+.+.
+.+.+.+

.......
.......
.......
........*/


using System;
using static System.Console;
Clear();

//int rows = asknum("количество строк массива");
//int column = asknum("количество столбцов массива");
//int[,] mass = GetArray(rows, column);
int[,] test = new int[,]
{
    {1,0,1,0,1},
    {0,1,0,1,0},
    {1,0,1,0,1},
    {0,1,0,1,0},
    {1,0,1,0,1}
};

PrintArray(test);
gameCicle(test, 10);
int[,] GetArray(int m, int n)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Write($" Введите [{i},{j}] элемент если 1 - жив, если 0 - мертв: ");
            result[i, j] = int.Parse(ReadLine()!);

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
            if (inArray[i, j]==1) Write('*');
            else Write('.');
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

void gameCicle(int[,] world, int k)
{   int[,] copyworld = world;
    for (int i = 0; i < k; i++)
    {
        for (int j = 0; j < world.GetLength(0); j++)
        {
            for (int h = 0; h < world.GetLength(1); h++)
            {
                if (checkNeibors(j, h, world)) copyworld[j,h] = 1;
                else copyworld[j,h] = 0;
            }
        }
    world = copyworld;
    WriteLine($"цикл {i+1}");
    PrintArray(world);
    }
}


bool checkNeibors(int row, int column, int[,] array)
{
    int[] variants1 = { -1, -1, 1, -1, 1, 0, 0, 1 };
    int[] variants2 = { -1, 0, 1, 1, 0, 1, -1, -1 };
    int sum = 0;
    int r = 0; int c = 0;
    for (int i = 0; i < variants1.Length; i++)
    {
        r = row + variants1[i]; c = column + variants2[i];
        if (r < 0) r = array.GetLength(0) - 1;
        if (c < 0) c = array.GetLength(1) - 1;
        if (r == array.GetLength(0)) r = 0;
        if (c == array.GetLength(1)) c = 0;
        sum += array[r, c];
    }
    if (sum > 1 && sum <= 3) return true;
    else return false;
}