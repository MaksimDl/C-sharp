// Задача 64: Напишите программу, которая реализует рекурсивный метод вывода всех натуральных числел в промежутке от N до 1.

// N = 5 -> "5, 4, 3, 2, 1"
// N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"

using static System.Console;
Clear();

WriteLine("writes all natural numbers from N to 1. Using recursion");
Write("Input natural naumber N: ");
string nStr = ReadLine();


 //if (!int.TryParse(inArray, out int result))
if (!uint.TryParse(nStr, out uint n))
{
    WriteLine("Only natural number allowed");
    Environment.Exit(0);
}
if (n == 0)
{
    WriteLine("0 isn't natural number either");
    Environment.Exit(0);
}

PrintRowRecursion(n,1);     //prints natural row from n to arg2
WriteLine();

void PrintRowRecursion(uint start ,uint stop)   // print final natural row from start(N) to stop(1)
{
    if (stop == start) 
        Write($" { stop}");
    else
    {
        PrintRowRecursion(start, stop +1);
        Write($" {stop}");
    }
}
