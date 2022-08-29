

namespace LAB5
{
    public class Memento
    {
        private int[,] _sudoku;
        public Memento(int[,] sudoku)
        {
            _sudoku = (int[,])sudoku.Clone();
        }
        public int[,] getState()
        {
            return _sudoku;
        }
    }
}
