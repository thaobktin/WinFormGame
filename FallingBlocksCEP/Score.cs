using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FallingBlocksCEP
{
    class Score
    {
        private OccupiedMap occupiedMap;

        public Score(OccupiedMap occupiedMap)
        {
            this.occupiedMap = occupiedMap;
        }

        // returns true if there are rows to drop (could just as well check for rowsToDrop)
        // The actual updating of the score is now int DropRows
        public bool RowsToDrop(List<int> rowsToDrop)
        {
            bool dropRow = false;

            for (int row = FallingBlocksGame.NumRows - 1; row >= 0; row--)
            {
                int numOccupiedOnThisRow = 0;
                for (int col = 0; col < (FallingBlocksGame.NumCols + 1); col++)
                {
                    if (occupiedMap.Map[row, col])
                    {
                        numOccupiedOnThisRow++;
                    }
                }

                if (numOccupiedOnThisRow == (FallingBlocksGame.NumCols + 1))
                {
                    dropRow = true;
                    rowsToDrop.Add(row);
                    
                    if (((row + 1) < FallingBlocksGame.NumRows) && (rowsToDrop.Count == 1))
                    {
                        occupiedMap.Map[row + 1, FallingBlocksGame.NumCols] = false; // so this row is not scored again
                    }
                    occupiedMap.DebugDumpMap();
                }
            }
           
            return dropRow;
        }
    }
}
