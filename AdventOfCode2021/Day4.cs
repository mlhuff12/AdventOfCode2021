using AdventOfCode2021.Helpers.cs;
using AdventOfCode2021.Models;

namespace AdventOfCode2021
{
    internal class Day4
    {
        public static int Process(int part)
        {
            return GetWinningScore(5, part);
        }

        private static int GetWinningScore(int boardSize, int part)
        {
            List<string> inputFile = FileUtil.GetFile("Input\\Day4.txt");

            List<int> balls = inputFile[0].Split(",").Select(int.Parse).ToList();
            inputFile.RemoveAt(0);

            List<Board> boards = new List<Board>();
            int boardNumber = 1;
            for (int i = 0; i < inputFile.Count; i += 6)
            {
                boards.Add(CreateBoard(inputFile.GetRange(i, boardSize + 1), boardNumber, boardSize));
                boardNumber++;
            }

            //PrintBoard(boards, boardSize);
            List<Board> winningBoards = new List<Board>();
            int totalWins = 0;
            foreach (int ball in balls)
            {
                foreach (Board board in boards)
                {
                    if (!board.IsAWinner)
                    {
                        ApplyBallToBoard(ball, board);
                        if (IsBoardAWinner(board, boardSize))
                        {
                            totalWins++;
                            board.IsAWinner = true;
                            board.WinningNumber = ball;
                            board.WinningOrder = totalWins;
                            winningBoards.Add(board);
                        }
                    }
                }
            }

            if (part == 1)
            {
                return CalculateScore(winningBoards[0]);
            }
            else
            {
                return CalculateScore(winningBoards.Last());
            }
        }

        private static Board CreateBoard(List<string> boardFromInput, int boardNumber, int boardSize)
        {
            Board board = new Board(boardNumber, boardSize);
            int rowIndex = 0;
            for (int i = 0; i < boardFromInput.Count; i++)
            {
                if (boardFromInput[i] != String.Empty)
                {
                    List<int> rowArr = boardFromInput[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                    for (int j = 0; j < rowArr.Count; j++)
                    {
                        board.Columns[j].Add(new Tile(rowArr[j], rowIndex, j));

                    }
                    rowIndex++;
                }
            }

            return board;
        }

        private static void PrintBoard(List<Board> boards, int boardSize)
        {
            foreach (Board board in boards)
            {
                for (int i = 0; i < boardSize; i++)
                {
                    for (int j = 0; j < boardSize; j++)
                    {
                        Console.Write(board.Columns[j][i].Value + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        private static void ApplyBallToBoard(int ballNumber, Board board)
        {
            foreach (List<Tile> column in board.Columns)
            {
                foreach (Tile tile in column)
                {
                    if (tile.Value == ballNumber)
                    {
                        tile.IsMarked = true;
                        return;
                    }
                }
            }
        }

        private static bool IsBoardAWinner(Board board, int boardSize)
        {
            // Check Columns
            bool allMarked;
            foreach (List<Tile> column in board.Columns)
            {
                allMarked = true;
                foreach (Tile tile in column)
                {
                    if (!tile.IsMarked)
                    {
                        allMarked = false;
                        break;
                    }
                }
                if (allMarked)
                {
                    return true;
                }
            }

            // Check Rows
            allMarked = true;

            for (int row = 0; row < boardSize; row++)
            {
                allMarked = true;
                for (int col = 0; col < boardSize; col++)
                {
                    Tile tile = board.Columns[col][row];
                    if (!tile.IsMarked)
                    {
                        allMarked = false;
                    }
                }
                
                if (allMarked)
                {
                    return true;
                }
            }
            return false;
        }

        private static int CalculateScore(Board board)
        {
            int unmarkedSum = 0;

            foreach (List<Tile> column in board.Columns)
            {
                foreach (Tile tile in column)
                {
                    if (!tile.IsMarked)
                    {
                        unmarkedSum += tile.Value;
                    }
                }
            }

            return unmarkedSum * board.WinningNumber;
        }

    }
}
