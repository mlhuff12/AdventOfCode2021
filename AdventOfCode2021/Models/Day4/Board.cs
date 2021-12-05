namespace AdventOfCode2021.Models
{
    internal class Board
    {
        public int BoardNumber { get; set; }

        public List<List<Tile>> Columns { get; set; }

        public Boolean IsAWinner { get; set; }

        public int WinningNumber { get; set; } // Don't know if I will use

        public int WinningOrder { get; set; } // Don't know if I will use

        public Board(int boardNumber, int boardSize)
        {
            BoardNumber = boardNumber;
            Columns = new List<List<Tile>>();

            for (int i = 0; i < boardSize; i++)
            { 
                Columns.Add(new List<Tile>());
            }
        }
    }
}
