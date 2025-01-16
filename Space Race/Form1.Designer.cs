namespace Space_Race
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.p1ScoreOutput = new System.Windows.Forms.Label();
            this.p2ScoreOutput = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.gameWatchOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // p1ScoreOutput
            // 
            this.p1ScoreOutput.AutoSize = true;
            this.p1ScoreOutput.ForeColor = System.Drawing.Color.White;
            this.p1ScoreOutput.Location = new System.Drawing.Point(125, 402);
            this.p1ScoreOutput.Name = "p1ScoreOutput";
            this.p1ScoreOutput.Size = new System.Drawing.Size(14, 16);
            this.p1ScoreOutput.TabIndex = 0;
            this.p1ScoreOutput.Text = "0";
            // 
            // p2ScoreOutput
            // 
            this.p2ScoreOutput.AutoSize = true;
            this.p2ScoreOutput.ForeColor = System.Drawing.Color.White;
            this.p2ScoreOutput.Location = new System.Drawing.Point(613, 402);
            this.p2ScoreOutput.Name = "p2ScoreOutput";
            this.p2ScoreOutput.Size = new System.Drawing.Size(14, 16);
            this.p2ScoreOutput.TabIndex = 1;
            this.p2ScoreOutput.Text = "0";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // gameWatchOutput
            // 
            this.gameWatchOutput.AutoSize = true;
            this.gameWatchOutput.ForeColor = System.Drawing.Color.White;
            this.gameWatchOutput.Location = new System.Drawing.Point(336, 402);
            this.gameWatchOutput.Name = "gameWatchOutput";
            this.gameWatchOutput.Size = new System.Drawing.Size(0, 16);
            this.gameWatchOutput.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.gameWatchOutput);
            this.Controls.Add(this.p2ScoreOutput);
            this.Controls.Add(this.p1ScoreOutput);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Space Racer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label p1ScoreOutput;
        private System.Windows.Forms.Label p2ScoreOutput;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label gameWatchOutput;
    }
}

