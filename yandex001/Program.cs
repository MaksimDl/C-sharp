using System.Text;
using System.IO;
using System;

string path = @"input.txt";
string path2 = @"output.txt";

using (FileStream ifstream = File.OpenRead(path))
{
    byte[] buffer = new byte[ifstream.Length];
    await ifstream.ReadAsync(buffer, 0, buffer.Length);

    Array.Sort(buffer);
    //array contains ascii codes was sorted!
    // WriteLine("Result buffer array: [{0}]", String.Join(",", buffer));

    // find start real element  (not space, not \n, not ascii(13) that  )
    int count_temp = 0;
    int[] sumCol = new int[buffer.Length];
    int[] result = new int[buffer.Length];
    while (count_temp < buffer.Length)
    {
        if (buffer[count_temp] == 10 || buffer[count_temp] == 13 || buffer[count_temp] == 32)
        {
            count_temp++;
        }
        else
        {
            sumCol[0] = 1;
            result[0] = buffer[count_temp];
            break;
        }
    }


    //WriteLine(buffer.Length-count_temp);
    //start counting elements and first add tham to simple arrays (length store in count)
    int count = 0;
    int max = 0;

    if (buffer.Length-count_temp <= 1)  // whe have only one real symbol except spaces and "/n"....
    {
        sumCol[count] = 1;
        max = 1;
        result[count] = Convert.ToChar(buffer[count_temp]);
        
        // WriteLine($"buf[0]= {buffer[0]}");
        // WriteLine($"res = {result[count]}");
    }

    for (int i = count_temp + 1; i < buffer.Length; i++)
    {
        if (buffer[i] == result[count])
        {
            sumCol[count]++;
            if (sumCol[count] > max)
            {
                max = sumCol[count];  // max ammount of same elements
            }

        }
        else
        {
            count++;
            sumCol[count] = 1;
            result[count] = Convert.ToInt32(buffer[i]);
            if (sumCol[count] > max)  // this if works if we met every wymb for only one time
            {
                max = sumCol[count];  // max ammount of same elements
            }
        }
    }
    //form array to output  - 
    // for (int i = 0; i <= count; i++) // output temp
    // {
    //     WriteLine($"[{i}]:{result[i]}({Convert.ToChar(result[i])})   - {sumCol[i]} times");
    // }
    // WriteLine($"max = {max}, count = {count}");

    char[,] resultOutput = new char[max + 2, count + 1];  // array for result

    // fill output 2 dimentional array with #-cols
    for (int i = 0; i <= max; i++)
    {
        for (int j = 0; j <= count; j++)
        {
            if (sumCol[j] >= i + 1)
            {
                resultOutput[i + 1, j] = '#';
            }
            else resultOutput[i + 1, j] = ' ';

        }
    }

    //fill the bottom line - letters
    for (int j = 0; j <= count; j++)
    {
        resultOutput[0, j] = Convert.ToChar(result[j]);
    }

    // Output to console;
    // for (int i = max; i >= 0; i--)
    // {
    //     for (int j = 0; j <= count; j++)
    //     {
    //         Write($"{resultOutput[i, j]} ");
    //     }
    //     WriteLine();
    // }

    // write output to file!
    using (StreamWriter sw = new StreamWriter(path2))
    {
        for (int i = max; i >= 0; i--)
        {
            for (int j = 0; j <= count; j++)
            {
                sw.Write($"{resultOutput[i, j]}");
            }
            sw.WriteLine();
        }
        sw.Close();
    }

}



