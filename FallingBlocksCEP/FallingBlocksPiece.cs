using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FallingBlocksCEP
{
    public class FallingBlocksPiece
    {
        private int PieceSize { get; set; }
        public string Name { get; set; }
        protected Color PieceColor { get; set; }
        protected Point[][] Points { get; set; }
        public Rectangle[][] Rectangles { get; set; }
        public bool[] RectangleVisible { get; set; }
        public enum Direction { Left, Right, Down, Up, UpDebug }
        protected int Rotation { get; set; }
        protected int XTranslate { get; set; }
        protected int YTranslate { get; set; }
        public Point[][] TransformedPoints { get; set; }
        public Rectangle[][] TransformedRectangles { get; set; }
        public int Orientation { get; set; }
        public bool[][][] Occupied { get; set; }
        public bool[] Visible { get; set; }
        public int[] MaxHeight { get; set; }
        public int PieceNum { get; set; }
        public static int numPieces;

        public FallingBlocksPiece(int size, string name, Color color, Point[][] points, Rectangle[][] rectangles, bool[][][] occupied, bool[] visible, int[] maxHeight, int xTranslate, int yTranslate)
        {
            this.PieceSize = size;
            this.Name = name;
            this.PieceColor = color;
            this.Points = points;
            this.Rectangles = rectangles;
            this.RectangleVisible = new bool[4];
            for(int ndx = 0; ndx < this.RectangleVisible.Length; ndx++) { this.RectangleVisible[ndx] = true; }
            this.Rotation = 0;
            this.XTranslate = xTranslate;
            this.YTranslate = yTranslate;
            this.TransformedPoints = new Point[Points.Length][];
            this.TransformedRectangles = new Rectangle[Rectangles.Length][];
            this.Occupied = occupied;
            this.Visible = visible;
            this.MaxHeight = maxHeight;
            this.PieceNum = FallingBlocksPiece.numPieces++;

            for (int ndx = 0; ndx < Points.Length; ndx++)
            {
                TransformedPoints[ndx] = new Point[Points[ndx].Length];
            }
            for (int ndx = 0; ndx < Rectangles.Length; ndx++)
            {
                TransformedRectangles[ndx] = new Rectangle[Rectangles[ndx].Length];
            }
            for (int ndx = 0; ndx < Points.Length; ndx++)
            {
                for (int ndx2 = 0; ndx2 < Points[ndx].Length; ndx2++)
                {
                    TransformedPoints[ndx][ndx2].X = Points[ndx][ndx2].X + this.XTranslate;
                    TransformedPoints[ndx][ndx2].Y = Points[ndx][ndx2].Y + this.YTranslate;
                }
            }
            for (int ndx = 0; ndx < Rectangles.Length; ndx++) // orientation
            {
                for (int ndx2 = 0; ndx2 < Rectangles[ndx].Length; ndx2++)
                {
                    TransformedRectangles[ndx][ndx2].X = Rectangles[ndx][ndx2].X + this.XTranslate;
                    TransformedRectangles[ndx][ndx2].Y = Rectangles[ndx][ndx2].Y + this.YTranslate;
                    TransformedRectangles[ndx][ndx2].Size = Rectangles[ndx][ndx2].Size;
                }
            }
        }

        public virtual void Draw(Graphics graphics)
        {
            Matrix transformSave = graphics.Transform;
            Matrix transformationMatrix = new Matrix();
            transformationMatrix.Translate(XTranslate, YTranslate, MatrixOrder.Prepend);
            graphics.Transform = transformationMatrix;

            if ((this is ZPiece) || (this is SPiece) || (this is IPiece))
            {
                Orientation = Math.Abs(Rotation / 90) % 2;
            }
            else if ((this is JPiece) || (this is LPiece) || (this is TPiece))
            {
                Orientation = Math.Abs(Rotation / 90) % 4;
            }
            else if (this is OPiece)
            {
                Orientation = 0;
            }

            using (Brush brush = new SolidBrush(PieceColor))
            {
                if (RectangleVisible[0]) { graphics.FillRectangle(brush, Rectangles[Orientation][0]); }
                if (RectangleVisible[1]) { graphics.FillRectangle(brush, Rectangles[Orientation][1]); }
                if (RectangleVisible[2]) { graphics.FillRectangle(brush, Rectangles[Orientation][2]); }
                if (RectangleVisible[3]) { graphics.FillRectangle(brush, Rectangles[Orientation][3]); }
            }

            //if (RectangleVisible[0] && RectangleVisible[1] && RectangleVisible[2] & RectangleVisible[3])
            {
                using (Pen blackPen = new Pen(Color.Black))
                {
                    if ((this is ZPiece) || (this is SPiece))
                    {
                        graphics.DrawLines(blackPen, Points[Orientation]);
                        graphics.DrawLine(blackPen, Points[Orientation][1], Points[Orientation][8]); // b --> i
                        graphics.DrawLine(blackPen, Points[Orientation][3], Points[Orientation][8]); // d --> i
                        graphics.DrawLine(blackPen, Points[Orientation][3], Points[Orientation][6]); // d --> g
                    }
                    else if ((this is JPiece) || (this is LPiece))
                    {
                        graphics.DrawLines(blackPen, Points[Orientation]);
                        graphics.DrawLine(blackPen, Points[Orientation][2], Points[Orientation][9]); // c --> j
                        graphics.DrawLine(blackPen, Points[Orientation][2], Points[Orientation][7]); // c --> h
                        graphics.DrawLine(blackPen, Points[Orientation][3], Points[Orientation][6]); // d --> g
                    }
                    else if (this is IPiece)
                    {
                        graphics.DrawLines(blackPen, Points[Orientation]);
                        graphics.DrawLine(blackPen, Points[Orientation][1], Points[Orientation][8]); // b --> i
                        graphics.DrawLine(blackPen, Points[Orientation][2], Points[Orientation][7]); // c --> h
                        graphics.DrawLine(blackPen, Points[Orientation][3], Points[Orientation][6]); // d --> g
                    }
                    else if (this is TPiece)
                    {
                        graphics.DrawLines(blackPen, Points[Orientation]);
                        graphics.DrawLine(blackPen, Points[Orientation][1], Points[Orientation][8]); // b --> i
                        graphics.DrawLine(blackPen, Points[Orientation][2], Points[Orientation][5]); // c --> f
                        graphics.DrawLine(blackPen, Points[Orientation][5], Points[Orientation][8]); // f --> i
                    }
                    else if (this is OPiece)
                    {
                        graphics.DrawLines(blackPen, Points[Orientation]);
                        graphics.DrawLine(blackPen, Points[Orientation][1], Points[Orientation][5]); // b --> f
                        graphics.DrawLine(blackPen, Points[Orientation][7], Points[Orientation][3]); // h --> d
                    }
                }
            }

            if (Properties.Settings.Default.LabelPieces)
            {
                using (Font font = new Font("courier", 8))
                {
                    using (Brush brush = new SolidBrush(Color.Black))
                    {
                        for (int ndx = 0; ndx < 4; ndx++)
                        {
                            string msg = String.Format("{0} ({1})", this.PieceNum, ndx);
                            graphics.DrawString(msg, font, brush, Rectangles[Orientation][ndx].Location);
                        }
                    }
                }
            }

            graphics.Transform = transformSave;
        }

        public virtual void Preview(Graphics graphics)
        {
            using (Brush brush = new SolidBrush(PieceColor))
            {
                if (this is OPiece) // need to center OPiece because it is drawn centered at origin
                {
                    Matrix transformationMatrix = new Matrix();
                    transformationMatrix.Translate(FallingBlocksGame.XOffset + FallingBlocksGame.ColumnWidth, FallingBlocksGame.ColumnHeight, MatrixOrder.Prepend);
                    graphics.Transform = transformationMatrix;
                }

                graphics.FillRectangle(brush, Rectangles[Orientation][0]);
                graphics.FillRectangle(brush, Rectangles[Orientation][1]);
                graphics.FillRectangle(brush, Rectangles[Orientation][2]);
                graphics.FillRectangle(brush, Rectangles[Orientation][3]);
            }

            if (Properties.Settings.Default.LabelPieces)
            {
                using (Font font = new Font("courier", 8))
                {
                    using (Brush brush = new SolidBrush(Color.Black))
                    {
                        for (int ndx = 0; ndx < 4; ndx++)
                        {
                            string msg = String.Format("{0} ({1})", this.PieceNum, ndx);
                            graphics.DrawString(msg, font, brush, Rectangles[Orientation][ndx].Location);
                        }
                    }
                }
            }

            using (Pen blackPen = new Pen(Color.Black))
            {
                if ((this is ZPiece) || (this is SPiece))
                {
                    graphics.DrawLines(blackPen, Points[Orientation]);
                    graphics.DrawLine(blackPen, Points[Orientation][1], Points[Orientation][8]); // b --> i
                    graphics.DrawLine(blackPen, Points[Orientation][3], Points[Orientation][8]); // d --> i
                    graphics.DrawLine(blackPen, Points[Orientation][3], Points[Orientation][6]); // d --> g
                }
                else if ((this is JPiece) || (this is LPiece))
                {
                    graphics.DrawLines(blackPen, Points[Orientation]);
                    graphics.DrawLine(blackPen, Points[Orientation][2], Points[Orientation][9]); // c --> j
                    graphics.DrawLine(blackPen, Points[Orientation][2], Points[Orientation][7]); // c --> h
                    graphics.DrawLine(blackPen, Points[Orientation][3], Points[Orientation][6]); // d --> g
                }
                else if (this is IPiece)
                {
                    graphics.DrawLines(blackPen, Points[Orientation]);
                    graphics.DrawLine(blackPen, Points[Orientation][1], Points[Orientation][8]); // b --> i
                    graphics.DrawLine(blackPen, Points[Orientation][2], Points[Orientation][7]); // c --> h
                    graphics.DrawLine(blackPen, Points[Orientation][3], Points[Orientation][6]); // d --> g
                }
                else if (this is TPiece)
                {
                    graphics.DrawLines(blackPen, Points[Orientation]);
                    graphics.DrawLine(blackPen, Points[Orientation][1], Points[Orientation][8]); // b --> i
                    graphics.DrawLine(blackPen, Points[Orientation][2], Points[Orientation][5]); // c --> f
                    graphics.DrawLine(blackPen, Points[Orientation][5], Points[Orientation][8]); // f --> i
                }
                else if (this is OPiece)
                {
                    graphics.DrawLines(blackPen, Points[Orientation]);
                    graphics.DrawLine(blackPen, Points[Orientation][1], Points[Orientation][5]); // b --> f
                    graphics.DrawLine(blackPen, Points[Orientation][7], Points[Orientation][3]); // h --> d
                }
            }
        }

        public virtual void Translate(Direction dir, int cols)
        {
            for (int col = 0; col < cols; col++)
            {
                Translate(dir);
            }
        }

        public virtual void Translate(Direction dir)
        {
            var x_query = from Point p in TransformedPoints[Orientation] select p.X;
            int xmin = x_query.Min();
            int xmax = x_query.Max();

            var y_query = from Point p in TransformedPoints[Orientation] select p.Y;
            int ymin = y_query.Min();
           
            switch (dir)
            {
                case Direction.Up:
                    this.YTranslate -= FallingBlocksGame.ColumnHeight;
                    break;
                case Direction.Down:
                    this.YTranslate += FallingBlocksGame.ColumnHeight;
                    break;
                case Direction.Left:
                    if (xmin <= FallingBlocksGame.XOffset) return;
                    this.XTranslate -= FallingBlocksGame.ColumnWidth;
                    break;
                case Direction.Right:
                    if (xmax >= FallingBlocksGame.XOffset + (FallingBlocksGame.NumCols * FallingBlocksGame.ColumnWidth)) return;
                    this.XTranslate += FallingBlocksGame.ColumnWidth;
                    break;
                case Direction.UpDebug:
                    if (ymin <= FallingBlocksGame.YOffset) return;
                    this.YTranslate -= FallingBlocksGame.ColumnHeight;
                    break;
            }

            UpdateTransformedPoints(dir);
         }

        public virtual void Rotate(Direction dir)
        {
            switch (dir)
            {
                case Direction.Down:
                    Rotation -= 90;
                    if (Rotation <= -360)
                    {
                        Rotation = 0;
                    }
                    break;

                case Direction.Up:
                    Rotation += 90;
                    if (Rotation >= 360)
                    {
                        Rotation = 0;
                    }
                    break;
            }
        }

        public virtual void UpdateTransformedPoints(Direction dir)
        {
            foreach (Point[] parray in TransformedPoints)
            {
                for (int ndx = 0; ndx < parray.Length; ndx++)
                {
                    switch (dir)
                    {
                        case Direction.Up:
                            parray[ndx].Y -= FallingBlocksGame.ColumnHeight;
                            break;
                        case Direction.Down:
                            parray[ndx].Y += FallingBlocksGame.ColumnHeight;
                            break;
                        case Direction.Left:
                            parray[ndx].X -= FallingBlocksGame.ColumnWidth;
                            break;
                        case Direction.Right:
                            parray[ndx].X += FallingBlocksGame.ColumnWidth;
                            break;
                        case Direction.UpDebug:
                            parray[ndx].Y -= FallingBlocksGame.ColumnHeight;
                            break;
                    }
                }
            }

            for (int ondx = 0; ondx < TransformedRectangles.Length; ondx++ )
            {
                Rectangle[] rarray = TransformedRectangles[ondx];

                for (int ndx = 0; ndx < rarray.Length; ndx++)
                {
                    switch (dir)
                    {
                        case Direction.Up:
                            rarray[ndx].Y -= FallingBlocksGame.ColumnHeight;
                            break;
                        case Direction.Down:
                            rarray[ndx].Y += FallingBlocksGame.ColumnHeight;
                            if ((this.Orientation == ondx) && (rarray[ndx].Y >= FallingBlocksGame.YMax))
                            {
                                this.RectangleVisible[ndx] = false;
                            }

                            break;
                        case Direction.Left:
                            rarray[ndx].X -= FallingBlocksGame.ColumnWidth;
                            break;
                        case Direction.Right:
                            rarray[ndx].X += FallingBlocksGame.ColumnWidth;
                            break;
                        case Direction.UpDebug:
                            rarray[ndx].Y -= FallingBlocksGame.ColumnHeight;
                            break;
                    }

                }
            }
        }
    }
}

