// На входе 2 строки.
// Можно либ из первой получить вторую
// Пример: Tom Marvolo Riddle => I am Lord Voldemort
// Количество пробелов произвольное.

//  пробелов любое количество.
//буквы должны закончиться и там и там


using static System.Console;
Clear();

Write("Case dependent compare? (Type Y or N and hit enter): ");
string param = ReadLine();
bool CaseDependent = true;
if (param[0] == 'Y') { CaseDependent = true; }
else if (param[0] == 'N') CaseDependent = false;
else
{
    WriteLine("Only Y or N supposed; restert!");
    Environment.Exit(0);
}

string str1 = "Tom Marvolo Riddle";
string str2 = "I am Lord Voldemort";

// string str1 = "TOM MARVOLO RIDDLE";
// string str2 = "I AM LORD VOLDEMORT";

//   Write("input 1st string: ");
//   string str1 = ReadLine();
//   WriteLine();
//   Write("input 2nd string: ");
//   string str2 = ReadLine();



if (SortCheckCan(str1, str2, CaseDependent))   // true - case Dependent!
{
    WriteLine("We can make string2 from string1 ! ");
}
else
{
    WriteLine("We CAN NOT make string2 from string1 ! ");
}

////////// methods below //////////////
bool SortCheckCan(string inString1, string inString2, bool CaseDependent)
{
    char[] sorted1 = new char[inString1.Length];
    char[] sorted2 = new char[inString2.Length];
    if (CaseDependent)
    {
        sorted1 = SortString(inString1);
        sorted2 = SortString(inString2);
    }
    else
    {
        string lowerStr1 = inString1.ToLower();
        string lowerStr2 = inString2.ToLower();
        sorted1 = SortString(lowerStr1);
        WriteLine();
        sorted2 = SortString(lowerStr2);

    }

    int i = 0;
    while (i < sorted1.Length)
    {
        if (i >= sorted2.Length) return false;   // сразу false если  выходим за границу массива
        if (sorted1[i] != sorted2[i]) return false;  // сразу false если очередной символ не совпал
        if (i == sorted1.Length - 1 && i == sorted2.Length - 1) return true;  // Не нашли разных и дошли до конца строк
        if (sorted1[i] == Convert.ToChar(" ") && sorted2[i] == Convert.ToChar(" ")) return true; // дошли до пробелов неважно сколько их- все ок, значит символы ранее совпали!

        i++;
    }

    return false;
}


char[] SortString(string inString)
{
    int[] resInt = new int[inString.Length];
    char[] result = new char[inString.Length];
    for (int i = 0; i < inString.Length; i++)  // get ascii code for each letter
    {
        resInt[i] = Convert.ToChar(inString[i]);

    }
    MyLibArray.SingleArrayInt.RegularizeArray(resInt, false); //regularize Ascii code-array

    for (int i = 0; i < inString.Length; i++)  // back to char
    {
        result[i] = Convert.ToChar(resInt[i]);
    }
    return result;
}