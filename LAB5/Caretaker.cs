

namespace LAB5
{
    public class Caretaker
    {
        private List<Memento> _mementos = new List<Memento>();
        private Sudoku _sudoku;
        public Caretaker(Sudoku sudoku)
        {
            _sudoku = sudoku;
        }
        public void MakeBackup()
        {
            _mementos.Add(_sudoku.Save());
        }
        public void Undo()
        {
            if (_mementos.Count == 0)
                return;

            var memento = _mementos.Last();
            _mementos.Remove(memento);
            _sudoku.Restore(memento);

        }
    }
}
