#define TESTz

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FallingBlocksCEP
{
    class FallingBlocksGame
    {
        private int DramaticPauseMS = Properties.Settings.Default.DramaticPauseMS;
        private static Random randomPiece = new Random();
        private static Random randomColumn = new Random();
        public const int NumPieces = 7; // per wikipedia
        private FallingBlocksForm.UpdateTimer updateTimer;
        private FallingBlocksForm.UpdatePaint updatePaint;
        private FallingBlocksForm.UpdateScore updateScore;
        private Color[] colors;
        public OccupiedMap occupiedMap;
        public Score score;
        private int pieceSize;
        private int lastPieceType = -1; // prevent two consecutive pieces of the same type

        public const int ColumnWidth = 20;  // also known as CellWidth
        public const int ColumnHeight = 20; // also known as CellHeight
        public const int NumCols = 12;
        public const int NumRows = 24;
        public const int XOffset = 20;
        public const int YOffset = 20;
        public const int XMax = (ColumnWidth * NumCols) + XOffset;
        public const int YMax = (ColumnHeight * NumRows) + YOffset;
        public const int Width = NumCols * ColumnWidth;
        public const int Height = NumRows * ColumnHeight;
        public List<FallingBlocksPiece> PieceList { get; set; }

#if TEST
        static FallingBlocksPiece[] testPieces = new FallingBlocksPiece[]
            { new IPiece(ColumnWidth, Color.Green), new JPiece(ColumnWidth, Color.Cyan),  new LPiece(ColumnWidth, Color.Red),   new OPiece(ColumnWidth, Color.Yellow),   new SPiece(ColumnWidth, Color.Violet),  new TPiece(ColumnWidth, Color.Blue), new ZPiece(ColumnWidth, Color.Gray), // I, J, L, O, S, T, Z
              new IPiece(ColumnWidth, Color.Green), new JPiece(ColumnWidth, Color.Cyan),  new LPiece(ColumnWidth, Color.Red),   new OPiece(ColumnWidth, Color.Yellow),   new SPiece(ColumnWidth, Color.Violet),  new TPiece(ColumnWidth, Color.Blue), new ZPiece(ColumnWidth, Color.Gray), // I, J, L, O, S, T, Z
              new IPiece(ColumnWidth, Color.Green), new IPiece(ColumnWidth, Color.Blue),  new IPiece(ColumnWidth, Color.Red),   new IPiece(ColumnWidth, Color.Cyan),     new IPiece(ColumnWidth, Color.Green),  new IPiece(ColumnWidth, Color.Blue), new IPiece(ColumnWidth, Color.Red), new IPiece(ColumnWidth, Color.Yellow), new IPiece(ColumnWidth, Color.DarkOliveGreen), new IPiece(ColumnWidth, Color.HotPink),
              new IPiece(ColumnWidth, Color.Green), new IPiece(ColumnWidth, Color.Blue),  new IPiece(ColumnWidth, Color.Red),   new IPiece(ColumnWidth, Color.Cyan),     new IPiece(ColumnWidth, Color.Green),  new IPiece(ColumnWidth, Color.Blue), new IPiece(ColumnWidth, Color.Red), new IPiece(ColumnWidth, Color.Yellow), new IPiece(ColumnWidth, Color.DarkOliveGreen), new IPiece(ColumnWidth, Color.HotPink),
              new IPiece(ColumnWidth, Color.Green), new JPiece(ColumnWidth, Color.Blue),  new LPiece(ColumnWidth, Color.Red),   new OPiece(ColumnWidth, Color.Cyan),     new SPiece(ColumnWidth, Color.Green),  new TPiece(ColumnWidth, Color.Blue), new ZPiece(ColumnWidth, Color.Red),
              new IPiece(ColumnWidth, Color.Cyan),  new JPiece(ColumnWidth, Color.Green), new LPiece(ColumnWidth, Color.Blue),  new OPiece(ColumnWidth, Color.Red),      new SPiece(ColumnWidth, Color.Cyan),   new TPiece(ColumnWidth, Color.Green), new ZPiece(ColumnWidth, Color.Blue),
              new IPiece(ColumnWidth, Color.Red),   new JPiece(ColumnWidth, Color.Cyan),  new LPiece(ColumnWidth, Color.Green), new OPiece(ColumnWidth, Color.Blue),     new SPiece(ColumnWidth, Color.Red),    new TPiece(ColumnWidth, Color.Green), new ZPiece(ColumnWidth, Color.Blue),
              new IPiece(ColumnWidth, Color.Red),   new JPiece(ColumnWidth, Color.Gray),  new LPiece(ColumnWidth, Color.Yellow),new OPiece(ColumnWidth, Color.LightGray),new SPiece(ColumnWidth, Color.Gray),   new TPiece(ColumnWidth, Color.Yellow), new ZPiece(ColumnWidth, Color.LightGray),
              new IPiece(ColumnWidth, Color.Orange),new JPiece(ColumnWidth, Color.Cyan),  new LPiece(ColumnWidth, Color.Violet),new OPiece(ColumnWidth, Color.Cornsilk), new SPiece(ColumnWidth, Color.DarkRed),new TPiece(ColumnWidth, Color.Salmon), new ZPiece(ColumnWidth, Color.Green)
            };
        static int testPiecesNdx = 0;
#endif
        public FallingBlocksGame(Color[] colors, FallingBlocksForm.UpdateTimer updateTimer, FallingBlocksForm.UpdateScore updateScore, FallingBlocksForm.UpdatePaint updatePaint)
        {
            if (PieceList != null) PieceList.Clear();
            PieceList = new List<FallingBlocksPiece>();

            this.pieceSize = ColumnHeight;
            this.colors = colors;
            this.updateTimer = updateTimer;
            this.updatePaint = updatePaint;
            this.updateScore = updateScore;
            occupiedMap = OccupiedMap.Instance;
            occupiedMap.Init();
            score = new Score(OccupiedMap.Instance);
        }

        public void DrawContainer(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            using (Brush brush = new SolidBrush(Properties.Settings.Default.ColorBackground1))
            {
                for (int col = 0; col < (ColumnWidth * NumCols); col += (2 * ColumnWidth))
                {
                    int colActual = col + XOffset;
                    graphics.FillRectangle(brush, new Rectangle(colActual, YOffset, ColumnWidth, Height));
                }
            }
            using (Brush brush = new SolidBrush(Properties.Settings.Default.ColorBackground2))
            {
                for (int col = ColumnWidth; col < (ColumnWidth * NumCols); col += (2 * ColumnWidth))
                {
                    int colActual = col + XOffset;
                    graphics.FillRectangle(brush, new Rectangle(colActual, YOffset, ColumnWidth, Height));
                }
            }

            using (Pen pen = new Pen(Color.Black))
            {
                // upper and lower bounds
                graphics.DrawLine(pen, XOffset, YOffset, XMax, YOffset);
                graphics.DrawLine(pen, XOffset, YMax, XMax, YMax);

                // vertical
                graphics.DrawLine(pen, XOffset, YOffset, XOffset, YMax);
                graphics.DrawLine(pen, XOffset + Width, YOffset, XOffset + Width, YMax);
            }

           
            if (Properties.Settings.Default.DrawLinesAndLabels)
            {
                DrawLinesAndLabels(graphics);
            }
        }

        // this is a little bit of a kludge to cover pieces that fall below the bottom row when the bottom row is cleared;
        // the intent of the Visible field in FallingBlocksPiece is to eventually get rid of the need for this 
        public void DrawFinalRectangle(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            using (Brush brush = new SolidBrush(System.Drawing.SystemColors.ControlLight)) // pbFallingBlocks.BackColor
            {
                graphics.FillRectangle(brush, new Rectangle(XOffset, YMax + 1, (ColumnWidth * NumCols) + 5, 30));
            }
        }


        private void DrawLinesAndLabels(Graphics graphics)
        {
            using (Font font = new Font("courier", 10))
            {
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    // vertical dashed lines
                    float[] dashValues = { 5, 5 };
                    using (Pen blackPen = new Pen(Color.Black))
                    {
                        blackPen.DashPattern = dashValues;
                        for (int col = 0; col <= (ColumnWidth * NumCols); col += ColumnWidth)
                        {
                            int colActual = col + XOffset;
                            graphics.DrawLine(blackPen, colActual, YOffset, colActual, YMax);

                            /* debug */
                            graphics.DrawString(colActual.ToString(), font, brush, colActual - 6, YMax + 6);
                            if (col < (ColumnWidth * NumCols))
                            {
                                graphics.DrawString((col / FallingBlocksGame.ColumnWidth).ToString(), font, brush, colActual + 6, 0);
                            }
                        }
                    }

                    // horizontal dashed lines
                    float[] dashValues2 = { 8, 8 };
                    using (Pen cyanPen = new Pen(Color.Cyan))
                    {
                        cyanPen.DashPattern = dashValues2;
                        for (int row = YOffset; row <= YMax; row += ColumnHeight)
                        {
                            graphics.DrawLine(cyanPen, XOffset, row, XMax, row);

                            /* debug */
                            graphics.DrawString(row.ToString(), font, brush, XMax, row - 4);
                            if(row < YMax) graphics.DrawString((row / ColumnHeight ).ToString(), font, brush, 0, row);
                        }
                    }
                }
            }
        }

        // returns true if we're continuing to fall, false if we've reached bottom or bumped into another piece
        public bool CanStillFall(FallingBlocksPiece piece)
        {
            // move the piece down
            piece.Translate(FallingBlocksPiece.Direction.Down);

            // get all the rectangles for the pieces already in place
            //List<Rectangle> allRectangles = new List<Rectangle>();
            //foreach (FallingBlocksPiece tpiece in PieceList) // todo if rectangle is not visible, do not include (for efficiency reasons)
            //{
            //    allRectangles.AddRange(tpiece.TransformedRectangles[tpiece.Orientation]);
           // }

            // get all the rectangles for the current piece
            List<Rectangle> rectangleList = piece.TransformedRectangles[piece.Orientation].OfType<Rectangle>().ToList(); // convert array to list

            // if there is a collision
            //bool collision = IsCollision(allRectangles, piece.TransformedRectangles[piece.Orientation]);
            bool collision = CheckForCollision(piece/*.TransformedRectangles[piece.Orientation]*/);
            if (collision)
            {
                // move the piece back up
                piece.Translate(FallingBlocksPiece.Direction.Up);

                // check to see if the piece is at the very top and can't be moved
                var y_queryPiece = from Point p in piece.TransformedPoints[piece.Orientation] select p.Y;
                int ymax = y_queryPiece.Max();

                if (ymax == (piece.MaxHeight[piece.Orientation] + FallingBlocksGame.XOffset))
                {
                    this.updateTimer(false); // game over
                    return true;
                }

                return false;
            }

            // if we got this far, there is no collision with another piece, so highest y value for this piece (bottom most coord)
            // to see if we are at bottom of screen
            var y_query = from Point p in piece.TransformedPoints[piece.Orientation] select p.Y;
            int ymax2 = y_query.Max();

            if (ymax2 < FallingBlocksGame.YMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DropPiece(FallingBlocksPiece piece)
        {
            while(CanStillFall(piece))
            {
                ; // do nothing 
            }
        }

        // Axis Aligned Bounding Box or "AABB"; returns true if any rectangles in 
        // pieceRect (the four rectangles that comprise the piece) intersects
        // with any of the rectangles in allRectangles; else false
        //
        // Non collision case example: ((rect1.X + rect1.Width) > rect2.X) is false; (rect1.X < (rect2.X + rect2.Width)) is true
        //   |
        //   |             +--------+
        //   |             |        |
        //   |             | rect1  |   +--------+
        //   |             |        |   |        |
        //   |             +--------+   | rect2  |
        //   |<--rect1.X-->|        |   |        |
        //   |<-rect1.X+rect1.Width>|   +--------+
        //   |<--------  rect2.X ------>|        |
        //   |<---- rect2.X + rect2.Width ------>|
        //   |            
        private bool IsCollision(List<Rectangle> allRectangles, Rectangle[] pieceRect)
        {
            // trivial rejection - the piece that is moving is the only one in the game
            if (allRectangles.Count == 0)
            {
                return false;
            }

            foreach (Rectangle rect1 in allRectangles)
            {
                foreach (Rectangle rect2 in pieceRect)
                {
                    if (rect1.X < (rect2.X + rect2.Width) &&
                       (rect1.X + rect1.Width) > rect2.X &&
                        rect1.Y < (rect2.Y + rect2.Height) &&
                       (rect1.Height + rect1.Y) > rect2.Y)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckForCollision(FallingBlocksPiece piece)
        {
            // get all the rectangles for the pieces already in place
            List<Rectangle> allRectangles = new List<Rectangle>();
            foreach (FallingBlocksPiece tpiece in PieceList) // todo if rectangle is not visible, do not include (for efficiency reasons)
            {
                allRectangles.AddRange(tpiece.TransformedRectangles[tpiece.Orientation]);
            }

            // get all the rectangles for the current piece
            List<Rectangle> rectangleList = piece.TransformedRectangles[piece.Orientation].OfType<Rectangle>().ToList(); // convert array to list

            // if there is a collision
            bool collision = IsCollision(allRectangles, piece.TransformedRectangles[piece.Orientation]);

            return collision;
        }

        public FallingBlocksPiece GetNextPiece()
        {
            FallingBlocksPiece piece = null;
#if TEST
            if (testPiecesNdx < testPieces.Length)
            {
                piece = testPieces[testPiecesNdx++];
            }
            else
            {
                MessageBox.Show("Test Over", "Info", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
            return piece;
#else
            int pieceType;

            pieceType = randomPiece.Next(0, NumPieces);
            while (pieceType == lastPieceType)
            {
                pieceType = randomPiece.Next(0, NumPieces); // inclusive, exclusive
            }
           
            switch (pieceType) // I, J, L, O, S, T, Z 
            {
                case 0:
                    piece = new IPiece(pieceSize, colors[pieceType]);
                    break;

                case 1:
                    piece = new JPiece(pieceSize, colors[pieceType]);
                    break;

                case 2:
                    piece = new LPiece(pieceSize, colors[pieceType]);
                    break;

                case 3:
                    piece = new OPiece(pieceSize, colors[pieceType]);
                    break;

                case 4:
                    piece = new SPiece(pieceSize, colors[pieceType]);
                    break;

                case 5:
                    piece = new TPiece(pieceSize, colors[pieceType]);
                    break;

                case 6:
                    piece = new ZPiece(pieceSize, colors[pieceType]);
                    break;

                default:
                    throw new Exception("pieceType out of range");
            }
            lastPieceType = pieceType;
            

        int column = randomColumn.Next(0, NumCols);
        piece.Translate(FallingBlocksPiece.Direction.Right, column);

        return piece;
#endif
        }

        public void DropRows(List<int> rowsToDrop)
        {
            StringBuilder sb = new StringBuilder();
            string msg = String.Format("Dropping row{0}: ", rowsToDrop.Count == 1 ? "" : "s");
            sb.Append(msg);
            foreach(int row in rowsToDrop)
            {
                sb.Append(row.ToString());
                sb.Append(", ");
            }
            string msg2 = sb.ToString().TrimEnd(new char[] { ',', ' ' });
            // debug Console.WriteLine(msg2);

            int rowCounter = 0;
            foreach (int rowToDrop in rowsToDrop)
            {
                DropTheRow(rowToDrop + rowCounter);
                rowCounter++;
                updateScore(100);
            }
            if (rowsToDrop.Count == 4)
            {
                updateScore(400); // not sure if this is actual FallingBlocks scoring method for 4 line clear, aka "tetris"
            }
            OccupiedMap.Instance.FillAllOccupied(null, PieceList);
        }

        private void DropTheRow(int rowToDrop)
        {
            List<int> piecesToDrop = new List<int>(); // pieces on this row to drop

            int ycoord = (rowToDrop * FallingBlocksGame.ColumnHeight) + XOffset;

            // for every piece
            for (int pNdx = 0; pNdx < PieceList.Count; pNdx++)
            {
                FallingBlocksPiece piece = PieceList[pNdx];
                int orientation = piece.Orientation;
                int num = piece.PieceNum;

                // for each rectangle in this piece
                for(int rndx = 0; rndx < piece.TransformedRectangles[orientation].Length; rndx++)
                {
                    Rectangle rect = piece.TransformedRectangles[orientation][rndx];

                    // if this rectangle is on the drop row
                    if (rect.Y == ycoord)
                    {
                        if(!piecesToDrop.Contains(num))
                        {
                            piecesToDrop.Add(num);
                        }
                    }
                }
            }
            
            for (int pNdx = 0; pNdx < PieceList.Count; pNdx++)
            {
                FallingBlocksPiece piece = PieceList[pNdx];

                // this code lifted from FillOccupied, but note how currentRow is computed differently
                int orientation = piece.Orientation;
                var y_query = from Point p in piece.TransformedPoints[orientation] select p.Y;
                int ymax = y_query.Max();
                int currentRow = ((ymax - FallingBlocksGame.YOffset) / FallingBlocksGame.ColumnHeight) - 1;
                currentRow = (ymax / FallingBlocksGame.ColumnHeight) - 1;
                {
                    // if piece on or above rowToDrop
                    if ((piecesToDrop.Contains(piece.PieceNum)) || (currentRow < rowToDrop))
                    {
                        piece.Translate(FallingBlocksPiece.Direction.Down);
                    }

                    System.Threading.Thread.Sleep(DramaticPauseMS);
                    updatePaint();
                }
            }
        }
    }
}
