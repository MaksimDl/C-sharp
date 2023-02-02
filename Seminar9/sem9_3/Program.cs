// **Задача 67:** Напишите программу, которая будет принимать на вход число и возвращать сумму его цифр.
// 453 -> 12
// 45 -> 9

using static System.Console;
Clear();

int num = 453;
Write($"Sum of digits of {num} = ");
WriteLine(GetSumDig(num));

int GetSumDig(int num)
{
    if (num/10 ==0) return num%10;
    else
    {
        return  num%10 + GetSumDig(num/10)  ;
    }
       
}