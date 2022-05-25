using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuValidator
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[9, 9];
            Random r = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = r.Next(1, 10);
                }
            }
            if(CheckRows(array) && CheckColumns(array) && FillArray(array))
            {
                Console.WriteLine("Sudoku is Valid");
            }
            else
            {
                Console.WriteLine("Sudoku is not valid");
            }


        }
        static bool CheckRows(int[,] array)
        {
            bool result = true;
            try
            {

                for (int row = 0; row < array.GetLength(0); row++)
                {
                    for (int col = 0; col < array.GetLength(1); col++)
                    {
                        int tempNum = array[row, col];
                        if (tempNum > 0 && tempNum < 10)
                        {
                            for (int i = col + 1; i < array.GetLength(1); i++)
                            {
                                if (tempNum == array[row, i])
                                {
                                    result = false;
                                    return result;
                                }
                            }
                        }
                        else
                        {
                            result = false;
                            return result;
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }
        static bool CheckColumns(int[,] array)
        {
            bool result = true;
            try
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    for (int row = 0; row < array.GetLength(0); row++)
                    {
                        int tempNum = array[row, col];

                        if (tempNum > 0 && tempNum < 10)
                            for (int i = row + 1; i < array.GetLength(0); i++)
                            {
                                if (tempNum == array[i, col])
                                {
                                    result = false;
                                    return result;
                                }
                            }
                        else
                        {
                            result = false;
                            return result;
                        }

                    }
                }
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        static bool FillArray(int[,] array)
        {
            bool result = true;
            int[,] arrayToTest = new int[3, 3];
            int rowLength = arrayToTest.GetLength(0);
            int colLength = arrayToTest.GetLength(1);
            for (int i = 0; i < array.GetLength(0); i += 3)
            {
                for (int j = 0; j < array.GetLength(1); j += 3)
                {
                    for (int row = 0; row < rowLength; row++)
                    {
                        for (int col = 0; col < colLength; col++)
                        {
                            arrayToTest[row, col] = array[row, col];                        
                        }
                    }
                    result = CheckSubGrid(arrayToTest);
                    if (!result)
                    {
                        return result;
                    }
                }
            }

            return result;
        }
        static bool CheckSubGrid(int[,] arrayToTest)
        {
            bool result = true;
            int rowLength = arrayToTest.GetLength(0);
            int colLength = arrayToTest.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    int tempNumb = arrayToTest[i, j];
                    if (tempNumb > 0 && tempNumb < 10)
                    {
                        for (int k = i + 1; k < rowLength; k++)
                        {
                            if (tempNumb == arrayToTest[k, j])
                            {
                                result = false;
                                return result;
                            }
                        }
                    }
                    else
                    {
                        result = false;
                        return result;
                    }
                }
            }
            return result;
        }
    }
}
