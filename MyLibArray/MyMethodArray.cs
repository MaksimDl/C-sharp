namespace MyLibArray;
using static System.Console;

public class MultidimensionalArray
{
    ///<summary>
    /// generate random filled double array with (size = unsigned int size M and N (array[m,n]),  begin of array,  end of array)
    /// check for size to be more than 0. in case of false - terminate the programm
    ///</summary>
    public static double[,] GenerateDoubleMNArray(uint sizeM, uint sizeN, double BeginArr, double EndArr)
    {
        if (sizeM == 0 || sizeN == 0)
        {
            WriteLine("Size can't be zero. Now terminate all progr");
            Environment.Exit(0);
        }

        double[,] result = new double[sizeM, sizeN];
        Random rnd = new Random();
        for (int i = 0; i < sizeM; i++)
        {
            for (int j = 0; j < sizeN; j++)
            {
                result[i, j] = BeginArr + rnd.NextDouble() * (EndArr - BeginArr);
            }
        }
        return result;
    }


    ///<summary>
    /// generate random filled double array with (size = unsigned int size M and N (array[m,n]),  begin of array,  end of array, int accuracy)
    /// Accuracy = number of digits, after dot (0.xxx)
    /// check for size to be more than 0. in case of false - terminate the programm
    ///</summary>
    public static double[,] GenerateDoubleMNArray(uint sizeM, uint sizeN, double BeginArr, double EndArr, int accuracy)
    {
        if (sizeM == 0 || sizeN == 0)
        {
            WriteLine("Size can't be zero. Now terminate all progr");
            Environment.Exit(0);
        }

        double[,] result = new double[sizeM, sizeN];
        Random rnd = new Random();
        for (int i = 0; i < sizeM; i++)
        {
            for (int j = 0; j < sizeN; j++)
            {
                result[i, j] = Math.Round((BeginArr + rnd.NextDouble() * (EndArr - BeginArr)), accuracy);
            }
        }
        return result;
    }

    ///<summary>
    /// print double[,] array.
    /// 
    ///</summary>

    public static void PrintDoubleMNArray(double[,] inArray)
    {
        for (int i = 0; i < inArray.GetLength(0); i++)
        {
            for (int j = 0; j < inArray.GetLength(1); j++)
            {
                Write($" {inArray[i, j]}");
                //Write($" {string.Format("{0:f4}", inArray[i,j])}"); 
            }
            WriteLine();
        }
    }



}


public class IntMultiDimentionalArray
{
    ///<summary>
    /// generate random filled INT array with (size = unsigned int size M and N (array[m,n]),  begin of array,  end of array)
    /// check for size to be more than 0. in case of false - terminate the programm
    ///</summary>
    public static int[,] GenerateIntMNArray(uint sizeM, uint sizeN, int BeginArr, int EndArr)
    {
        if (sizeM == 0 || sizeN == 0)
        {
            WriteLine("Size can't be zero. Now terminate all progr");
            Environment.Exit(0);
        }

        int[,] result = new int[sizeM, sizeN];
        Random rnd = new Random();
        for (int i = 0; i < sizeM; i++)
        {
            for (int j = 0; j < sizeN; j++)
            {
                result[i, j] = rnd.Next(BeginArr, EndArr + 1);
            }
        }
        return result;
    }

    ///<summary>
    /// print int[,] array.
    /// 
    ///</summary>
    public static void PrintIntMNArray(int[,] inArray)
    {
        for (int i = 0; i < inArray.GetLength(0); i++)
        {
            for (int j = 0; j < inArray.GetLength(1); j++)
            {
                Write($" {inArray[i, j]}");
                //Write($" {string.Format("{0:f4}", inArray[i,j])}"); 
            }
            WriteLine();
        }
    }

