namespace WhackAMole
{
    partial class FrmStopwatch
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            btnStop = new Button();
            btnReset = new Button();
            lblTimeElapsed = new Label();
            tmrStopwatch = new System.Windows.Forms.Timer(components);
            btnTarget = new Button();
            lblPlayerName = new Label();
            txtPlayerName = new TextBox();
            lblScore = new Label();
            lblLives = new Label();
            lblLevel = new Label();
            lblGameStatus = new Label();
            btnDecoy = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(165, 400);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(90, 35);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += BtnStartClickEH;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(265, 400);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(90, 35);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += BtnStopClickEH;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(365, 400);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(90, 35);
            btnReset.TabIndex = 2;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnResetClickEH;
            // 
            // lblTimeElapsed
            // 
            lblTimeElapsed.AutoSize = true;
            lblTimeElapsed.Font = new Font("Segoe UI", 12F);
            lblTimeElapsed.Location = new Point(25, 405);
            lblTimeElapsed.Name = "lblTimeElapsed";
            lblTimeElapsed.Size = new Size(70, 21);
            lblTimeElapsed.TabIndex = 3;
            lblTimeElapsed.Text = "00:00:00";
            // 
            // tmrStopwatch
            // 
            tmrStopwatch.Interval = 250;
            tmrStopwatch.Tick += TmrStopwatchTickEH;
            // 
            // btnTarget
            // 
            btnTarget.BackColor = Color.LimeGreen;
            btnTarget.Location = new Point(250, 150);
            btnTarget.Name = "btnTarget";
            btnTarget.Size = new Size(120, 55);
            btnTarget.TabIndex = 4;
            btnTarget.Text = "Target";
            btnTarget.UseVisualStyleBackColor = false;
            btnTarget.Click += BtnTargetClickEH;
            // 
            // lblPlayerName
            // 
            lblPlayerName.AutoSize = true;
            lblPlayerName.Font = new Font("Segoe UI", 10F);
            lblPlayerName.Location = new Point(25, 20);
            lblPlayerName.Name = "lblPlayerName";
            lblPlayerName.Size = new Size(89, 19);
            lblPlayerName.TabIndex = 5;
            lblPlayerName.Text = "Player Name:";
            // 
            // txtPlayerName
            // 
            txtPlayerName.Location = new Point(125, 18);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(150, 23);
            txtPlayerName.TabIndex = 6;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 10F);
            lblScore.Location = new Point(25, 60);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(57, 19);
            lblScore.TabIndex = 7;
            lblScore.Text = "Score: 0";
            // 
            // lblLives
            // 
            lblLives.AutoSize = true;
            lblLives.Font = new Font("Segoe UI", 10F);
            lblLives.Location = new Point(140, 60);
            lblLives.Name = "lblLives";
            lblLives.Size = new Size(54, 19);
            lblLives.TabIndex = 8;
            lblLives.Text = "Lives: 3";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Font = new Font("Segoe UI", 10F);
            lblLevel.Location = new Point(255, 60);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(55, 19);
            lblLevel.TabIndex = 9;
            lblLevel.Text = "Level: 1";
            // 
            // lblGameStatus
            // 
            lblGameStatus.AutoSize = true;
            lblGameStatus.Font = new Font("Segoe UI", 10F);
            lblGameStatus.Location = new Point(370, 60);
            lblGameStatus.Name = "lblGameStatus";
            lblGameStatus.Size = new Size(131, 19);
            lblGameStatus.TabIndex = 10;
            lblGameStatus.Text = "Game Status: Ready";
            // 
            // btnDecoy
            // 
            btnDecoy.BackColor = Color.Red;
            btnDecoy.Location = new Point(425, 150);
            btnDecoy.Name = "btnDecoy";
            btnDecoy.Size = new Size(120, 55);
            btnDecoy.TabIndex = 11;
            btnDecoy.Text = "Decoy";
            btnDecoy.UseVisualStyleBackColor = false;
            btnDecoy.Click += BtnDecoyClickEH;
            // 
            // FrmStopwatch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(784, 461);
            Controls.Add(btnDecoy);
            Controls.Add(lblGameStatus);
            Controls.Add(lblLevel);
            Controls.Add(lblLives);
            Controls.Add(lblScore);
            Controls.Add(txtPlayerName);
            Controls.Add(lblPlayerName);
            Controls.Add(btnTarget);
            Controls.Add(lblTimeElapsed);
            Controls.Add(btnReset);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Name = "FrmStopwatch";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Whack-A-Mole";
            Click += FrmStopwatchClickEH;
            Resize += FrmStopwatchResizeEH;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Button btnReset;
        private Label lblTimeElapsed;
        private System.Windows.Forms.Timer tmrStopwatch;
        private Button btnTarget;
        private Label lblPlayerName;
        private TextBox txtPlayerName;
        private Label lblScore;
        private Label lblLives;
        private Label lblLevel;
        private Label lblGameStatus;
        private Button btnDecoy;
    }
}
