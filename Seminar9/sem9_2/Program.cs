// **Задача 65:** Задайте значения M и N. Напишите программу, которая выведет все натуральные числа в промежутке от M до N.

// M = 1; N = 5. -> "1, 2, 3, 4, 5"
// M = 4; N = 8. -> "4, 5, 6, 7, 8"

using static System.Console;
Clear();

int m = 10;
int n = 15;
PrintNumbers(m, n);
WriteLine();

string str = PrintNumbersStr(m, n);
Write(str);
WriteLine();

void PrintNumbers(int numM, int numN)
{
    if (numM == numN) Write($"{numN} ");
    else
    {
        if (numM < numN)
        {
            PrintNumbers(numM, numN - 1);
            Write($"{numN} ");
        }
        else
        {
            PrintNumbers(numN, numM - 1);
            Write($"{numM} ");
        }
    }
}

string PrintNumbersStr(int numM, int numN)
{
    if (numM == numN) return numN.ToString();
    else
    {   
         if (numM < numN)
        {
            return $"{PrintNumbersStr(numM, numN - 1)}, {numN}";
        }
        else
        {
            return $"{PrintNumbersStr(numN, numM - 1)}, {numM}";
        }
        //           else return $"{GetNumbers(num-1)}, {num}";
    }
}