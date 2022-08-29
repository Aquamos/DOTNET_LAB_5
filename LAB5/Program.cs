using System;

namespace LAB5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] example = new int[,] 
            {   {1, 0, 0,   7, 0, 0,   0, 2, 8},
                {4, 8, 0,   0, 0, 5,   0, 0, 0},
                {0, 0, 0,   0, 0, 0,   4, 0, 0},

                {3, 4, 0,   0, 0, 1,   7, 0, 0},
                {5, 9, 0,   0, 0, 0,   0, 3, 4},
                {0, 0, 7,   0, 0, 0,   0, 6, 1},

                {0, 0, 3,   0, 0, 9,   0, 4, 0},
                {0, 0, 4,   2, 8, 0,   0, 0, 3},
                {0, 1, 8,   0, 0, 6,   5, 0, 9}
            };

            Sudoku sudoku = new Sudoku(example);
            Caretaker caretaker = new Caretaker(sudoku);

            sudoku.WriteToConsole();

            while (true)
            {
                sudoku.Navigation(caretaker);
                Console.Clear();
                sudoku.WriteToConsole();
            }
        }
    }
}