    //<summary>
    /// regularize row of Two-dimension array
    /// regularize by increase(parameter true) or decrease(false)
    /// int row param - which row we want to regularize
    /// if arg row == -1 - regularize all rows
    ///</summary>
    public static void RegulaRizeArrayRowX(int[,] inArray, int row, bool increase)
    {
        if (row == -1)
        {
            for (row = 0; row < inArray.GetLength(0); row++)
            {
                for (int i = 0; i < inArray.GetLength(1); i++)
                {
                    for (int j = 1; j < inArray.GetLength(1) - i; j++)
                    {
                        if (inArray[row, j - 1] < inArray[row, j] && !increase)
                        {
                            int temp = inArray[row, j];
                            inArray[row, j] = inArray[row, j - 1];
                            inArray[row, j - 1] = temp;
                        }
                        if (inArray[row, j - 1] > inArray[row, j] && increase)
                        {
                            int temp = inArray[row, j];
                            inArray[row, j] = inArray[row, j - 1];
                            inArray[row, j - 1] = temp;
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < inArray.GetLength(1); i++)
            {
                for (int j = 1; j < inArray.GetLength(1) - i; j++)
                {
                    if (inArray[row, j - 1] < inArray[row, j] && !increase)
                    {
                        int temp = inArray[row, j];
                        inArray[row, j] = inArray[row, j - 1];
                        inArray[row, j - 1] = temp;
                    }
                    if (inArray[row, j - 1] > inArray[row, j] && increase)
                    {
                        int temp = inArray[row, j];
                        inArray[row, j] = inArray[row, j - 1];
                        inArray[row, j - 1] = temp;
                    }
                }
            }
        }
    }


    //<summary>
    /// regularize row of Two-dimension array
    /// regularize by increase(parameter true) or decrease(false)
    /// int call param - which col we want to regularize
    //  if arg col == -1 - regularize all cols
    ///</summary>
    public static void RegulaRizeArrayColX(int[,] inArray, int col, bool increase)
    {
        if (col == -1)
        {
            for (col = 0; col < inArray.GetLength(1); col++)
            {
                for (int i = 0; i < inArray.GetLength(0); i++)
                {
                    for (int j = 1; j < inArray.GetLength(0) - i; j++)
                    {
                        if (inArray[j - 1, col] < inArray[j, col] && !increase)
                        {
                            int temp = inArray[j, col];
                            inArray[j, col] = inArray[j - 1, col];
                            inArray[j - 1, col] = temp;
                        }
                        if (inArray[j - 1, col] > inArray[j, col] && increase)
                        {
                            int temp = inArray[j, col];
                            inArray[j, col] = inArray[j - 1, col];
                            inArray[j - 1, col] = temp;
                        }
                    }
                }
            }
        }
    }


    //<summary>
    /// regularize row of Two-dimension array
    /// regularize by increase(parameter true) or decrease(false)
    /// int call param - which col we want to regularize
    //  if arg col == -1 - regularize all cols
    ///</summary>
    public static int[,] CopyMNArray(int[,] inArray)
    {
        int[,] result = new int[inArray.GetLength(0), inArray.GetLength(1)];
        for (int i = 0; i < inArray.GetLength(0); i++)
        {
            for (int j = 0; j < inArray.GetLength(0); j++)
            {
                result[i, j] = inArray[i, j];
            }
        }
        return result;
    }

}


public class SingleArrayInt
{
    //<summary>
    /// regularize single array
    /// increase or decrease
    ///</summary>
    public static void RegularizeArray(int[] inArray, bool increase)
    {
        for (int i = 0; i < inArray.Length; i++)
        {
            for (int j = 1; j < inArray.Length - i; j++)
            {
                if (inArray[j - 1] < inArray[j] && !increase)
                {
                    int temp = inArray[j];
                    inArray[j] = inArray[j - 1];
                    inArray[j - 1] = temp;
                }
                if (inArray[j - 1] > inArray[j] && increase)
                {
                    int temp = inArray[j];
                    inArray[j] = inArray[j - 1];
                    inArray[j - 1] = temp;
                }
            }
        }
    }



}