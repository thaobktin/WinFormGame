using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace FallingBlocksCEP
{
    public sealed class OccupiedMap // singleton
    {
        static readonly OccupiedMap instance = new OccupiedMap(FallingBlocksGame.NumRows, FallingBlocksGame.NumCols + 1);
        private int numRows;
        private int numCols;
        public bool[,] Map { get; set; }

        public static OccupiedMap Instance
        {
            get
            {
                return instance;
            }
        }

        private OccupiedMap(int numRows, int numCols)
        {
            Map = new bool[numRows, numCols]; // last column is false indicates row has already been scored and dropped
            this.numRows = numRows;
            this.numCols = numCols;

            for (int row = 0; row < numRows; row++)
            {
                Map[row, (numCols - 1)] = true;
            }

            DebugDumpMap();
        }

        public void Init()
        {
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < (numCols - 1); col++)
                {
                    Map[row, col] = false;
                }

                Map[row, (numCols - 1)] = true; // last column is false indicates row has already been scored and dropped
            }

            DebugDumpMap();
        }

        private void ClearAll()
        {
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < (numCols - 1); col++)
                {
                    Map[row, col] = false;
                }
            }
        }

        // somewhat inefficient
        public void FillAllOccupied(FallingBlocksPiece currentPiece, List<FallingBlocksPiece> pieceList)
        {
            ClearAll();

            if (currentPiece != null)
            {
                FillOccupied(currentPiece);
            }

            foreach (FallingBlocksPiece piece in pieceList)
            {
                FillOccupied(piece);
            }

            if (pieceList.Count == 0)
            {
                DebugDumpMap();
            }
        }

        public void FillOccupied(FallingBlocksPiece piece)
        {
            // get the min x, y (leftmost, topmost coord) of this piece
            int orientation = piece.Orientation;
            var x_query = from Point p in piece.TransformedPoints[orientation] select p.X;
            var y_query = from Point p in piece.TransformedPoints[orientation] select p.Y;
            int xmin = x_query.Min();
            int ymin = y_query.Min();
            int currentCol = xmin / FallingBlocksGame.ColumnWidth;
            int currentRow = ymin / FallingBlocksGame.ColumnHeight;
            
            for (int row = 0; row < piece.Occupied[orientation].Length; row++)
            {
                for (int col = 0; col < piece.Occupied[orientation][row].Length; col++)
                {
                    int rw = row + currentRow;
                    int cl = col + currentCol;
                    if (rw < FallingBlocksGame.NumRows)
                    {
                        if (!Map[rw, cl])
                        {
                            Map[rw, cl] = piece.Occupied[orientation][row][col];
                        }
                    }
                }
            }

            DebugDumpMap();
        }

        public void DebugDumpMap()
        {
            if (Properties.Settings.Default.DebugMap)
            {
                Console.WriteLine("\n\n\n\n");
                for (int rowNdx = 0; rowNdx < numRows; rowNdx++)
                {
                    for (int colNdx = 0; colNdx < numCols; colNdx++)
                    {
                        Console.Write("{0}", Map[rowNdx, colNdx] == true ? "X" : "_");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
