using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB5
{
    public class Sudoku
    {
        private int[,] _sudoku;
        private int _posX = 0;
        private int _posY = 0;
        public Sudoku(int[,] _sudoku)
        {
            this._sudoku = _sudoku;
        }
        public void Navigation(Caretaker caretaker)
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (_posY != 0)
                            _posX = _posX - 1;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (_posY != 8)
                            _posX = _posX + 1;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        if (_posX != 0)
                            _posY = _posY - 1;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        if (_posY != 8)
                            _posY = _posY + 1;
                        break;
                    }
                case ConsoleKey.Backspace:
                    {
                        caretaker.Undo();
                        break;
                    }
                default:
                    {
                        if (key.KeyChar >= 48 && key.KeyChar <= 57)
                        {
                            caretaker.MakeBackup();
                            _sudoku[_posX, _posY] = int.Parse(key.KeyChar.ToString());
                        }
                        break;
                    }
            }
        }
        public void WriteToConsole()
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (_sudoku[y, x] == 0)
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    else if (GetRow(y).Where(i => i == _sudoku[y, x]).Count() > 1 || 
                             GetColumn(x).Where(i => i == _sudoku[y, x]).Count() > 1 || 
                             GetBlock(y, x).Where(i => i == _sudoku[y, x]).Count() > 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    if (x == _posY && y == _posX)
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(_sudoku[y, x] + " ");
                    Console.ResetColor();

                    if ((x + 1) % 3 == 0) 
                        Console.Write(" ");
                }

                Console.WriteLine();
                if ((y + 1) % 3 == 0) 
                    Console.WriteLine();
            }
        }
        private IEnumerable<int> GetRow(int rowIndex)
        {
            List<int> row = new List<int>();

            for (int x = 0; x < 9; x++)
            {
                if (_sudoku[rowIndex, x] != 0)
                    row.Add(_sudoku[rowIndex, x]);
            }

            return row;
        }
        private IEnumerable<int> GetColumn(int columnIndex)
        {
            List<int> column = new List<int>();

            for (int y = 0; y < 9; y++)
            {
                if (_sudoku[y, columnIndex] != 0)
                    column.Add(_sudoku[y, columnIndex]);
            }

            return column;
        }
        private IEnumerable<int> GetBlock(int x, int y)
        {
            int startX = 3 * (x / 3);
            int startY = 3 * (y / 3);
            List<int> block = new List<int>();

            for (int yPos = 0; yPos < 3; yPos++)
            {
                for (int xPos = 0; xPos < 3; xPos++)
                {
                    if (_sudoku[yPos + startY, xPos + startX] != 0)
                        block.Add(_sudoku[yPos + startY, xPos + startX]);
                }
            }

            return block;
        }
        public Memento Save()
        {
            return new Memento(_sudoku);
        }
        public void Restore(Memento memento)
        {
            _sudoku = memento.getState();
        }
    }
}