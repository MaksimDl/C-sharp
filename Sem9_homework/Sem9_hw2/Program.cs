// Задача 66: Напишите программу, которая реализует рекурсивный метод нахождения суммы натуральных элементов в промежутке от M до N.

// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30

using static System.Console;
Clear();

WriteLine("writes summ of all natural numbers betwee M and N. Using recursion");
Write("Input natural numbers M and N, separated by space: ");
string[] paramStr = ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);

if (paramStr.Length != 2)
{
    WriteLine("Exactly 2 parametters supposed. Restart programm");
    Environment.Exit(0);
}

uint numM = CheckInput(paramStr[0]);
uint numN = CheckInput(paramStr[1]);
//WriteLine($"m ={numM}, n = {numN} ");
WriteLine($"summ = {SumRowRecursion(numM, numN)}");


uint SumRowRecursion(uint inNumM, uint inNumN)   // print final natural row from start(N) to stop(1)
{
    //add check  N<M N>M
    
    if (inNumN == inNumM)
    {
        return inNumM;
    }
    else
    {
        if (inNumM > inNumN)
        {
            return inNumN + SumRowRecursion(inNumM, inNumN + 1);
        }
        else
        {
            return inNumM + SumRowRecursion(inNumM + 1, inNumN);
        }
    }


}


uint CheckInput(string inNumber)
{
    if (!uint.TryParse(inNumber, out uint result))
    {
        WriteLine("Only natural number allowed");
        Environment.Exit(0);
    }
    if (result == 0)
    {
        WriteLine("0 isn't natural number either");
        Environment.Exit(0);
    }
    return result;
}