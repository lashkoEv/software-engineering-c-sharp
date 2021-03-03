using System;
using System.Runtime.Remoting.Messaging;

namespace LR1_KPZ
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowGreeting();
            Play();
            ShowParting();
        }

        static void ShowGreeting()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\t+-----------------------------+");
            Console.WriteLine("\t|+---------------------------+|");
            Console.WriteLine("\t||   Welcome to Evolution!   ||");
            Console.WriteLine("\t|+---------------------------+|");
            Console.WriteLine("\t+-----------------------------+");
            ReadKey();
        }

        static void ShowParting()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\t+-----------------------------+");
            Console.WriteLine("\t|+---------------------------+|");
            Console.WriteLine("\t||  See you later! Goodbye!  ||");
            Console.WriteLine("\t|+---------------------------+|");
            Console.WriteLine("\t+-----------------------------+");
            Console.ReadKey();
            System.Environment.Exit(0);
        }

        static ConsoleKey ReadKey()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape) ShowParting();
            return key.Key;
        }

        static void ShowHeadAndTale(int cols) 
        {
            for (int i = 0; i < cols; i++)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");
        }


        static int CorrectInput(int min, int max)
        {
            int correctNum;
            bool flag;
            do
            {
                Console.Write("\tEnter number: ");
                flag = int.TryParse(Console.ReadLine(), out correctNum);
                if (correctNum < min || correctNum > max) { Console.WriteLine($"\tIncorrect! Must be greater than {min} and less than {max}!"); }
            } while (!flag || !(correctNum >= min && correctNum <= max));
            return correctNum;
        }

        static void InitFields(int[,] field, int[,] tmpField, int rows, int cols, int maxCount)
        {
            int tmpCount;
            int tmp;
            Random rnd = new Random();
            do
            {
                tmpCount = maxCount;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        field[i, j] = tmpField[i, j] = 0;
                    }
                }
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                    {
                        if (tmpCount <= 1)
                        {
                            field[i, j] = tmpField[i, j] = tmpCount;
                            tmpCount -= tmpCount;
                            return;
                        }
                        else
                        {
                            tmp = rnd.Next(2);
                            field[i, j] = tmpField[i, j] = tmp;
                            tmpCount -= tmp;
                        }

                    }
            } while (tmpCount > 0);
        }

        static void ShowField(int[,] field, int rows, int cols)
        {
            ShowHeadAndTale(cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    switch (field[i, j])
                    {
                        case 0:
                            {
                                Console.Write("|   ");
                                break;
                            }
                        case 1:
                            {
                                Console.Write("| * ");
                                break;
                            }
                    }
                }
                Console.WriteLine("|");
                ShowHeadAndTale(cols);
            }
        }

        static bool IsDie(int[,] tmpField, int row, int col, int rowsCount, int colsCount)
        {
            if (tmpField[row, col] == 1)
            {
                if (col == 0 && row == 0)
                {
                    if (tmpField[row, col + 1] != 0 &&
                        tmpField[row + 1, col] != 0 &&
                        tmpField[row + 1, col + 1] != 0) return true;
                }
                else
                {
                    if (col == colsCount && row == rowsCount)
                    {
                        if (tmpField[row, col - 1] != 0 &&
                            tmpField[row - 1, col] != 0 &&
                            tmpField[row - 1, col - 1] != 0) return true;
                    }
                    else
                    {
                        if (row == 0 && col != colsCount)
                        {
                            if (tmpField[row, col + 1] != 0 &&
                                tmpField[row, col - 1] != 0 &&
                                tmpField[row + 1, col] != 0 &&
                                tmpField[row + 1, col - 1] != 0 &&
                                tmpField[row + 1, col + 1] != 0) return true;
                        }
                        else
                        {
                            if (row == 0 && col == colsCount)
                            {
                                if (tmpField[row, col - 1] != 0 &&
                                    tmpField[row + 1, col] != 0 &&
                                    tmpField[row + 1, col - 1] != 0) return true;
                            }
                            else
                            {
                                if (row == rowsCount && col == 0)
                                {
                                    if (tmpField[row, col + 1] != 0 &&
                                        tmpField[row - 1, col] != 0 &&
                                        tmpField[row - 1, col + 1] != 0) return true;

                                }
                                else
                                {
                                    if (row == rowsCount && col != colsCount)
                                    {
                                        if (tmpField[row, col + 1] != 0 &&
                                            tmpField[row, col - 1] != 0 &&
                                            tmpField[row - 1, col] != 0 &&
                                            tmpField[row - 1, col - 1] != 0 &&
                                            tmpField[row - 1, col + 1] != 0) return true;
                                    }
                                    else
                                    {
                                        if (row != 0 && col == 0)
                                        {
                                            if (tmpField[row - 1, col] != 0 &&
                                                tmpField[row + 1, col] != 0 &&
                                                tmpField[row, col + 1] != 0 &&
                                                tmpField[row + 1, col + 1] != 0 &&
                                                tmpField[row - 1, col + 1] != 0) return true;
                                        }
                                        else
                                        {
                                            if (row != 0 && col == colsCount)
                                            {
                                                if (tmpField[row - 1, col] != 0 &&
                                                    tmpField[row + 1, col] != 0 &&
                                                    tmpField[row, col - 1] != 0 &&
                                                    tmpField[row - 1, col - 1] != 0 &&
                                                    tmpField[row + 1, col - 1] != 0) return true;
                                            }
                                            else
                                            {
                                                if (tmpField[row - 1, col] != 0 &&
                                                    tmpField[row + 1, col] != 0 &&
                                                    tmpField[row, col + 1] != 0 &&
                                                    tmpField[row, col - 1] != 0 &&
                                                    tmpField[row + 1, col - 1] != 0 &&
                                                    tmpField[row + 1, col + 1] != 0 &&
                                                    tmpField[row - 1, col - 1] != 0 &&
                                                    tmpField[row - 1, col + 1] != 0) return true;




                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        static bool IsBorn(int[,] tmpField, int row, int col, int rowsCount, int colsCount)
        {
            int count = 0;
            if (tmpField[row, col] == 0)
            {
                if (col == 0 && row == 0)
                {
                    count += tmpField[row, col + 1];
                    count += tmpField[row + 1, col];
                    count += tmpField[row + 1, col + 1];
                }
                else
                {
                    if (col == colsCount && row == rowsCount)
                    {
                        count += tmpField[row, col - 1];
                        count += tmpField[row - 1, col];
                        count += tmpField[row - 1, col - 1];
                    }
                    else
                    {
                        if (row == 0 && col != colsCount)
                        {
                            count += tmpField[row, col - 1];
                            count += tmpField[row, col + 1];
                            count += tmpField[row + 1, col];
                            count += tmpField[row + 1, col - 1];
                            count += tmpField[row + 1, col + 1];
                        }
                        else
                        {
                            if (row == 0 && col == colsCount)
                            {
                                count += tmpField[row, col - 1];
                                count += tmpField[row + 1, col];
                                count += tmpField[row + 1, col - 1];
                            }
                            else
                            {
                                if (row == rowsCount && col == 0)
                                {
                                    count += tmpField[row, col + 1];
                                    count += tmpField[row - 1, col];
                                    count += tmpField[row - 1, col + 1];
                                }
                                else
                                {
                                    if (row == rowsCount && col != colsCount)
                                    {
                                        count += tmpField[row, col - 1];
                                        count += tmpField[row, col + 1];
                                        count += tmpField[row - 1, col];
                                        count += tmpField[row - 1, col - 1];
                                        count += tmpField[row - 1, col + 1];
                                    }
                                    else
                                    {
                                        if (row != 0 && col == 0)
                                        {
                                            count += tmpField[row, col + 1];
                                            count += tmpField[row + 1, col];
                                            count += tmpField[row - 1, col];
                                            count += tmpField[row + 1, col + 1];
                                            count += tmpField[row - 1, col + 1];
                                        }
                                        else
                                        {
                                            if (row != 0 && col == colsCount)
                                            {
                                                count += tmpField[row, col - 1];
                                                count += tmpField[row + 1, col];
                                                count += tmpField[row - 1, col];
                                                count += tmpField[row - 1, col - 1];
                                                count += tmpField[row + 1, col - 1];
                                            }
                                            else
                                            {
                                                count += tmpField[row, col - 1];
                                                count += tmpField[row, col + 1];
                                                count += tmpField[row + 1, col];
                                                count += tmpField[row - 1, col];
                                                count += tmpField[row + 1, col - 1];
                                                count += tmpField[row + 1, col + 1];
                                                count += tmpField[row - 1, col - 1];
                                                count += tmpField[row - 1, col + 1];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (count >= 2) return true;
            }
            return false;
        }

        static void Change(int[,] field, int[,] tmpField, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = tmpField[i, j];
                }
            }
        }

        static void Play()
        {
            bool answerToExit;
            do
            {
                answerToExit = false;
                int rows, cols, cells;
                Console.Clear();
                Console.WriteLine("Enter the number of rows of the playing field: ");
                rows = CorrectInput(1, 20);
                Console.WriteLine("Enter the number of columns of the playing field: ");
                cols = CorrectInput(1, 20);
                int maxCount = rows * cols;
                Console.WriteLine("Enter the number of cells: ");
                cells = CorrectInput(1, maxCount);
                int[,] field = new int[rows, cols];
                int[,] tmpField = new int[rows, cols];
                InitFields(field, tmpField, rows, cols, cells);

                bool answerToContinue = false;
                do
                {
                    answerToContinue = false;
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            if (IsBorn(field, i, j, rows - 1, cols - 1))
                            {
                                tmpField[i, j]++;
                            }
                            else
                            {
                                if (IsDie(field, i, j, rows - 1, cols - 1))
                                {
                                    tmpField[i, j] = 0;
                                }
                            }
                        }
                    }

                    Console.Clear();
                    Console.Clear();
                    Console.WriteLine("\n\tCreated field:");
                    ShowField(tmpField, rows, cols);
                    ReadKey();

                    Console.Clear();
                    Console.Write("Maybe go around the field again? Press 'Space' ");
                    if (ReadKey() == ConsoleKey.Spacebar)
                    {
                        answerToContinue = true;
                        Change(field, tmpField, rows, cols);
                    }
                } while (answerToContinue);

                Console.Clear();
                Console.Write("Do you want to play again? Press 'y': ");
                if (ReadKey() == ConsoleKey.Y)
                {
                    answerToExit = true;
                }
            } while (answerToExit);
        }
    }
}

