namespace FallingBlocksCEP
{
    partial class FallingBlocksForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerPieceDrop = new System.Windows.Forms.Timer(this.components);
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.tbrSpeed = new System.Windows.Forms.TrackBar();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.pbFallingBlocks = new System.Windows.Forms.PictureBox();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.gbScore = new System.Windows.Forms.GroupBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.gbNext = new System.Windows.Forms.GroupBox();
            this.timerElapsed = new System.Windows.Forms.Timer(this.components);
            this.lblNumPieces = new System.Windows.Forms.Label();
            this.gbPieces = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tbrSpeed)).BeginInit();
            this.gbControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFallingBlocks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.gbScore.SuspendLayout();
            this.gbNext.SuspendLayout();
            this.gbPieces.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerPieceDrop
            // 
            this.timerPieceDrop.Interval = 2000;
            this.timerPieceDrop.Tick += new System.EventHandler(this.timerPieceDrop_Tick);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(6, 19);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(6, 48);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Start";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // tbrSpeed
            // 
            this.tbrSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbrSpeed.Location = new System.Drawing.Point(15, 115);
            this.tbrSpeed.Maximum = 1000;
            this.tbrSpeed.Minimum = 100;
            this.tbrSpeed.Name = "tbrSpeed";
            this.tbrSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbrSpeed.Size = new System.Drawing.Size(126, 45);
            this.tbrSpeed.TabIndex = 5;
            this.tbrSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbrSpeed.Value = 100;
            this.tbrSpeed.Scroll += new System.EventHandler(this.tbrSpeed_Scroll);
            // 
            // Label22
            // 
            this.Label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(105, 155);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(36, 13);
            this.Label22.TabIndex = 9;
            this.Label22.Text = "Faster";
            // 
            // Label21
            // 
            this.Label21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(15, 153);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(39, 13);
            this.Label21.TabIndex = 8;
            this.Label21.Text = "Slower";
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.lblElapsed);
            this.gbControls.Controls.Add(this.btnNewGame);
            this.gbControls.Controls.Add(this.Label22);
            this.gbControls.Controls.Add(this.btnPause);
            this.gbControls.Controls.Add(this.Label21);
            this.gbControls.Controls.Add(this.tbrSpeed);
            this.gbControls.Location = new System.Drawing.Point(12, 33);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(204, 178);
            this.gbControls.TabIndex = 10;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Controls";
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsed.Location = new System.Drawing.Point(12, 85);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(105, 18);
            this.lblElapsed.TabIndex = 15;
            this.lblElapsed.Text = "Elapsed: 00:00";
            // 
            // pbFallingBlocks
            // 
            this.pbFallingBlocks.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbFallingBlocks.Location = new System.Drawing.Point(247, 32);
            this.pbFallingBlocks.Name = "pbFallingBlocks";
            this.pbFallingBlocks.Size = new System.Drawing.Size(350, 710);
            this.pbFallingBlocks.TabIndex = 11;
            this.pbFallingBlocks.TabStop = false;
            this.pbFallingBlocks.Paint += new System.Windows.Forms.PaintEventHandler(this.pbFallingBlocks_Paint);
            // 
            // pbPreview
            // 
            this.pbPreview.Location = new System.Drawing.Point(34, 19);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(140, 68);
            this.pbPreview.TabIndex = 12;
            this.pbPreview.TabStop = false;
            this.pbPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pbPreview_Paint);
            // 
            // gbScore
            // 
            this.gbScore.Controls.Add(this.lblScore);
            this.gbScore.Location = new System.Drawing.Point(16, 323);
            this.gbScore.Name = "gbScore";
            this.gbScore.Size = new System.Drawing.Size(200, 89);
            this.gbScore.TabIndex = 13;
            this.gbScore.TabStop = false;
            this.gbScore.Text = "Score";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(31, 30);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(24, 25);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "0";
            // 
            // gbNext
            // 
            this.gbNext.Controls.Add(this.pbPreview);
            this.gbNext.Location = new System.Drawing.Point(16, 217);
            this.gbNext.Name = "gbNext";
            this.gbNext.Size = new System.Drawing.Size(200, 100);
            this.gbNext.TabIndex = 14;
            this.gbNext.TabStop = false;
            this.gbNext.Text = "Next";
            // 
            // timerElapsed
            // 
            this.timerElapsed.Enabled = true;
            this.timerElapsed.Interval = 1000;
            this.timerElapsed.Tick += new System.EventHandler(this.timerElapsed_Tick);
            // 
            // lblNumPieces
            // 
            this.lblNumPieces.AutoSize = true;
            this.lblNumPieces.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPieces.Location = new System.Drawing.Point(31, 30);
            this.lblNumPieces.Name = "lblNumPieces";
            this.lblNumPieces.Size = new System.Drawing.Size(24, 25);
            this.lblNumPieces.TabIndex = 0;
            this.lblNumPieces.Text = "0";
            // 
            // gbPieces
            // 
            this.gbPieces.Controls.Add(this.lblNumPieces);
            this.gbPieces.Location = new System.Drawing.Point(18, 425);
            this.gbPieces.Name = "gbPieces";
            this.gbPieces.Size = new System.Drawing.Size(200, 89);
            this.gbPieces.TabIndex = 15;
            this.gbPieces.TabStop = false;
            this.gbPieces.Text = "Pieces";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FallingBlocksForm
            // 
            this.AcceptButton = this.btnPause;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 765);
            this.Controls.Add(this.gbPieces);
            this.Controls.Add(this.gbNext);
            this.Controls.Add(this.gbScore);
            this.Controls.Add(this.pbFallingBlocks);
            this.Controls.Add(this.gbControls);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.Name = "FallingBlocksForm";
            this.Text = "FallingBlocks";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FallingBlocksForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.tbrSpeed)).EndInit();
            this.gbControls.ResumeLayout(false);
            this.gbControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFallingBlocks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.gbScore.ResumeLayout(false);
            this.gbScore.PerformLayout();
            this.gbNext.ResumeLayout(false);
            this.gbPieces.ResumeLayout(false);
            this.gbPieces.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerPieceDrop;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnPause;
        internal System.Windows.Forms.TrackBar tbrSpeed;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label Label21;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.PictureBox pbFallingBlocks;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.GroupBox gbScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.GroupBox gbNext;
        private System.Windows.Forms.Timer timerElapsed;
        private System.Windows.Forms.Label lblNumPieces;
        private System.Windows.Forms.GroupBox gbPieces;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

