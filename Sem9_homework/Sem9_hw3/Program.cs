// Задача 68: Напишите программу реализующую метод вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29


using static System.Console;
Clear();

WriteLine("Calculate Akkerman func A(M,N)");
Write("Input M,N (>=0) separated by space: ");

string[] paramStr = ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);

if (paramStr.Length != 2)
{
    WriteLine("Exactly 2 parametters supposed. Restart programm");
    Environment.Exit(0);
}
ulong numM = CheckInput(paramStr[0]);
ulong numN = CheckInput(paramStr[1]);

WriteLine($"A({numM},{numN}) = {Akkerman(numM, numN)}");



//WriteLine($"m = {numM} n = {numN}");


/////////// methods below///////////////

ulong Akkerman(ulong numM, ulong numN)
{
    if (numM == 0) return numN + 1;
    if (numM > 0 && numN == 0)
    {
        return Akkerman(numM - 1, 1);
    }
    if (numM > 0 && numN > 0)
    {
        return Akkerman(numM - 1, Akkerman(numM, numN - 1));
    }
    return 0;
}


ulong CheckInput(string inNumber)
{
    if (!ulong.TryParse(inNumber, out ulong result))
    {
        WriteLine("Only natural number allowed");
        Environment.Exit(0);
    }
    return result;
}

