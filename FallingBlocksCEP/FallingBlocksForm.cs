using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace FallingBlocksCEP
{
    public partial class FallingBlocksForm : Form
    {
        private FallingBlocksGame FallingBlocksGame;
        private FallingBlocksPiece currentPiece;
        private FallingBlocksPiece previewPiece;
        private Color[] colors = new Color[FallingBlocksGame.NumPieces];
        private int currentScore;
        private Stopwatch stopwatch = new Stopwatch();
        
        public delegate void UpdateTimer(bool enabled);
        public delegate void UpdateScore(int score);
        public delegate void UpdatePaint();

        public FallingBlocksForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            // I, J, L, O, S, T, Z 
            colors[0] = Properties.Settings.Default.ColorI;
            colors[1] = Properties.Settings.Default.ColorJ;
            colors[2] = Properties.Settings.Default.ColorL;
            colors[3] = Properties.Settings.Default.ColorO;
            colors[4] = Properties.Settings.Default.ColorS;
            colors[5] = Properties.Settings.Default.ColorT;
            colors[6] = Properties.Settings.Default.ColorZ;

            FallingBlocksPiece.numPieces = 0;
            FallingBlocksGame = new FallingBlocksGame(colors, new UpdateTimer(UpdateTheTimer), new UpdateScore(UpdateTheScore), new UpdatePaint(UpdateThePaint));
            
            FallingBlocksPiece piece = FallingBlocksGame.GetNextPiece();
            previewPiece = piece;
            currentPiece = null;
            currentScore = 0;
            this.lblNumPieces.Text = this.lblScore.Text = "0";
            timerPieceDrop.Enabled = false;
            stopwatch.Reset();
            this.btnPause.Text = "Start";
            this.btnPause.Enabled = true;
            this.pbPreview.Invalidate();
            this.pbFallingBlocks.Invalidate();
            this.Invalidate();
        }

        private void DrawAllPieces(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            if (currentPiece != null)
            {
                currentPiece.Draw(graphics);
            }

            foreach (FallingBlocksPiece piece in FallingBlocksGame.PieceList)
            {
                  piece.Draw(graphics);
            }
        }

        private void timerPieceDrop_Tick(object sender, EventArgs e)
        {
            if (!FallingBlocksGame.CanStillFall(currentPiece))
            {
                DebugPieceLocation(currentPiece);
                NextPiece();
            }

            this.pbFallingBlocks.Invalidate();
        }

        private void NextPiece()
        {
            FallingBlocksGame.PieceList.Add(currentPiece);
            this.lblNumPieces.Text = FallingBlocksGame.PieceList.Count.ToString();
            FallingBlocksGame.occupiedMap.FillOccupied(currentPiece);

            List<int> rowsToDrop = new List<int>();
            if (FallingBlocksGame.score.RowsToDrop(rowsToDrop))
            {
                FallingBlocksGame.DropRows(rowsToDrop);
                OccupiedMap.Instance.FillAllOccupied(currentPiece, FallingBlocksGame.PieceList);
            }

            currentPiece = previewPiece;
            previewPiece = FallingBlocksGame.GetNextPiece();
            this.pbFallingBlocks.Invalidate();
            this.pbPreview.Invalidate();
        }

        // this currently is not used
        private void FallingBlocksForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
        }

        // returns true if the character was processed by the control; otherwise, false. 
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) // http://stackoverflow.com/questions/4378865/detect-arrow-key-keydown-for-the-whole-window
        {
            if (keyData == Keys.Left)
            {
                currentPiece.Translate(FallingBlocksPiece.Direction.Left);
                if (FallingBlocksGame.CheckForCollision(currentPiece)) currentPiece.Translate(FallingBlocksPiece.Direction.Right);
                this.pbFallingBlocks.Invalidate();
                return true; 
            }
            else if (keyData == Keys.Right)
            {
                currentPiece.Translate(FallingBlocksPiece.Direction.Right);
                if (FallingBlocksGame.CheckForCollision(currentPiece)) currentPiece.Translate(FallingBlocksPiece.Direction.Left);
                this.pbFallingBlocks.Invalidate();
                return true;
            }
            else if (keyData == Keys.Up)
            {
                currentPiece.Rotate(FallingBlocksPiece.Direction.Up);
                this.pbFallingBlocks.Invalidate();
                return true;
            }
            else if (keyData == Keys.Down)
            {
                currentPiece.Rotate(FallingBlocksPiece.Direction.Down);
                this.pbFallingBlocks.Invalidate();
                return true;
            }
            else if (keyData == Keys.Space)
            {
                if (currentPiece == null) return true;
                timerPieceDrop.Enabled = false;
                FallingBlocksGame.DropPiece(currentPiece);
                DebugPieceLocation(currentPiece);
                NextPiece();
                timerPieceDrop.Enabled = true;
                return true;
            }
            else if (keyData == Keys.U) // moves piece up - not standard FallingBlocks, but useful during development
            {
                currentPiece.Translate(FallingBlocksPiece.Direction.UpDebug);
                this.pbFallingBlocks.Invalidate();
                return true;
            }
            else if (keyData == Keys.Z) // "undo" movement of piece - not standard FallingBlocks, but useful during development
            {
                FallingBlocksGame.PieceList.RemoveAt(FallingBlocksGame.PieceList.Count - 1);
                this.pbFallingBlocks.Invalidate();
                return true;
            }
            else if ((keyData == Keys.Escape) || (keyData == Keys.P))
            {
                if (btnPause.Text != "Start")
                {
                    btnPause_Click(null, null);
                }
                return true; 
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Init();
            btnPause.Enabled = true;
        }

        private void UpdateTheTimer(bool enabled)
        {
            timerPieceDrop.Enabled = enabled;
            if (!enabled)
            {
                btnPause.Text = "Stopped";
                btnPause.Text = "Game Over";
                btnPause.Enabled = false;
                this.btnNewGame.Text = "New Game";
                stopwatch.Stop();
                this.previewPiece = null;
                this.pbPreview.Invalidate();
            }
            else
            {
                throw new Exception("UpdateTheTimer no longer being called with true");
                //btnPause.Text = "Pause";
                //btnPause.ForeColor = Color.Gray;
            }
        }

        private void UpdateTheScore(int score)
        {
            currentScore += score;
            this.lblScore.Text = currentScore.ToString();
            this.Invalidate();
            this.Refresh();
        }

        private void UpdateThePaint()
        {
            //this.pbFallingBlocks.Invalidate(); does not seem to work http://blogs.msdn.com/b/subhagpo/archive/2005/02/22/378098.aspx
            this.pbFallingBlocks.Refresh();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            // if pausing
            if (timerPieceDrop.Enabled)
            {
                timerPieceDrop.Enabled = false;
                btnPause.Text = "Resume";
                stopwatch.Stop();
            }
            // else starting or resuming
            else
            {
                if (btnPause.Text == "Start")
                {
                    currentPiece = previewPiece;
                    previewPiece = FallingBlocksGame.GetNextPiece();
                    this.pbFallingBlocks.Invalidate();
                    this.pbPreview.Invalidate();
                }

                timerPieceDrop.Enabled = true;
                btnPause.Text = "Pause";
                stopwatch.Start();
            }
        }

        private void tbrSpeed_Scroll(object sender, EventArgs e)
        {
            int speed = 1000 - tbrSpeed.Value; // hard code
            timerPieceDrop.Interval = (speed <= 100) ? 100 : speed;
        }

        private void pbFallingBlocks_Paint(object sender, PaintEventArgs e)
        {
            FallingBlocksGame.DrawContainer(e);
            DrawAllPieces(e);
            FallingBlocksGame.DrawFinalRectangle(e);
        }

        private void pbPreview_Paint(object sender, PaintEventArgs e)
        {
            if (previewPiece != null)
            {
                previewPiece.Preview(e.Graphics);
            }
        }

        private void timerElapsed_Tick(object sender, EventArgs e)
        {
            //string elapsed = String.Format("{0:d2}:{1:d2}:{2:d3}", stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds); // zero pad
            string elapsed = String.Format("Elapsed: {0:d2}:{1:d2}", stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds); // zero pad
            lblElapsed.Text = elapsed;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNewGame_Click(null, null);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FallingBlocksCEPAboutBox fallingBlocksCEPAboutBox = new FallingBlocksCEPAboutBox();
            if (File.Exists(Properties.Resources.HelpFile))
            {
                string[] help = File.ReadAllLines(Properties.Resources.HelpFile);
                foreach (string str in help)
                {
                    fallingBlocksCEPAboutBox.textBoxDescription.Text += (str + Environment.NewLine);
                }
            }
            else
            {
                String msg = String.Format("Error: missing help file: {0}", Properties.Resources.HelpFile);
                fallingBlocksCEPAboutBox.textBoxDescription.Text = msg;
                fallingBlocksCEPAboutBox.textBoxDescription.Text += "Keys: Left, Right Arrows to move piece\r\nUp, Down Arrows to Rotate Piece\r\nSpace Bar To Drop Piece";
            }

            fallingBlocksCEPAboutBox.Show();
        }

        private void DebugPieceLocation(FallingBlocksPiece piece)
        {
            if (Properties.Settings.Default.DebugPieceLocation)
            {
                int rect = 0; // enough to determine where the piece is
                int orientation = piece.Orientation;
                string debugMsg = String.Format("Piece {0} ({1}) Oriented {2} Rectangle {3} at Column {4} Row {5}",
                    piece.PieceNum, piece.Name, piece.Orientation, rect,
                    (piece.TransformedRectangles[orientation][rect].X / FallingBlocksGame.ColumnWidth),
                    (piece.TransformedRectangles[orientation][rect].Y / FallingBlocksGame.ColumnWidth));
                Console.WriteLine(debugMsg);
            }
        }
    }
}
