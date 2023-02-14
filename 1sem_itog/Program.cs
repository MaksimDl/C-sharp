// ## Задача:
// Написать программу, которая из имеющегося массива стро формирует массив строк, длинна которых меньше либо 3 символа. 
// Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

using static System.Console;
Clear();

//string[] strings = new string[] { "hello", "2", "world", ":-)"};
WriteLine("Input Several strings, separated by space(s)");
string[] strings = ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] result = new string[strings.Length];

int count = 0;


for (int i = 0; i < strings.Length; i++)
{
    if (strings[i].Length <= 3)
    {
        result[count] = strings[i];
        count += 1;
    }
}


result = result[..^(strings.Length - count)];   // slice excess elements of array

WriteLine("Result array: [{0}]", String.Join(",", result));





