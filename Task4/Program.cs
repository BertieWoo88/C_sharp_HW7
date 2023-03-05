/* Доп **
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
    {1,1,0,0,0},
    {0,0,1,1,0},
    {0,1,0,0,0},
    {0,0,1,0,0},
    {0,0,0,1,0}
};

int[,] test2 = new int[,]
{
    {0,1,0,1,0,1,0},
    {1,0,1,0,1,0,1},
    {0,1,0,1,0,1,0},
    {1,0,1,0,1,0,1}
// .+.+.+.
// +.+.+.+
// .+.+.+.
// +.+.+.+
};

WriteLine("Первое покаление");
PrintArray(test);
gameCicle(test, 5);
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
            if (inArray[i, j] == 1) Write('*');
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
{
    for (int i = 0; i < k; i++)
    {int[,] copyworld = new int [world.GetLength(0),world.GetLength(1)];
        for (int j = 0; j < world.GetLength(0); j++)
        {
            for (int h = 0; h < world.GetLength(1); h++)
            {
                if ( checkNeighbours(j, h, world)) copyworld[j, h] = 1;
                else copyworld[j, h] = 0;
            }
        }
        world = copyworld;
        //Thread.Sleep(1000);
        //Clear();
        WriteLine($"цикл {i + 1}");
        PrintArray(world);
    }
}


bool checkNeighbours(int row, int column, int[,] array)
{
    //WriteLine($"({row},{column}) ->");
   // int[] variants1 = { -1, -1, -1, 0, 0, 1, 1, 1 };
   // int[] variants2 = { -1, 0, 1, -1, 1, -1, 0, 1 };

    int[,] variants = new int[,] // массив с вариантами поиска координат соседей
    {  { -1, -1, -1, 0, 0, 1, 1, 1 },
       { -1, 0, 1, -1, 1, -1, 0, 1 } 
    };
    int sum = 0;
    int r = 0; int c = 0;
    for (int i = 0; i < variants.GetLength(1); i++)
    {
        r = row + variants[0,i]; c = column + variants[1,i];
        if (r < 0) r = array.GetLength(0) - 1;
        if (c < 0) c = array.GetLength(1) - 1;
        if (r == array.GetLength(0)) r = 0;
        if (c == array.GetLength(1)) c = 0;
        //Write($"({r},{c}) ");
        sum += array[r, c];
    }
    //WriteLine($" Sym={sum}");
    if ( sum== 3 || (sum==2 && array[row,column] ==1)) return true;
    else  return false;
}