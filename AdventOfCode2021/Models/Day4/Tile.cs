namespace AdventOfCode2021.Models
{
    internal class Tile
    {
        public int Value { get; set; }

        public int RowIndex { get; set; } // Don't know if I will use

        public int ColumnIndex { get; set; } // Don't know if I will use

        public Boolean IsMarked { get; set; }

        public Tile(int value, int rowIndex, int columnIndex)
        {
            Value = value;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }
    }
}
